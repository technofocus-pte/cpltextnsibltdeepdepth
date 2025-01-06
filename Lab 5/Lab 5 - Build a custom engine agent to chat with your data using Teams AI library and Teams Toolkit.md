# Lab 5: Build a Custom Contoso Agent to Chat with Your Data Using Teams AI Library and Teams Toolkit

**Estimated Time: 45 mins**

## Objective

The objective of this lab is to enable participants to build a custom
Contoso Agent leveraging the Teams AI Library and Teams Toolkit.
Participants will configure the Azure OpenAI API to integrate GPT
capabilities, set up and manage data using Azure OpenAI and Azure Blob
Storage, and deploy a customized chat model tailored for AI-driven
interactions. By the end of the lab, they will have created and
configured a Teams AI-powered custom agent using Visual Studio Code and
the Teams Toolkit, gaining practical experience in deploying and
managing AI-enabled applications.

## Solution Focus Area

This lab guide focuses on enabling participants to leverage the Azure
OpenAI API to create intelligent, context-aware chat interactions.
Participants will configure GPT-based models and integrate with Azure
services like Blob Storage and Azure AI Search for efficient data
management.

The lab provides hands-on experience in deploying and customizing chat
models with tailored prompts and settings to meet business needs.
Additionally, participants will build a custom AI agent using the Teams
AI Library and Teams Toolkit, integrating it seamlessly into
organizational workflows.

## Exercise 1: Configuring Azure OpenAI API and Role Permissions

### Task 1: Creating an Azure OpenAI API key to use OpenAI’s GPT

1.  Navigate to the following the URL +++https://oai.azure.com/portal+++ and
    login using the tenant credentials provided in the resources.

    ![](./media/image1.png)

    ![](./media/image2.png)

2.  On the **Azure AI Foundry** home page Click on **Create new Azure
    OpenAI resource**.

    ![](./media/image3.png)

2.  Create Azure OpenAI Window will open, if prompted sign in again.
    Enter the below given details into respected fields and click on
    **Next**.

    | **Subscription** | **Select the assigned subscription** |
    |-------------------|-------------------------------------|
    | **Resource group** | Click on 🡪 Create new<br>Enter name **RG4OpenAI** then press<br>Ok |
    | **Region**         | East US 2                         |
    | **Name**           | +++ContosoAgent+++                      |
    | **Pricing tier**    | Standard S0                       |


    ![](./media/image4.png)

3.  Under **Network** tab and Tags tab click on **Next**

    ![](./media/image5.png)

    ![](./media/image6.png)

4.  On the **Review + submit** tab click on **Create.**

    ![](./media/image7.png)

5.  After Successful deployment, window automatically navigate to
    CognitiveServiceOpenAI Page. Click on the resource group
    **RG4OpenAI** button, it will navigate to resource page.

![](./media/image8.png)

### Task 2: Assign Cognitive contributor role.

1.  On ContosoAgent resource page, from left navigation bar select
    **Access control (IAM)**, then select **+** **Add** and click **Add
    role assignment**.

    ![](./media/image9.png)

2.  Search and select +++**cognitive service contributor**+++ , click **Next**.

    ![](./media/image10.png)

3.  Click on **Select members** to assign members and click on the
    **Select**. After selecting member click on **Next**.

    ![](./media/image11.png)

    ![](./media/image12.png)

4.  On the assignment type tab, select assignment type as **Active**,
    duration as **Permanent**, and click on **Review +Assign** and again
    **Review + Assign**.

    ![](./media/image13.png)

    ![](./media/image14.png)

## Exercise 2: Set up your data on Azure OpenAI

### Task 1: Deploy chat in AI Foundary

1.  Navigate to +++https://portal.azure.com/+++ and click on **All
    resources**.

    ![](./media/image15.png)

2.  Select the Azure OpenAI service **ContosoAgent** that you created in
    exercise 1, task 4.

    ![](./media/image16.png)

3.  Select **Go to Azure OpenAI Studio**, it will navigate to Azure AI
    Foundry Page.

    ![](./media/image17.png)

    ![](./media/image18.png)

4.  On the left navigation pane, Under **Playgrounds,** Select **Chat.**

    ![](./media/image19.png)

5.  In the **Chat playground** page, click on **Create new deployment**
    à select **From base models**.

    ![](./media/image20.png)

6.  On the **Select a chat completion model** page, search and select
    +++**gpt-35-turbo-16k**+++ , select it and click on **Confirm.**

    ![](./media/image21.png)

