# 实验室 2：使用 Teams Toolkit为 Microsoft 365 Copilot 构建声明性代理

**预计时间：30 分钟**

## 目的

本实验室的目标是使参与者能够使用 Teams 工具包为 Microsoft 365 Copilot
构建声明性代理。完成实验后，参与者将创建一个地理定位游戏，为工作之余提供有趣且具有教育意义的休息时间。该实验室侧重于了解声明性代理的结构，使用说明对其进行配置，并将其集成到
Microsoft 365 生态系统中，以实现自定义的 Copilot 交互。

## 解决

参与者将在 Visual Studio Code 中安装 Teams
Toolkit并设置其开发环境。使用模板，他们将搭建名为 Geo Locator Game
的声明性代理的基架。他们将自定义代理的指令并更新其配置文件，例如
instruction.txt 和
manifest.json。该实验室还指导参与者使用唯一标识符、自定义图标和测试功能来增强代理。结果是一个功能齐全、引人入胜的
Copilot 应用程序，专为提供有关城市的线索而量身定制，同时与 Microsoft 365
无缝集成。

## 练习 1：设置 Microsoft 365 Copilot 的开发环境

### 任务 1：安装 Teams Toolkit

这些实验室基于 Teams 工具包版本
5.0。按照下面屏幕截图中所示的步骤进行作。

1.  打开 Visual Studio Code 并关闭 已打开的 **Appliances.csv**。

2.  在 Restricted Mode is intended 消息中，选择 **Manage**。

![](./media/image1.png)

3.  在 You are in Restricted mode 对话框中选择 **Trust**。

![](./media/image2.png)

4.  单击 Extensions 工具栏按钮。

![](./media/image3.png)

5.  搜索 +++**Teams**+++ 并找到 **Teams Toolkit **，然后单击
    **Install。**

![](./media/image4.png)

6.  安装完成后，**Teams Toolkit**图标将显示在左侧导航栏上。
    ![](./media/image5.png)

## 练习 2：第一个声明性代理

在本实验室中，您将使用适用于 Visual Studio Code 的 Teams
工具包构建一个简单的声明性代理。您的代理旨在通过帮助您探索全球城市，为您提供一个有趣且具有教育意义的工作休息时间。它为您提供抽象的线索供您猜测一个城市，您使用的线索越多，获得的分数就越少。最后，您的最终分数将揭晓。

在本练习中，您将学习:

- 什么是 Microsoft 365 Copilot 的声明性代理

- 使用 Teams 工具包模板创建声明性代理

- 使用说明自定义代理以创建 geo locator 游戏

- 了解如何运行和测试应用

- 对于奖励练习，您将需要一个 SharePoint 团队站点

**介绍**

声明式代理利用与 Microsoft 365 Copilot
相同的可扩展基础设施和平台，专为满足您特定领域的需求而量身定制。他们充当特定领域或业务需求的主题专家，允许您使用与标准
Microsoft 365 Copilot 聊天相同的界面，同时确保他们专注于手头的特定任务。

欢迎加入构建您自己的声明式代理！让我们潜入并让您的 Copilot 神奇工作！

在本实验中，你将开始使用 Teams
Toolkit和工具中使用的默认模板构建声明性代理。这是为了帮助您开始做某事。接下来，您将修改您的代理以专注于地理位置游戏。

您的 AI
的目标是提供一个有趣的工作休息时间，同时帮助您了解世界各地的不同城市。它为您提供了识别城市的抽象线索。您需要的线索越多，您获得的分数就越少。在游戏结束时，它将显示您的最终分数。

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image6.png)

您还将为您的代理提供一些文件以供参考、秘密日记 🕵🏽 和地图 🗺️
，以给玩家提供更多挑战。

那么，让我们开始吧

**声明式代理剖析**

随着我们开发越来越多的 Copilot 扩展，您将看到最终您将构建的是 zip
文件中的几个文件的集合，我们将其称为应用程序包，然后您将安装和使用。因此，请务必对应用包的组成有一个基本的了解。声明性代理的应用程序包类似于
Teams
应用程序（如果您之前使用其他元素构建了一个应用程序）。请参阅表格以查看所有核心元素。您还将看到应用程序部署过程与部署
Teams 应用程序非常相似。

[TABLE]

