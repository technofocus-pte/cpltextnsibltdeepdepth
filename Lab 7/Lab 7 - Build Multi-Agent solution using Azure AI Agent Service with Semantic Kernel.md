# 实验 7 - 使用带有Semantic Kernel的 Azure AI 代理服务构建多代理解决方案

我们可以通过 Azure AI 代理服务构建面向企业的 AI 代理。

**介绍**

下面介绍一个博客写作场景。此方案涉及两个 AI
代理：一个用于编写帮助，另一个用于内容存储和管理。这些代理可以使用
AutoGen 或 Semantic Kernel 无缝编排。在本实验中，我们将使用 Semantic
Kernel Orchestration。

![A diagram of a diagram of a business AI-generated content may be
incorrect.](./media/image1.png)

## 目的:

使用 Azure AI Foundry SDK，开发人员可以使用 Python 或 C# 基于 Azure AI
代理服务快速构建代理。企业会根据其业务拥有不同的 AI Agent，那么这些 AI
Agent 应该如何在工作流中组合呢？我们需要使用 AutoGen 或 Semantic Kernel
来编排 AI 代理。在本实验中，我们使用语义内核通过 Azure AI
代理服务开发多代理解决方案。

## 练习 1：创建 Azure AI Hub 资源和项目

在本练习中，我们将在 Azure 门户中创建中心，然后在 Azure AI Foundry
中创建一个项目，部署模型并创建执行所需的代理。

1.  在浏览器中，打开
    +++\*\*<https://portal.azure.com/**+++>，然后使用**login** **credentials** 登录，然后从**主页**中选择
    **Azure AI Foundry**。

    - 用户名 – <+++@lab.CloudPortalCredential>(User1).Username+++

    - 密码 – <+++@lab.CloudPortalCredential>(User1).Password+++

![image](./media/image2.png)

2.  选择 **Use with AI Foundry** -\> **AI Hubs**。选择 **+
    Create -\> Hub**。

![image](./media/image3.png)

3.  输入以下详细信息，接受其他默认值，然后选择 **Review + create**。

    - 订阅 - 选择**已分配的订阅**

    - 资源组 - 选择已分配的资源组 （**ResourceGroup1**）

    &nbsp;

    - 区域 - 选择 @lab.CloudResourceGroup(ResourceGroup1).Location

    - 名字 - <+++hub@lab.LabInstance.Id>+++

![image](./media/image4.png)

![image](./media/image5.png)

4.  验证通过后，选择 **Create** 。

![image](./media/image6.png)

5.  部署完成后，单击 **Go to resource**。

![image](./media/image7.png)

6.  从中心资源页中选择“**Launch Azure AI Foundry**”。

![image](./media/image8.png)

7.  从启动的中心资源中，向下滚动并选择 **+ New project**。

![image](./media/image9.png)

![image](./media/image10.png)

8.  将名称输入为 <+++multiagent@lab.LabInstance.Id>+++，然后选择
    **Create**。

![image](./media/image11.png)

9.  **Close** Explore and experiment 弹出窗口。

![image](./media/image12.png)

10. 您将进入创建的项目页面。

![image](./media/image13.png)

11. 向下滚动页面，并将 **Project connection string** 的值复制到记事本。

![image](./media/image14.png)

12. 在左侧窗格中向下滚动，然后选择**Management center**。

![image](./media/image15.png)

13. 在“Hub resource”下选择“**Connected resources** ”，然后单击“+ **New
    connection** ”以创建与 Azure AI Foundry 资源的连接。 

![image](./media/image16.png)

14. 从可用的外部资产中选择 **Azure AI Foundry**。

![image](./media/image17.png)

15. 选择 **Add connection** 以添加连接。

![image](./media/image18.png)

![image](./media/image19.png)

16. 连接后，单击 **Close**。如果 **Close**
    按钮不可见，请减小浏览器的**zoom size **，然后选择 **Close**。

![image](./media/image20.png)

17. 从 左侧窗格中选择 **Go to project**。

![image](./media/image21.png)

18. 在项目页面中，复制 **API Key** 和 **Azure OpenAI
    endpoint** 的值，并将其保存到记事本中。

![image](./media/image22.png)

19. 在左侧窗格中的 **Build and customize**下选择 **Agents**。在 **Azure
    AI Agent Service** 页面中，选择已创建的 **Azure OpenAI
    Service** ，然后单击 “**Let’s go**”。 

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

20. 选择 **gpt-4o-mini**，然后单击 **Confirm**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

21. 接受部署名称为 +++**gpt-4o-mini**+++，选择 Deployment type 为
    **Standard**。接受其他默认值，然后单击 **Deploy** 以部署模型。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

22. 现在，我们已经准备好了 Azure 资源。

## 练习 2：多代理编排

在本练习中，我们将设置 Visual Studio Code 并安装执行所需的先决条件。

1.  在 VM 中，打开 **Visual Studio Code**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

2.  选择**File -\> Open Folder，**然后从 **C：\LabFiles** 中选择文件夹
    **MultiAgent**，然后单击**Select Folder。**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

3.  在弹出窗口中选择 **Yes， I trust the authors**。

![A screenshot of a computer error AI-generated content may be
incorrect.](./media/image30.png)

4.  右键单击笔记本并选择 **Open in Integrated Terminal**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

5.  依次执行以下命令以添加 **nuget source**。

+++dotnet nuget list source+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

> +++dotnet nuget add
> source <https://api.nuget.org/v3/index.json> --name nuget.org+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  执行以下命令以安装 dotnet interacrive。

+++dotnet tool install --global Microsoft.dotnet-interactive --version
1.0.556801+++