7.  On the **Deploy model gpt-35-turbo-16k** pane, Expand the
    **Customize** tab enter the following details, and click on
    **Deploy.**

    - **Deployment type**: Standard

    - **Deployment name**: gpt-35-turbo-16k

    - **Token per Minute Rate**: 5K

    - **Content Filter**: defaultv2

    ![](./media/image22.png)


8.  You can check the deployment under **Shared resources** à
    **Deployments**

    ![](./media/image23.png)

### Task 2: Creating a storage account

1.  Navigate to azure portal +++https://portal.azure.com/+++ search and
    select for Storage account.

    ![](./media/image24.png)

2.  Click on **Create,** enter the following details and click
    **Review + create.**

    Subscription - Select your subscription

    Resource group – RG4OpenAI

    Storage account name - +++contosostorage4+++

    Region – West US

    Primary service – Azure Blob storage or Azure Data Lake Storage Gen 2

    Performance – Standard

    ![](./media/image25.png)

    ![](./media/image26.png)

3.  Click on **Create** and wait for the deployment to complete and then
    click on **Go to resource**.

    ![](./media/image27.png)

    ![](./media/image28.png)

4.  On the newly created storage account, navigate to **Containers**
    under Data storage and click on **+ Container**

    ![](./media/image29.png)

5.  Enter the container name as **source** and click on **create.**

    ![](./media/image30.png)

6.  Click on **source** container and open it.

    ![](./media/image31.png)

7.  To add data into the source container, Click on **Upload** --
    **Browse for files** and then from **C:\Labfiles** select
    **TF-AzureOpenAI.** After selecting file click on **upload** button.

    ![](./media/image32.png)

    ![](./media/image33.png)

### Task 3: Create Azure AI search

1.  On the Azure portal +++https://portal.azure.com/+++ search and select
    +++**AI search**+++ .

    ![](./media/image34.png)

2.  Click on **+ Create** to create a new Azure AI Search resource.

    Enter the following details and click on **Review + create** and then select **Create**.

    Subscription: select your subscription

    Resource Group: RG4OpenAI

    Service name: +++contoso-ai-search-01+++

    Location: Central US

    ![](./media/image35.png)

    ![](./media/image36.png)

3.  On the search-service-contoso-ai-search-01overview click on **Go to resources**.

    ![](./media/image37.png)

4.  On contoso-ai-search-01 overview, save URL endpoint for future use.
    Then from left navigation bar select key and save primary and
    secondary key for future use.
    
    ![](./media/image38.png)

    ![](./media/image39.png)

### Task 4: Add data to chat in Azure AI Foundry

1.  Navigate to **Azure AI Foundry** page, select **Chat** a **Add your
    data à Add a data source**.

    ![](./media/image40.png)

2.  From the dropdown, select **Azure Blob Storage (preview)**.

    ![](./media/image41.png)

3.  On the **Add data** page, enter the following details and click on
    **Next.**

    Select data source – Azure Blob Storage(preview)

    Subscription - Select your subscription

    Select Azure Blob storage resource - contosostorage4

    Select storage container – source

    Select Azure AI Search resource – contoso-ai-search-01

    Index Name - +++contosoindex01+++

    Indexer schedule - Once

    ![](./media/image42.png)

4.  On the **Data management** page, select search type as **keyword**
    and click **Next**.

    ![](./media/image43.png)

5.  On the **Data connection** page, select **API key** and click on
    **Next.**

    ![](./media/image44.png)

6.  On the **Review and finish** page, click on **Save and close.**

    ![](./media/image45.png)

7.  Ingestion will take some time, once completed the data details will
    reflect in the pane. After the data ingestion process is complete,
    you can start creating your custom engine agent using the Teams AI
    library and Teams Toolkit.

    > Note: Files must be in .txt, .md, .html, .pdf, .docx, or .pptx format
    with 16-MB size limit.

    ![](./media/image46.png)

## Exercise 3: Create and configure your custom agent

### Task 1: Adding a Teams Toolkit extension

1.  Open **Visual Studio Code,** on your PC.

    ![](./media/image47.png)

2.  On the VS home page, on the left navigation pane click on the
    **Extensions** icon, search for **Teams Toolkit** and click on
    **Install.**

    ![](./media/image48.png)

3.  Select the Teams Toolkit icon in the Visual
    Studio Code Activity Bar and select **Create a New App**.

    ![](./media/image50.png)

4.  Select **Custom Engine Agent**.

    ![](./media/image51.png)

5.  Select **Basic AI Chatbot**.

    ![](./media/image52.png)

6.  Select **JavaScript** as the programming language.

    ![](./media/image53.png)

