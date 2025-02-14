
# Lab 5 - Creating a Custom AI Agent with Azure AI Foundry and search integration

**Estimated time: 45 min**

## Objective

The objective of this lab is to guide participants in building an
AI-powered agent using Azure AI services and Search integration.
Retrieval Augmented Generation (RAG) is a technique used to build
applications that integrate data from custom data sources into a prompt
for a generative AI model. RAG is a commonly used pattern for developing
generative AI apps - chat-based applications that use a language model
to interpret inputs and generate appropriate responses. Participants
will learn to use Azure AI Foundry portal to integrate custom data into
a generative AI prompt flow.

Solution

This lab focuses on integrating Azure AI services with advanced search
capabilities to create a robust, intelligent solution. It emphasizes
configuring an AI-powered agent, enabling seamless data retrieval, and
providing contextual responses. By leveraging AI and search integration,
the solution aims to streamline workflows, improve decision-making, and
enhance user engagement through intuitive and efficient interactions.

## Task 1: Create an Azure AI Search resource

1.  In a web browser, open the Azure
    portal at +++<https://portal.azure.com>+++ and **Sign in** using

  - Username - +++@lab.CloudPortalCredential(User1).Username+++
  
  - Password - +++@lab.CloudPortalCredential(User1).Password+++

  ![A screenshot of a computer Description automatically generated](./media/image1.png)

2.  On the home page, select **+ Create a resource.**

  ![A screenshot of a computer Description automatically generated](./media/image2.png)

3.   From the search bar, search for and select +++**Azure AI
    Search**+++.

  ![A screenshot of a computer Description automatically generated](./media/image3.png)

4.  Select the drop down next to **Create** and select **Azure AI
    Search**.

  ![A screenshot of a computer Description automatically generated](./media/image4.png)

5.  In the Create a search service page, enter the below details and
    click on **Review + create**.

    - **Subscription**: Select your Azure subscription from the drop
      down.

    - **Resource group**: Select the Resource group assigned to your
      subscription (ResourceGroup1)

    - **Service name**: *+++*aisearch@lab.LabInstanceId+++

    - **Location**: Select **Canada East** region

    - **Pricing tier**: Standard

  ![A screenshot of a computer Description automatically generated](./media/image5.png)

6.  Review the settings in the click on **Create**.

  ![A screenshot of a search service Description automatically generated](./media/image6.png)

7.  Wait for your Azure AI Search resource deployment to be completed.

  ![A screenshot of a computer Description automatically generated](./media/image7.png)

  >[!Note] **Note:** Later, you’re going to create an Azure AI Hub (which includes an Azure OpenAI service) in the same region as your Azure AI Search resource. Azure OpenAI resources are constrained at the tenant level by regional quotas. In the event of a quota limit being reached later in the exercise, there’s a possibility you may need to create another Azure AI hub in a different region.

## Task 2: Create an Azure AI project

1.  In a web browser, open **Azure AI Foundry portal** at +++https://ai.azure.com+++ and
    **sign in** using

    - Username - <+++@lab.CloudPortalCredential(User1).Username>+++
    
    - Password - +++@lab.CloudPortalCredential(User1).Password+++

   ![](./media/image8.png)

2.  **Close** the **Help** tab and select **Got it** in the
    **Streamlined from the start** pop up.

3.  In the home page, select **+ Create project**.

    ![](./media/image9.png)

4.  In the **Create a project** wizard enter project name as
    +++**ragpfproject@lab.LabInstanceId**+++ and click on **Customize**.

    ![](./media/image10.png)

5.  **In Customize**, connect to your Azure AI Search resource, enter
    the following details, select **Next** and review your
    configuration.

    - **Hub name**: +++**hub@lab.LabInstanceId**+++

    - **Azure Subscription**: Select the assigned Azure subscription

    - **Resource group**: Select the assigned Resource Group

    - **Location**: The same **location** as your **Azure AI Search
      resource**, Canada East

    - **Connect Azure AI Services or Azure OpenAI**: (New) Autofill’s
      with your hub name

    - **Connect Azure AI Search**: Select your Azure AI Search resource,
      **aisearch@lab.LabInstanceId**

    ![](./media/image11.png)

6.  Review the details and click on **Create** and wait for the process
    to complete.

    ![](./media/image12.png)

