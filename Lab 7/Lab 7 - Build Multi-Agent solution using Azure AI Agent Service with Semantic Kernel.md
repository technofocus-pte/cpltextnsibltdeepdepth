# Lab 7 - Build Multi-Agent solution using Azure AI Agent Service with Semantic Kernel 

We can build enterprise-oriented AI agents through Azure AI Agent
Service.

**Introduction**

The following introduces a blog writing scenario. This scenario involves
two AI agents: one for writing assistance, and the next for content
storage and management. These agents can be seamlessly orchestrated
using AutoGen or Semantic Kernel. In this lab, we are using the Semantic
Kernel Orchestration.

![A diagram of a diagram of a business AI-generated content may be
incorrect.](./media/image1.png)

**Objective:**

Using Azure AI Foundry SDK, developers can quickly build agents based on
Azure AI Agent Service using Python or C#. Enterprises will have
different AI Agents based on their business, so how should these AI
Agents be combined in the workflow? We need to use AutoGen or Semantic
Kernel to orchestrate the AI Agents. In this lab, we use Semantic Kernel
to develop a Multi-Agent solution using Azure AI Agent Service.

## Exercise 1: Create an Azure AI Hub resource and project

In this exercise, we will create the hub in the Azure portal, then a project in the Azure AI Foundry, deploy the model and create the agent required for the execution.