![](./media/image34.png)

7.  执行 +++pip install jupyter+++ 安装 Jupyter。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image35.png)

8.  执行下一个命令以使用 jupyter interactive。

+++dotnet interactive jupyter install+++

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image36.png)

9.  **关闭Terminal**。从 **Visual Studio Code** 的左窗格中选择
    **Extensions** 。搜索并选择 +++**Jupyter**+++，然后单击 **Install**
    安装 以安装 **Jupyter** 扩展。 

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

10. **Close** Visual Studio Code，然后再次**open**它。

11. 打开笔记本 **AzureAIMultiAgentWithSK.ipynb**。打开后，单击 **Select
    Kernel**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

12. 选择 **Jupyter Kernel**。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image39.png)

13. 在 下一组选项中选择 .**NET （C#） dotnet**。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image40.png)

14. 在**Security Alert**中选择 **Allow access**。

![A screenshot of a computer security alert AI-generated content may be
incorrect.](./media/image41.png)

15. 执行第一个单元以**install **所有必需的** packages**。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image42.png)

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image43.png)

16. 执行下一个单元以导入命名空间。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image44.png)

17. 在下一个单元格中，验证 **deployment** 变量值是否与您创建的 **model
    deployment** 相同。取代,

    1.  Endpoint – **Azure OpenAI Endpoint**

    2.  Key – The **API Key**

在 Azure AI Foundry 中创建项目后，我们之前将上述两个值保存在记事本中。

替换值后，**execute**单元格。

这会将这些值设置为要进一步使用的相应变量。

![A black screen with numbers AI-generated content may be
incorrect.](./media/image45.png)

18. 下一个单元创建一个新的 **KernelBuilder** 实例，将 **Azure OpenAI
    Chat Completion**作为 AI
    服务提供商添加到内核中，并将上一步中的变量作为输入，然后调用
    **Build**（） 创建 Kernel 实例。

**Execute **它以创建 Kernel 实例。

![A screen shot of a computer code AI-generated content may be
incorrect.](./media/image46.png)

19. 执行下一个单元以安装所需的 **Azure**
    包，并执行下一个单元以导入引用。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image47.png)

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image48.png)

20. 下一个单元格中的类为 **custom HTTP pipeline policy for Azure
    SDK** ，并将自定义 HTTP 标头 （x-ms-enable-preview： true）
    添加到每个传出请求。**Execute**它。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image49.png)

## 练习 3：保存博客代理

1.  下一个单元格定义了 **SavePlugin** 类，该类实现了使用 **Azure AI
    Projects and the Semantic Kernel save blog content** 的方法。 

    - 它接收 blog content作为输入。

    - 与 **Azure AI Projects** 交互以创建 AI 代理。

    - 生成并执行 Python 代码以 **将**内容**另存**为 **Markdown** （.md）
      文件。

    - **Download**并**存储在**本地生成的文件。

    &nbsp;

    - **返回确认消息 （“Saved”）。**

要执行此单元格，请将 **Your Connection String**
替换为您之前保存到记事本的 **Project Connection String**。可以从 Azure
AI Foundry 门户的项目概述页访问它。

替换连接字符串后单击 **Execute**。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image50.png)

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image51.png)

2.  下一个单元格使用 Save specific values
    初始化**Constants**。**Execute**它。这些常量将在下一个单元格中使用。

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image52.png)

3.  下一个单元格将创建一个 名为 **save_blog_agent** 的
    **ChatCompletionAgent**。执行它以创建代理。

![A computer screen shot of a computer program AI-generated content may
be incorrect.](./media/image53.png)

## 练习 4：编写器代理

1.  执行笔记本中的下一个单元格，该单元格使用 Writer 特定值声明常量。

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image54.png)

2.  下一个单元格创建一个名为 write-blog_content 的
    **ChatCompletionAgent**，它将负责使用 Microsoft 语义内核和 Azure
    OpenAI 聊天模型编写博客文章。执行它以创建代理。

![A computer screen shot of a black screen AI-generated content may be
incorrect.](./media/image55.png)

3.  下一个单元格中的代码使 **SavePlugin** 可用作 save_blog_agent
    中的函数。它 从 **SavePlugin** 创建一个 **Kernel
    Plugin。**将插件添加到代理的 **kernel** 中。AI
    在检测到与保存相关的请求时调用 **SavePlugin.Save** 函数。

执行它以创建 Kernel Plugin。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image56.png)

4.  下一个单元格包含类 **ApprovalTerminationStrategy 的代码**

5.  此自**custom termination strategy** 用于确定 **when an AI agent
    should stop running**。**Execute**它。 

![A computer screen with text on it AI-generated content may be
incorrect.](./media/image57.png)

6.  下一个单元格包含 **AgentGroupChat**
    代码。这将创建一个多**multi-agent chat** 系统，其中两个 AI
    代理（**write_blog_agent** 和 **save_blog_agent**）协作。使用
    **ApprovalTerminationStrategy** 确定聊天应何时停止。

只有**save_blog_agent**可以批准终止。

**Execute**它以配置多代理聊天。

![A computer screen shot of a program AI-generated content may be
incorrect.](./media/image58.png)

7.  下一个单元格包含对代理的指令。它**adds a user message to the
    multi-agent chat system**，指示 **search for information on
    GraphRAG, write a blog, and save it**。, instructing

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image59.png)

8.  **Execute**下一个单元格。这将在流式传输时多代理聊天中 **iterates
    over the AI-generated responses**。 

在执行时，它会编写一个博客，并保存它。

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image60.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

## 总结

我们使用带有Semantic Kernel的 Azure AI 代理服务实现了多代理系统。