**注意：**您可以从 SharePoint、OneDrive、Web
搜索等添加参考数据，并向声明性代理（如插件和连接器）添加扩展功能。您将在此路径的后续实验中学习如何添加插件。

**Declarative 代理的功能**

您不仅可以添加说明，还可以指定代理应访问的知识库，从而增强代理对上下文和数据的关注。它们称为功能，支持三种类型的功能。

- **Microsoft Graph Connectors** - 将 Graph
  连接器的连接传递给代理，允许代理访问和利用连接器的知识。

- **OneDrive 和 SharePoint** - 向代理提供文件和网站的
  URL，以便代理访问这些内容。

- **Web search** - 启用或禁用作为代理知识库一部分的 Web 内容。

![](./media/image7.png)

**One Drive 和 SharePoint**

URL 应为 SharePoint
项（网站、文档库、文件夹或文件）的完整路径。您可以使用 SharePoint
中的“复制直接链接”选项来获取完整路径或文件和文件夹。为此，请右键单击文件或文件夹，然后选择
详细信息。导航到 路径 并单击 复制 图标。如果不指定
URL，代理将使用登录用户可用的整个 OneDrive 和 SharePoint 内容语料库。

**Microsoft Graph Connector**

如果不指定连接，代理将使用登录用户可用的整个 Graph 连接器内容语料库。

**Web search**

目前，您无法传递特定的网站或域，这仅用作打开和关闭使用 Web 的开关。

## 练习 3：从模板搭建声明性代理的基架

如果您知道上述应用程序包中文件的结构，则可以使用任何编辑器创建声明性代理。但是，如果您使用
Teams Toolkit
等工具不仅为您创建这些文件，还可以帮助您部署和发布应用程序，那么事情会变得更容易。因此，为了尽可能简化作，您将使用
Teams Toolkit。

### 任务 1：使用 Teams Toolkit创建声明性代理应用

1.  转到 Visual Studio Code 编辑器中的 Teams 工具包扩展，然后选择
    **“Create a New App”。**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

2.  此时会打开一个面板，您需要在其中选择 **Agent ** 从项目类型列表中。

![](./media/image9.png)

3.  接下来，系统会要求您选择 Copilot Agent 选择**declarative
    agent**的应用程序功能，然后按 **Enter**。

![](./media/image10.png)

4.  接下来，系统会要求您选择想要创建基本的声明式代理或带有 API
    插件的代理。选择 **No Plugin** 选项。

![](./media/image11.png)

5.  接下来，选择 **Default folder** 选项以指定必须创建项目文件夹的位置。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

6.  接下来，为其指定应用程序名称 +++**Geo Locator Game**+++，然后按
    Enter。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

该项目将在几秒钟内在您提到的文件夹中创建，并将在 Visual Studio Code
的新项目窗口中打开。这是您的工作文件夹。

7.  如果出现提示，请单击 **Yes， I trust the authors**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

> ![](./media/image15.png)

做得好！您已成功设置基础声明式代理！现在，继续检查其中包含的文件，以便对其进行自定义，从而制作地理定位器游戏应用。

### 任务 2：在 Teams Toolkit中设置帐户

1.  现在，从左侧窗格中选择 Teams Toolkit 图标。在“帐户”下，单击“登录
    Microsoft 365”并使用您的 **User1 credentials**。单击 Visual Studio
    Code 弹出窗口中的 Sign in 。

- 用户名 - <+++@lab.CloudPortalCredential>(User1).Username+++

- 密码 - <+++@lab.CloudPortalCredential>(User1).Password+++