1.  From a browser, open +++**https://portal.azure.com/**+++, and login using your **login** **credentials** and select **Azure AI Foundry** from the **Home** page.

    - User name – +++@lab.CloudPortalCredential(User1).Username+++
    
    - Password – +++@lab.CloudPortalCredential(User1).Password+++

    ![image](https://github.com/user-attachments/assets/b26ef8b5-13dd-414e-91bb-c2963cf7cce0)
    
2.	Select **Use with AI Foundry** -> **AI Hubs**. Select **+ Create** -> **Hub**.

    ![image](https://github.com/user-attachments/assets/d5b52709-4acc-4700-9da4-39e4f99bab1b)

3.	 Enter the below details, accept the other defaults and select **Review + create**.
   
     -	Subscription - Select your **assigned subscription**
     
     -	Resource group - Select your assigned Resource group (**ResourceGroup1**)
     
     -	Region - Select @lab.CloudResourceGroup(ResourceGroup1).Location
     
     -	Name - +++hub@lab.LabInstance.Id+++

     ![image](https://github.com/user-attachments/assets/8d93aaba-be60-428d-87c0-31d808dbe764)
 
     ![image](https://github.com/user-attachments/assets/373f295f-0978-4ec6-befa-197ea1abc3a5)

4.	 Once the validation passes, select **Create**.

     ![image](https://github.com/user-attachments/assets/dbd63853-0474-4df4-b77c-c29472bfd0ed)

5.	 Once the deployment is complete, click on **Go to resource**.

     ![image](https://github.com/user-attachments/assets/9b06560b-8a37-41d1-935f-0c7f9dce13f4)

6.	 Select **Launch Azure AI Foundry** from the hub resource page.

     ![image](https://github.com/user-attachments/assets/c0d16b19-0425-48e2-8a97-0efde10642c4)

7.	 From the launched hub resource, scroll down and select **+ New project**.

     ![image](https://github.com/user-attachments/assets/f38fd293-fa4c-410b-a8fc-fe5427ede9ad)

     ![image](https://github.com/user-attachments/assets/40c1a532-0953-42b6-b728-4084f8ceea04)

8.	 Enter the name as +++multiagent@lab.LabInstance.Id+++ and select **Create**.

     ![image](https://github.com/user-attachments/assets/e4b5fd6b-2fa1-4790-9042-4f4642aedaba)

9.	 **Close** the Explore and experiment pop up.

     ![image](https://github.com/user-attachments/assets/745309d4-4b57-4303-8623-8e538ece3e25)

10.  You will land in the created project page.

     ![image](https://github.com/user-attachments/assets/d8fd443d-0181-4ecd-ac00-64488705fa81)

11.  Scroll down the page and copy the value of the **Project connection string** to a notepad.

     ![image](https://github.com/user-attachments/assets/ec005fdd-75c4-4871-9fd3-aba1cb657d84)

12.  Scroll down in the left pane and select **Management center**.

     ![image](https://github.com/user-attachments/assets/cdaa9a3a-4f72-4dd1-9f65-95d710d7663c)

13.  Select **Connected resources** under the Hub resource and then click on **+ New connection** to create a connection with the Azure AI Foundry resource.

     ![image](https://github.com/user-attachments/assets/e5cdc311-b72b-447f-9517-f2f84afdb663)

14.  Select **Azure AI Foundry** from the available external assets.

     ![image](https://github.com/user-attachments/assets/2d2b9ed9-78f3-466d-a374-0c79935bf4da)

15.  Select **Add connection** to add the connection.

     ![image](https://github.com/user-attachments/assets/babc62ed-5218-41bb-9820-f0a2f979ec8f)

     ![image](https://github.com/user-attachments/assets/dbdfe97a-5aa3-4782-927c-b70d3d59d185)

16.  Once connected, click on **Close**. If the **Close** button is not visible, reduce the **zoom size** of the browser and then select **Close**.

     ![image](https://github.com/user-attachments/assets/c20d1bca-2e92-4263-bb09-d65847f03839)

17.  Select **Go to project** from the left pane.

     ![image](https://github.com/user-attachments/assets/9062a254-ce3a-4a64-8a0b-4e0b5abec790)

18.  From the project page, copy the values of the **API Key** and the **Azure OpenAI endpoint** and save it to a notepad.

     ![image](https://github.com/user-attachments/assets/020eedc1-9d7e-4219-b546-28f0c76bcfe9)

19.  Select **Agents** under **Build and customize** from the left pane.
     In the **Azure AI Agent Service** page, select your **Azure OpenAI
     Service** that was created, and then click on **Let’s go**.

     ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

20.  Select **gpt-4o-mini** and click on **Confirm**.

     ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

21.  Accept the deployment name as +++**gpt-4o-mini**+++, select the Deployment type to be **Standard**. Accept the other defaults and click on **Deploy** to deploy the model.

     ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

     ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

22.  Now, we have the Azure resources ready.

## Exercise 2: Multi Agent Orchestration 

In this exercise, we will set up the Visual Studio Code and install the pre requisites that are needed for the execution.
1.  From your VM, open the **Visual Studio Code**.

    ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

2.  Select **File** -> **Open Folder** and select the folder
    **MultiAgent** from **C:\LabFiles** and click **Select Folder**.

    ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

    ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

3.  Select **Yes, I trust the authors** in the pop up.

    ![A screenshot of a computer error AI-generated content may be
incorrect.](./media/image15.png)

4.  Right click on the notebook and select **Open in Integrated
    Terminal**.

    ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

5.  Execute the below commands one after another to add the **nuget
    source**.

    +++dotnet nuget list source+++

    ![A screenshot of a computer AI-generated content may be incorrect.](./media/image17.png)

    +++dotnet nuget add source https://api.nuget.org/v3/index.json --name nuget.org+++

    ![A screenshot of a computer AI-generated content may be incorrect.](./media/image18.png)

6.  Execute the below command to install dotnet interacrive.

    +++dotnet tool install --global Microsoft.dotnet-interactive --version 1.0.556801+++

    ![](./media/image19.png)

7.  Execute +++pip install jupyter+++ to install Jupyter.

    ![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image20.png)

8.  Execute the next command to jupyter interactive.

    +++dotnet interactive jupyter install+++

    ![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image21.png)

9.  **Close** the **Terminal**. Select **Extensions** from the left pane
    pf the **Visual Studio Code**. Search and select +++**Jupyter**+++ and
    click on **Install** to install the Jupyter extension.

    ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image22.png)

10. **Close** the Visual Studio Code and **open** it again.

11. Open the notebook **AzureAIMultiAgentWithSK.ipynb**. Once opened,
    click on **Select Kernel**.

    ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

12. Select **Jupyter Kernel**.

    ![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image24.png)

13. Select **.NET (C#) dotnet** in the next set of options.

    ![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image25.png)

14. Select **Allow access** in the **Security Alert**.

    ![A screenshot of a computer security alert AI-generated content may be
incorrect.](./media/image26.png)

15. Execute the first cell to **install** all the required **packages**.

    ![A screen shot of a computer program AI-generated content may be incorrect.](./media/image27.png)

    ![A screenshot of a computer program AI-generated content may be incorrect.](./media/image28.png)

16. Execute the next cell to import the namespaces.

    ![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image29.png)

17. In the next cell, verify that the **deployment** variable value is
    the same as the **model deployment** that you created. Replace,

    - Endpoint – **Azure OpenAI Endpoint**
    
    - Key – The **API Key**

    Both the values above, we have saved earlier in a notepad once the
project was created in the Azure AI Foundry.

    After replacing the values, **execute** the cell.

    This sets these values to corresponding variables to be used further.

    ![A black screen with numbers AI-generated content may be incorrect.](./media/image30.png)

18. The next cell creates a new **KernelBuilder** instance, adds **Azure
    OpenAI Chat Completion** as an AI service provider to the kernel
    with the variables from the last step as input and invokes
    **Build**() creates an instance of Kernel.

    **Execute** it to create the Kernel instance.

    ![A screen shot of a computer code AI-generated content may be incorrect.](./media/image31.png)

19. Execute the next cell to install the required **Azure** packages and
    the next cell to import the references.

    ![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image32.png)

    ![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image33.png)

20. The class in the next cell defines a **custom HTTP pipeline policy
    for Azure SDK** requests and adds a custom HTTP header
    (x-ms-enable-preview: true) to every outgoing request. **Execute**
    it.

    ![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image34.png)

## Exercise 3: Save Blog Agent

1.  The next cell defines the **SavePlugin** class which implements a
    method to **save blog content** using **Azure AI Projects and the
    Semantic Kernel**.

    - It receives the **blog content** as input.

    - Interacts with **Azure AI Projects** to create an AI agent.

    - Generates and executes Python code to **save** the **content** as
      a **Markdown** (.md) file.

    - **Downloads** and **stores** the generated file locally.

    - **Returns** a **confirmation** message ("Saved").

    To execute this cell, replace **Your Connection String** with your
**Project Connection String** that you saved earlier to a note pad. It
can be accessed from the project overview page of Azure AI Foundry
portal.

    Click on **Execute** after replacing the connection string.

    ![](./media/image35.png)

    ![A screen shot of a computer AI-generated content may be incorrect.](./media/image36.png)

2.  The next cell initializes **constants** with Save specific values.
    **Execute** it. These constants will be used in the next cells.

    ![A screen shot of a computer AI-generated content may be
incorrect.](./media/image37.png)

3.  The next cell creates a **ChatCompletionAgent** named
    **save_blog_agent**. Execute it to create the agent.

    ![A computer screen shot of a computer program AI-generated content may
be incorrect.](./media/image38.png)

## Exercise 4: Writer agent

1.  Execute the next cell in the notebook which declares constants with
    Writer specific values.

    ![A screen shot of a computer AI-generated content may be
incorrect.](./media/image39.png)

2.  The next cell creates a **ChatCompletionAgent** named
    write-blog_content which will be responsible for writing a blog post
    using the Microsoft Semantic Kernel and Azure OpenAI chat models.
    Execute it to create the agent.

    ![A computer screen shot of a black screen AI-generated content may be
incorrect.](./media/image40.png)

3.  The code in the next cell makes **SavePlugin** available as a
    function inside **save_blog_agent**. It creates a **Kernel Plugin**
    from **SavePlugin.** **Adds** the Plugin to the **Agent's Kernel** .
    The AI calls the **SavePlugin.Save** function when it detects a
    save-related request.

    Execute it to create the Kernel Plugin.

    ![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image41.png)

4.  The next cell contains the code for the class
    **ApprovalTerminationStrategy**

5.  This **custom termination strategy** is used to determine **when an
    AI agent should stop running**. **Execute** it.

    ![A computer screen with text on it AI-generated content may be
incorrect.](./media/image42.png)

6.  The next cell contains the **AgentGroupChat** code. This creates a
    **multi-agent chat** system where two AI agents
    (**write_blog_agent** and **save_blog_agent**) collaborate. Uses
    **ApprovalTerminationStrategy** to determine when the chat should
    stop.

    Only **save_blog_agent** can approve termination.
    
    **Execute** it to configure the multi agent chat.

    ![A computer screen shot of a program AI-generated content may be
incorrect.](./media/image43.png)

7.  The next cell contains instructions to the agent. It **adds a user
    message to the multi-agent chat system**, instructing the AI to
    **search for information on GraphRAG, write a blog, and save it**.

    ![](./media/image44.png)

8.  **Execute** the next cell. This **iterates over the AI-generated
    responses** in the multi-agent chat **as they are streamed**.

    On execution, it writes a blog, saves it.

    ![A screen shot of a computer AI-generated content may be
incorrect.](./media/image45.png)

    ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image46.png)

    ![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

**Summary:**

We have implemented a Multi Agent system using Azure AI Agent Service
with Semantic Kernel.

