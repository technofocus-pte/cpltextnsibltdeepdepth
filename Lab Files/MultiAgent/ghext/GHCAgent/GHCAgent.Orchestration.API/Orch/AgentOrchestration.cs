using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Agents.Chat;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;

using Azure.Identity;
using Azure.AI.Projects;
using Azure.Core;
using Azure.Core.Pipeline;

using GHCAgent.Orchestration.API.Plugins;

namespace GHCAgent.Orchestration.API.Orch
{

    public class AgentOrchestration
    {
        private static string deployment = "gpt-4o-mini";
        private static string endpoint = "Your AOAI Endpoint";
        private static string key = "Your AOAI Endpoint Key";

        private static Kernel kernel = null;

        const string GenCodeName = "GenCode";
        const string GenCodetInstructions = "You are a Python developer, help me to gerneate code based on the requirements";

        const string SaveCodeName = "SaveCode";
        const string SaveCodeInstructions = "You are a bash assistatnt , help me to save code from generation code. Respond with \"Saved [Download File](http://localhost:5284/arch/+zipfilename)\" to when your code are saved";

        #pragma warning disable SKEXP0110
        private static ChatCompletionAgent gen_code_agent =null;
        private static ChatCompletionAgent save_code_agent = null;

        private static AgentGroupChat chat = null;



        public static void Init()
        {
            #pragma warning disable SKEXP0010
            #pragma warning disable SKEXP0110
            if(kernel == null)
            {
                kernel = Kernel.CreateBuilder()
                            .AddAzureOpenAIChatCompletion(deployment, endpoint, key).Build();

                    

                ChatCompletionAgent gen_code_agent = new()
                {
                    Name = GenCodeName,
                    Instructions = GenCodetInstructions,
                    Kernel = kernel,
                    Arguments = new KernelArguments(new AzureOpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() }),
                };

                ChatCompletionAgent save_code_agent = new()
                {
                    Name = SaveCodeName,
                    Instructions = SaveCodeInstructions,
                    Kernel = kernel,
                    Arguments = new KernelArguments(new AzureOpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() }),
                };

                KernelPlugin gencode_plugin = KernelPluginFactory.CreateFromType<GenCodePlugin>();
                KernelPlugin savecode_plugin = KernelPluginFactory.CreateFromType<SaveCodePlugin>();
                gen_code_agent.Kernel.Plugins.Add(gencode_plugin);
                save_code_agent.Kernel.Plugins.Add(savecode_plugin);



                chat = new(gen_code_agent, save_code_agent)
                                        {
                                            ExecutionSettings =
                                                new()
                                                {
                                                    TerminationStrategy =
                                                        new ApprovalTerminationStrategy()
                                                        {
                                                            Agents = [save_code_agent],
                                                            MaximumIterations = 10,
                                                        }
                                                }
                                        };

                }
        }

        public static async Task<string> Orchestration(string prompt)
        {
            Init();

            #pragma warning disable SKEXP0110

            string requirements = @"Generate the code according to the following requirements, then save all files and folders from generation code. \n";


            ChatMessageContent input = new(AuthorRole.User, requirements + prompt);
            chat.AddChatMessage(input);

            string result = "";

            #pragma warning disable SKEXP0001
            await foreach (ChatMessageContent content in chat.InvokeAsync())
            {
                Console.WriteLine($"# {content.Role} - {content.AuthorName ?? "*"}: '{content.Content}'");
                if(content.AuthorName == SaveCodeName)
                {
                    result = content.Content ?? string.Empty;
                }
            }

            return result.Replace("!","").Replace("Saved","");

        }
    }

    public class ApprovalTerminationStrategy : TerminationStrategy
    {
        // Terminate when the final message contains the term "approve"
        protected override Task<bool> ShouldAgentTerminateAsync(Microsoft.SemanticKernel.Agents.Agent agent, IReadOnlyList<ChatMessageContent> history, CancellationToken cancellationToken)
            => Task.FromResult(history[history.Count - 1].Content?.Contains("Saved", StringComparison.OrdinalIgnoreCase) ?? false);
    }

}