![](./media/image16.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

2.  在 Security Alert 对话框中选择 **Allow access**。

![](./media/image18.png)

3.  登录后，浏览器将打开并显示一条消息“您You are signed in now and close
    this page”。请这样做。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

4.  验证 **Custom App Upload Enabled** 检查器是否带有绿色复选标记。

5.  验证 **Copilot Access Enabled** 检查器是否具有绿色复选标记。

![](./media/image20.png)

### 任务 3：了解应用程序中的文件

下面是基本项目的外观:

[TABLE]

1.  我们实验室感兴趣的文件主要是 **appPackage/instruction.txt**
    文件，这是您的代理所需的核心指令。它是一个纯文本文件，你可以在其中编写自然语言指令。

![](./media/image21.png)

2.  另一个重要文件是
    **appPackage/declarativeAgent.json**其中有一个架构，以使用新的声明性代理扩展
    Microsoft 365 Copilot。让我们看看此文件的架构具有哪些属性。

- $schema 是 schema 引用

- version 是架构版本

- name 键表示声明性代理的名称。

- description 提供描述。

- 指令是 **instructions.txt**
  文件的路径，该文件包含将确定作行为的指令。您还可以将说明作为纯文本作为值在此处放置。但对于本实验，我们将使用
  **instructions.txt** 文件。

![](./media/image22.png)

3.  另一个重要文件是 **appPackage/manifest.json**
    文件，其中包含关键元数据，包括包名称、开发人员姓名以及对应用程序使用的
    copilot 代理的引用。manifest.json
    文件中的以下部分说明了这些详细信息:

> "copilotAgents": {
>
> "declarativeAgents": \[
>
> {
>
> "id": "declarativeAgent",
>
> "file": "declarativeAgent.json"
>
> }
>
> \]
>
> },
>
> ![](./media/image23.png)

4.  您还可以更新 color.png 和 outline.png
    的徽标文件，使其与您的应用程序品牌相匹配。在今天的练习中，您将更改**color.png**图标以使代理脱颖而出。

## 练习 4：更新说明和图标

### 任务 1：更新图标和清单

1.  首先，我们将替换 logo。我们将用新的图像替换
    项目中的color.png图像。复制 **位于** C：\LabFiles
    中的图像**color.png**，并替换根项目 （路径应为
    **C：\Users\Student\TeamsApps\Geo Locator Game\appPackage**）
    的文件夹中的同名图像。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![](./media/image26.png)

2.  接下来，转到根项目中的文件 **appPackage/manifest.json** 并找到节点
    **copilotAgents**。将 declarativeAgents 数组的第一个条目的 id 值从
    declarativeAgent 更新为 +++dcGeolocator+++，以使此 ID 唯一。

> "copilotAgents": {
>
> "declarativeAgents": \[
>
> {
>
> "id": "dcGeolocator",
>
> "file": "declarativeAgent.json"
>
> }
>
> \]
>
> },
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image27.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

3.  接下来，转到文件 **appPackage/instruction txt**
    并复制粘贴以下指令以覆盖文件的现有内容。

> 系统角色：您是地理位置猜谜游戏的游戏主持人。您的目标是为玩家提供有关特定城市的线索，并引导他们完成游戏，直到他们猜出正确答案。如果玩家猜错了，您将逐步提供更详细的线索。您还将在特殊回合中引用
> PDF 文件，以创建巧妙且身临其境的游戏体验。
>
> 游戏玩法说明:
>
> Game Introduction Prompt
>
> 使用以下提示欢迎玩家并解释规则:
>
> 欢迎来到地理位置游戏！我会给你关于一个城市的线索，你的任务是猜出城市的名字。每次猜错后，我都会给你一个更详细的线索。您使用的提示数字愈少，您获得的分数就越多！让我们开始吧。这是你的第一个线索:
>
> Clue Progression Prompts
>
> 从模糊的线索开始，如果玩家猜错，则逐渐变得具体。使用以下结构:
>
> 线索 1：提供有关城市的一般地理线索（例如，大陆、气候、纬度/经度）。
>
> 线索 2：提供有关城市地标或自然特征的提示（例如，著名的纪念碑、河流）。
>
> 线索 3： 提供有关城市的历史或文化线索（例如，著名事件、文化意义）。
>
> 线索 4： 提供与城市美食、当地人或行业相关的特定线索。
>
> Response Handling
>
> 玩家猜测后，做出相应的回应：
>
> 如果玩家猜对了，请说：
>
> 没错！您已经在 \[数量线索\] 线索中猜中了城市，并获得了 \[分数\]
> 分。你想再玩一轮吗？
>
> 如果猜测错误，请说：
>
> Nice try! \[followed by more clues\]
>
> PDF-Based Scenario
>
> 对于特殊回合，请使用 PDF
> 文件提供来自历史文件、旅行者日记或古代地图的线索：
>
> 这一轮不同！我有一份秘密文件可以帮助我们。我会从这个
> \[历史地图/旅行者日记\]
> 中阅读线索，并指导你猜这个城市。这是第一个线索：
>
> 引用特定 PDF 以提取详细信息：
>
> 旅行者日记 PDF，历史地图 PDF。
>
> 必要时使用表情符号以保持友好的语气。
>
> Scorekeeping System
>
> 跟踪玩家使用的线索数量并计算分数:
>
> 1 clue: 10 points
>
> 2 clues: 8 points
>
> 3 clues: 5 points
>
> 4 clues: 3 points
>
> End of Game Prompt
>
> 在玩家猜出城市或用尽所有提示数字后，提示:
>
> 您想再玩一轮，尝试特殊挑战吗？

![](./media/image29.png)

4.  请注意 **appPackage/declarativeAgent.json 中的这一行**：

> "instructions": "$\[file('instruction.txt')\]",
>
> 这将从 **instruction.txt** 文件中引入您的说明
> 。如果要模块化打包文件，可以在 appPackage 文件夹中的任何 **JSON**
> 文件中使用此技术 。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

### 任务 2：添加对话启动器

您可以通过向声明式代理添加对话启动器来增强用户与声明式代理的互动。

拥有对话开场白的一些好处是:

- **参与度**：它们有助于发起交互，使用户感觉更舒适并鼓励参与。

- **上下文设置**：启动器设置对话的基调和主题，指导用户如何进行。

- **效率**：通过以明确的重点进行领导，发起人可以减少歧义，使对话顺利进行。

- **用户留存率**：精心设计的启动器保持用户的兴趣，鼓励与 AI 重复交互。

1.  declarativeAgent.json打开文件，然后在 instructions
    节点后添加逗号，按 Enter，然后粘贴以下代码。

> "conversation_starters": \[
>
> {
>
> "title": "Getting Started",
>
> "text":"I am ready to play the Geo Location Game! Give me a city to
> guess, and start with the first clue."
>
> },
>
> {
>
> "title": "Ready for a Challenge",
>
> "text": "Let us try something different. Can we play a round using the
> travelers diary?"
>
> },
>
> {
>
> "title": "Feeling More Adventurous",
>
> "text": "I am in the mood for a challenge! Can we play the game using
> the historical map? I want to see if I can figure out the city from
> those ancient clues."
>
> }
>
> \]
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image31.png)