7.  **Close** the Explore and experiment pop up.

    ![](./media/image13.png)

8.  You will land in the created project page.

    ![](./media/image14.png)

## Task 3: Deploy models

You need two models to implement your solution:

- An embedding model to vectorize text data for efficient indexing and
  processing.

- A model that can generate natural language responses to questions
  based on your data.

1.  Select **Models + endpoints** under **My assets** from the left
    pane.

    ![](./media/image15.png)

2.  On the **Manage deployments of your models and services page,**
    click on **+Deploy model** and select **Deploy base model.**

    ![A screenshot of a computer Description automatically generated](./media/image16.png)

3.  On the **Select a model** page, search and
    select +++**text-embedding-ada-002**+++ model and click on
    **Confirm.**

    ![A screenshot of a computer Description automatically generated](./media/image17.png)

4.  On the **Deploy model text-embedding-ada-002** pane, accept the pre-
    populated values for the **Deployment name** and **Deployment
    type**. Click on **Customize** and enter the following details in
    the Deploy model wizard.

    ![A screenshot of a computer Description automatically generated](./media/image18.png)

  - **Model version**: *Select the default version*
  
  - **AI resource**: *Select the resource created previously that gets
    listed*
  
  - **Tokens per Minute Rate Limit (thousands)**: 5K
  
  - **Content filter**: DefaultV2
  
  - **Enable dynamic quota**: Disabled

  ![A screenshot of a computer Description automatically generated](./media/image19.png)

  ![A screenshot of a computer Description automatically generated](./media/image20.png)

  ![A screenshot of a computer Description automatically generated](./media/image21.png)

5.  Repeat the previous steps to deploy a **gpt-35-turbo-16k** model
    with the deployment name gpt-35-turbo-16k.

  ![A screenshot of a computer Description automatically generated](./media/image22.png)

6.  We now have the two deployments ready.

  ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

  >[!Note] **Note:** Reducing the Tokens Per Minute (TPM) helps avoid over-using the quota available in the subscription you are using. 5,000 TPM is sufficient for the data used in this exercise.

## Task 4: Add data to your project

The data for your copilot consists of a set of travel brochures in PDF
format from the fictitious travel agency *Margie’s Travel*. Let’s add
them to the project.

1.  Select **Data + indexes** under **My assets** from the left pane.
    Select **+ New data**.

  ![A screenshot of a computer Description automatically generated](./media/image24.png)

2.  In the **Add your data** wizard, select **Upload files/folders**
    from the drop down.

  ![A screenshot of a computer Description automatically generated](./media/image25.png)

3.  Select **Upload folder** and select the **brochures** folder from
    **C:\LabFiles** and click **Upload**.

  ![A screenshot of a computer Description automatically generated](./media/image26.png)

  ![A screenshot of a computer Description automatically generated](./media/image27.png)

4.  Wait for the folder to be uploaded and note that it contains several
    .pdf files. Select **Next** once the files are all uploaded.

    ![A screenshot of a computer Description automatically generated](./media/image28.png)

5.  On the next page of name and finish, enter the data name as
    +++**data@lab.LabInstanceId**+++ and click on **Create.**

    ![A screenshot of a computer Description automatically generated](./media/image29.png)

    ![A screenshot of a computer AI-generated content may be incorrect.](./media/image30.png)

## Task 5: Create an index for your data

Now that you’ve added a data source to your project, you can use it to
create an index in your Azure AI Search resource.

1.  From the **Data + indexes** page, select the **Indexes** tab.

    ![A screenshot of a computer Description automatically generated](./media/image31.png)

2.  In the **Indexes** tab, select **+ New index** to add a new index.

    ![A screenshot of a computer Description automatically generated](./media/image32.png)

3.  Enter the below details and click on **Next**.

    - **Data source** - Select **Data in Azure AI Foundry**

    Select the listed **data source** and then click on **Next**.

    ![A screenshot of a computer Description automatically
generated](./media/image33.png)

4.  Enter the below details in the Create a vector index – Index
    configuration page and click on **Next.**

    - **Select Azure AI Search service**: Select **AzureAISearch** **Vector
      index**: brochures-index
    
    - Vector index - +++**brochures-index**+++
    
    - **Virtual machine**: Select **Auto select**

    ![A screenshot of a computer Description automatically generated](./media/image34.png)

