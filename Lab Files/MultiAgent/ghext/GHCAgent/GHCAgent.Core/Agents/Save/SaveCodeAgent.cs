
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Azure.Core;
using Azure.Identity;
using Azure.AI.Projects;
using System.Text;
using System.Collections.Specialized;



namespace GHCAgent.Core.Agents
{
    public class SaveCodeAgent
    {
        private static AgentsClient client = null;
        private static Azure.Response<Agent> agentResponse = null;
        private static Agent agent = null; 

        private static string connectionString = "Your Azure Foundry Project Connection String";
        

        private static async void Init()
        {
            if(client == null)
            {
                client = new AgentsClient(connectionString, new DefaultAzureCredential());
            }

            if(agentResponse==null)
            {
                agentResponse = await client.CreateAgentAsync(
                                    model: "gpt-4o-mini",
                                    name: "code-agent",
                                    instructions: "You are helpful agent",
                                    tools: new List<ToolDefinition> { new CodeInterpreterToolDefinition() });
            }

            if(agent == null)
            {
                agent = agentResponse.Value;
            }

        }

        public static async Task<string> SaveCode(string req)
        {


            // Console.WriteLine("bbbbbbbbbbb 来来了"+req);

            Init();
            Azure.Response<AgentThread> threadResponse = await client.CreateThreadAsync();
            AgentThread thread = threadResponse.Value;

            string note = @"Note：

                1. All files in the folder need to be created and cannot be missing. Name them according to the provided name

                2. Please add the contents of the corresponding files

                3. After successful creation, please package it into a zip file , the zip file name is proj-yymmddhhmmss.zip";



            Azure.Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
                                                                thread.Id,
                                                                MessageRole.User,
                                                                @"You are a bash assistant, please create folders and files according to the following project structure \n"+req +" \n"+note);

            ThreadMessage message = messageResponse.Value;

            Azure.Response<PageableList<ThreadMessage>> messagesListResponse = await client.GetMessagesAsync(thread.Id);

            Azure.Response<ThreadRun> runResponse = await client.CreateRunAsync(
                                                    thread.Id,
                                                    agent.Id);

            ThreadRun run = runResponse.Value;

            do
            {
                        await Task.Delay(TimeSpan.FromMilliseconds(500));
                        runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
            }
            while (runResponse.Value.Status == RunStatus.Queued
                        || runResponse.Value.Status == RunStatus.InProgress);


            Azure.Response<PageableList<ThreadMessage>> afterRunMessagesResponse = await client.GetMessagesAsync(thread.Id);
            IReadOnlyList<ThreadMessage> messages = afterRunMessagesResponse.Value.Data;

            string fileName = "";

            foreach (ThreadMessage threadMessage in messages)
            {
                        Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");

                        foreach (MessageContent contentItem in threadMessage.ContentItems)
                        {
                            
                            if (contentItem is MessageTextContent textItem)
                            {
                                Console.Write(textItem.Text);

                                if(textItem.Annotations is not null && textItem.Annotations.Count > 0)
                                {

                                    if(textItem.Annotations[0] is MessageTextFilePathAnnotation pathItem )
                                    {
                                        Console.Write($"[Download file]({pathItem.Text})");

                                        Azure.Response<AgentFile> agentfile = await client.GetFileAsync(pathItem.FileId);

                                        Azure.Response<BinaryData> fileBytes = await client.GetFileContentAsync(pathItem.FileId);

                                        // Console.Write("baba:"+agentfile.Value.Filename);
                                        fileName = agentfile.Value.Filename;

                                        var zipfile =System.IO.Path.GetFileName(agentfile.Value.Filename);

                                        using System.IO.FileStream stream = System.IO.File.OpenWrite($"./arch/{zipfile}");
                                        fileBytes.Value.ToStream().CopyTo(stream);

                                    }

                                }

                            }
                            Console.WriteLine();
                        }


            }



            return "Saved ![Download file](http://localhost:5284/arch/"+fileName+")";

        }

    }
}