现在，对代理完成所有更改，是时候对其进行测试了。

2.  前往 **Files** 从顶部栏，然后单击 **Save All.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

### 任务 3：测试应用程序

1.  若要测试应用，请转到 Visual Studio Code 中的 Teams
    工具包扩展。这将打开左侧窗格。在“**LIFECYCLE**”下，选择“**Provision**”。您可以在此处看到
    Teams Toolkit 的价值，因为它使发布变得如此简单。

![](./media/image33.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

2.  如果出现提示，请使用您的凭据登录。

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image35.png)

3.  在此步骤中，Teams 工具包会将 appPackage 文件夹中的所有文件打包为 zip
    文件，并将声明性代理安装到您自己的应用程序目录中。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

5.  一旦您收到一条消息，指出 **5/5 actions in provision stage
    successfully executed** that 该过程即完成。

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image37.png)

6.  从浏览器导航到
    +++[https://teams.microsoft.com/v2/+++](https://teams.microsoft.com/v2/+++%C2%A0from)，并在出现提示时登录到您的租户。新应用程序将自动固定在您的聊天上方。只需打开
    Teams，选择“聊天”，您就会看到 **Copilot**。选择它。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

\[！警报\] 如果您收到一条消息，指出 Copilot
目前在此区域不可用，请使用此链接
+++<https://m365.cloud.microsoft/chat/+++>
并按照相同的步骤测试应用程序。

7.  加载 Copilot 应用程序后，从右侧面板找到 +++Geo Locator
    Game+++，如图所示。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

如果您找不到，这可能是一个很长的列表，您可以通过选择 “see more”
来扩展列表来找到您的代理

8.  启动后，您将进入此与代理的重点聊天窗口。您将看到下面标记的对话启动器：

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

9.  选择其中一个对话启动器，它将用启动器提示填充您的撰写消息框，等待您按“Enter”。它仍然只是您的助手，将等待您采取行动。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

10. 尝试回答问题并探索您开发的游戏。

## 总结

在本实验室中，我们学习了如何使用 Teams
工具包构建声明性代理并测试代理的功能。