5.  In the Create a vector index – Search settings page,

    **Vector settings** - Select **Add vector search to this search
resource**

    Accept the other defaults and select **Next.**

    ![A screenshot of a search box Description automatically generated](./media/image35.png)

6.  In the **Review and finish** page, review the details and select
    **Create vector index**.
 
     ![A screenshot of a computer Description automatically generated](./media/image36.png)

7.  Wait for the indexing process to be completed, which can take
    several minutes. The index creation operation consists of the
    following jobs:

    - Crack, chunk, and embed the text tokens in your brochures data.

    - Create the Azure AI Search index.

    - Register the index asset.

    ![A screenshot of a computer error Description automatically
generated](./media/image37.png)

    ![A screenshot of a computer program Description automatically
generated](./media/image38.png)

## Task 6: Test the index

Before using your index in a RAG-based prompt flow, let’s verify that it
can be used to affect generative AI responses.

1.  Select the **Playgrounds** from the left pane and select **Chat
    Playground.**

    ![A screenshot of a chat Description automatically generated](./media/image39.png)

2.  Click on **Show setup** if it is not visible by default.

    ![A screenshot of a computer Description automatically generated](./media/image40.png)

3.  Ensure that your **gpt-35-turbo** model deployment is selected.
    Then, in the main chat session panel, submit the prompt +++**Where
    can I stay in New York?**+++

    ![A screenshot of a computer program Description automatically generated](./media/image41.png)

    ![A screenshot of a chat Description automatically generated](./media/image42.png)

4.  Review the response, which should be a generic answer from the model
    without any data from the index.

5.  In the Setup pane, expand the **Add your data** field,
    select **brochures-index** project index and select the **hybrid
    (vector + keyword)** search type.

    ![A screenshot of a computer Description automatically generated](./media/image43.png)

    >[!Note] **Note:** Some users are finding newly created indexes unavailable right away. Refreshing the browser usually helps, but if you’re still experiencing the issue where it can’t find the index you may need to wait until the index is recognized.

6.  This addition of the data source starts a new session. Once that is
    done, resubmit the prompt +++**Where can I stay in New York?**+++

    ![A screenshot of a chat Description automatically generated](./media/image44.png)

7.  Review the response and note that now the response is based on data
    in the index.

    ![A screenshot of a chat Description automatically generated](./media/image45.png)

## Task 7: Use the index in a prompt flow

Your vector index has been saved in your Azure AI Foundry project,
enabling you to use it easily in a prompt flow.

1.  Select the **Prompt flow** under **Build and customize** from the
    left navigation pane and then click on **Create**.

    ![](./media/image46.png)

2.  Select **Clone** under Multi-Round Q&A on Your Data.

    ![A screenshot of a computer Description automatically generated](./media/image47.png)

3.  Give the folder name as +++**brochure-flow**+++ and click on
    **Clone**.

    ![A screenshot of a computer Description automatically generated](./media/image48.png)

    > [!Note] **Note:** If you face permissions error, retry with a new name after 2 minutes and the flow will get cloned.

    ![](./media/image49.png)

4.  When the prompt flow designer page opens, review **brochure-flow**.
    Its graph should resemble the following image:

    ![](./media/image50.png)

    ![A screenshot a a prompt flow graph](./media/image51.png)

    The sample prompt flow you are using implements the prompt logic for a
chat application in which the user can iteratively submit text input
to chat interface. The conversational history is retained and included
in the context for each iteration. The prompt flow orchestrates a
sequence of *tools* to:

    - Append the history to the chat input to define a prompt in the form of
      a contextualized form of a question.
    
    - Retrieve the context using your index and a query type of your own
      choice based on the question.
    
    - Generate prompt context by using the retrieved data from the index to
      augment the question.
    
    - Create prompt variants by adding a system message and structuring the
      chat history.
    
    - Submit the prompt to a language model to generate a natural language
      response.

5.  Use the **Start compute session** button to start the runtime
    compute for the flow.

    Wait for the runtime to start. This provides a compute context for the prompt flow. While you’re waiting, in the **Flow** tab, review the sections for the tools in the flow.

    ![A screenshot of a computer screen Description automatically generated](./media/image52.png)

6.  In the **Inputs** section, ensure the inputs include:

    - **chat_history**

    - **chat_input**