7.  Select **Azure OpenAI**.

    ![](./media/image54.png)

8.  Enter the values from the Azure portal, the once which we have
    copied and saved on the notepad.

    - **Azure OpenAI key**

    ![](./media/image55.png)


    - **Azure OpenAI endpoint**

    ![](./media/image56.png)


    - **Deployment name**

    ![](./media/image57.png)


9.  Create a new folder to contain the data related to teams and
    navigate to that location by clicking on **Browse**.

    ![](./media/image58.png)

    ![](./media/image59.png)

10. Enter a +++**TeamsContosoAgent**+++ as name for your custom engine agent,
    select **Enter**. Custom engine agent is created in a few seconds.

    ![](./media/image60.png)

11. Select Yes, I author

    ![](./media/image61.png)


**Take a tour of the source code**

Have a look at what's inside this custom engine agent \> Basic AI
Chatbot template.

| **Folder name** | **Contents** |
|----|----|
| .vscode | VS Code files for debugging. |
| appPackage | Templates for the Teams application manifest. |
| env | Name or value pairs are stored in environment files and used by teamsapp.yml to customize the provisioning and deployment rules. |
| infra | Templates for provisioning Azure resources. |
| src/ | The source code for the notification Teams application. |
| src/index.js | Sets up the bot app server. |
| src/adapter.js | Sets up the bot adapter. |
| src/config.js | Defines the environment variables. |
| src/prompts/chat/skprompt.txt | Defines the prompt. |
| src/prompts/chat/config.json | Configures the prompt. |
| src/app/app.js | Handles business logics for the Basic AI Chatbot. |
| teamsapp.yml | Main project file describes your application configuration and defines the set of actions to run in each lifecycle stages. |
| teamsapp.local.yml | This override teamsapp.yml with actions that enable local execution and debugging. |
| teamsapp.testtool.yml | This override teamsapp.yml with actions that enable local execution and debugging in Teams App Test Tool. |

### Task 2: Configure your custom agent

Let's customize the prompt for your custom engine agent.

1.  Go to src/prompts/chat/skprompt.txt and update the following code
    in **skprompt.txt** file. After update press ctrl+s to save the file.

    ```
    The following is a conversation with an AI assistant, who is an expert on answering questions over the given context.

    Responses should be in a short journalistic style with no more than 80 words.
    ```

    ![](./media/image62.png)

2.  Go to the **config.json** file under prompts/chat. Replace the following
    code and replace the endpoint , index_name, and key values with your
    Azure AI Search resource details. After update press ctrl+s to save
    the file.

    ```
    {
    "schema": 1.1,
    "description": "A bot that can chat with users",
    "type": "completion",
    "completion": {
        "completion_type": "chat",
        "include_history": true,
        "include_input": true,
        "max_input_tokens": 2800,
        "max_tokens": 1000,
        "temperature": 0.9,
        "top_p": 1.0,
        "presence_penalty": 0.6,
        "frequency_penalty": 0.0
    },
    "data_sources": [
        {
        "type": "azure_search",
        "parameters": {
            "endpoint": "AZURE-AI-SEARCH-ENDPOINT",
            "index_name": "YOUR-INDEX_NAME",
            "authentication": {
            "type": "api_key",
            "key": "AZURE-AI-SEARCH-KEY"
            }
        }
        }
    ]
    }
    ```


    ![](./media/image63.png)

3.  Go to src/app/app.js file and add the following variable
    inside OpenAIModel:

    ```
    azureApiVersion: '2024-02-15-preview',
    ```

    ![](./media/image64.png)

4.  Open Powershell as an administrator and run the following command,
    and enter A.

    ```
    Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned
    ```
    
    ![](./media/image65.png)

5.  From the left pane, select **Run and Debug (Ctrl+Shift+D)**.
    Select **Debug in Test Tool.** Press the **F5** key.

    ![](./media/image66.png)

6.  Custom engine agent runs within the Teams App Test Tool, which opens
    in your browser.

    ![](./media/image67.png)

7.  The browser will open a new tab, Teams App Test Tool and queries can
    be run in the app.

    ![](./media/image68.png)


## Conclusion

By completing this lab, participants have gained hands-on experience in
building and deploying a custom AI-driven chatbot using the Teams AI
Library and Teams Toolkit. This included setting up Azure OpenAI
resources, integrating data storage and AI search capabilities, and
customizing the chatbot for context-aware interactions. Through this
exercise, participants have learned how to configure intelligent agents
tailored to business needs and integrate them into organizational
workflows, effectively leveraging modern AI capabilities within
Microsoft Teams.
