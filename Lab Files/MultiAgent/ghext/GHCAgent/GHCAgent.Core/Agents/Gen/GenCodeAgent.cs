using System.Security;
using Azure;
using Azure.AI.Inference;

namespace GHCAgent.Core.Agents
{
    public class GenCodeAgent
    {

        private static AzureKeyCredential credential = null;
        private static ChatCompletionsClient client = null;
        

        public static void Init()
        {
            if(credential == null)
            {
                credential = new AzureKeyCredential("Your GitHub Model Key");
            }

            if(client == null)
            {
                client = new ChatCompletionsClient(new Uri("https://models.inference.ai.azure.com"),credential);
            }

        }

        public static string GenRequirement(string req)
        {

            string  note =  """

            Note:

            1. Use Python Flask to create a Repository pattern based on the following structure to generate the files

            ｜- models
            ｜- controllers
            ｜- repositories
            ｜- views

            2. For the view page, please use SPA + VueJS + TypeScript to build

            3. Firstly use markdown to output the generated project structure (including directories and files), and then generate the  file names and corresponding codes step by step, output like this 

               ## Project Structure

                    ｜- models
                        | - user.py
                    ｜- controllers
                        | - user_controller.py
                    ｜- repositories
                        | - user_repository.py
                    ｜- templates
                        | - index.html

               ## Backend
                 
                   #### `models/user.py`
                   ```python

                   ```
                   .......
               

               ## Frontend
                 
                   #### `templates/index.html`
                   ```html

                   ```
                   .......

            """;

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestUserMessage("Please create a project with Python and Flask according to the following requirements：\n" + req + note),
                },
                Model = "o1-mini"
            };

            Response<ChatCompletions> response = client.Complete(requestOptions);


            return response.Value.Content;
        }
    }
}