The default chat history in this sample includes some conversation about
AI.

  ![](./media/image53.png)

7.  In the **Outputs** section, ensure that the output includes:

    - **chat_output** with value ${chat_with_context.output}

   ![](./media/image54.png)

8.  In the **modify_query_with_history** section, select the following
    settings (leaving others as they are):

    - **Connection**: Select the **Azure OpenAI resource** for your AI
      hub that gets listed

    - **Api**: Select **chat**

    - **deployment_name**: Select **gpt-35-turbo-16k**

    - **response_format**: Select **{“type”:”text”}**

    ![](./media/image55.png)

9.  Once the compute session has started, in the **lookup** section, set
    the following parameter values:

    - **mlindex_content**: *Select the empty field to open the Generate
      pane*

      - **index_type**: Select **Registered Index**

      &nbsp;

      - **mlindex_asset_id**: Select **brochures-index:1**

    ![A screenshot of a computer Description automatically generated](./media/image56.png)

    ![A screenshot of a computer Description automatically generated](./media/image57.png)

    Back in the Lookup section enter the below details

    - **queries**: ${modify_query_with_history.output}
    
    - **query_type**: Hybrid (vector + keyword)
    
    - **top_k**: 2

    ![A screenshot of a computer Description automatically generated](./media/image58.png)

10. In the **generate_prompt_context** section, review the Python script
    and ensure that the **inputs** for this tool include the following
    parameter:

    - **search_result** *(object)*: ${lookup.output}

    ![A screenshot of a computer Description automatically generated](./media/image59.png)

11. In the **Prompt_variants** section, review the Python script and
    ensure that the **inputs** for this tool include the following
    parameters:

    - **contexts** *(string)*: ${generate_prompt_context.output}

    - **chat_history** *(string)*: ${inputs.chat_history}

    - **chat_input** *(string)*: ${inputs.chat_input}

    ![A screenshot of a chat Description automatically generated](./media/image60.png)

12. In the **chat_with_context** section, select the following settings
    (leaving others as they are):

    - **Connection**: Select the **Azure OpenAI resource**

    - **Api**: Chat

    - **deployment_name**: gpt-35-turbo-16k

    - **response_format**: {“type”:”text”}

    Then ensure that the **inputs** for this tool include the following
parameters:

    - **prompt_text** *(string)*: ${Prompt_variants.output}

    ![A screenshot of a computer Description automatically generated](./media/image61.png)

13. Select the **Save** button in the toolbar, to save the changes
    you’ve made to the tools in the prompt flow.

    ![A screenshot of a computer Description automatically generated](./media/image62.png)

14. From the toolbar, select **Chat**. A chat pane opens with the sample
    conversation history and the input already filled in based on the
    sample values. You can ignore these.

    ![A screenshot of a computer Description automatically generated](./media/image63.png)

15. In the chat pane, replace the default input with the
    question +++**Where can I stay in London?**+++ and submit it.

    ![](./media/image64.png)

16. The response is based on data in the index.

17. Review the outputs for each tool in the flow.

    ![A screenshot of a computer Description automatically generated](./media/image65.png)

18. In the chat pane, enter the question +++**What can I do there?**+++

19. Review the response, which should be based on data in the index and
    it takes **chat history** into account (so “**there**” is understood
    as “**in London**”).

    ![A screenshot of a chat Description automatically generated](./media/image66.png)

20. Review the outputs for each tool in the flow, noting how each tool
    in the flow operated on its inputs to prepare a contextualized
    prompt and get an appropriate response.

## Task 8: Clean up the resources:

1.  From the Azure portal (+++https://portal.azure.com+++), select the
    **ResourceGroup1**(the one assigned to you).

2.  Select all the resources under it and click on **Delete**.

    ![A screenshot of a computer Description automatically generated](./media/image67.png)

3.  Enter +++**delete**+++ and click on the **Delete** button to confirm
    deletion. Click on **Delete** in the Delete confirmation dialog box.

    ![A screenshot of a computer Description automatically generated](./media/image68.png)

4.  Ensure that the resources are deleted, by the delete confirmation
    message.

    ![A screenshot of a computer screen Description automatically
generated](./media/image69.png)

**Summary:**

In this lab, we have learnt to create a custom agent that uses your own
data from **Azure AI Foundry**.
