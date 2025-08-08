# 实验 6 - 使用 Azure OpenAI 和语义内核 SDK 开发 Contoso AI 旅行助理代理

**预计时间：40 分钟**

## 目的

在本实验中，参与者将使用 Azure OpenAI 和语义内核 SDK 为 Contoso 构建 AI
支持的旅行代理。目标是演示如何利用 AI
技术创建能够理解用户查询、提供旅行推荐以及执行预订航班、酒店和管理行程等任务的对话代理。在实验结束时，参与者将获得将
AI 模型与实际应用程序集成、利用 Semantic Kernel SDK
增强旅行社能力以及在模拟环境中测试旅行社绩效的实践经验。

## 解决方案重点领域

该实验室专注于使用 Azure OpenAI 和 Semantic Kernel SDK构建 AI
驱动的旅行代理。它支持自然语言处理 （NLP）
来处理与旅行计划相关的用户查询，例如预订航班、住宿和提供旅行推荐。

该实验室强调创建一个对话式 AI
界面，以便与用户互动、回答问题并协助完成与旅行相关的任务。它使用
Semantic Kernel SDK 编排行程管理等任务，并集成用于实时旅行数据的 API。

该解决方案旨在通过提供个性化和响应式的旅行帮助来增强用户体验。它可以自动执行常见的差旅任务，以优化工作流程并简化差旅计划流程。

## 练习 1：了解 VM 和凭据

在本练习中，我们将识别并了解我们将在整个实验室中使用的凭证。

1.  **“Instructions **选项卡包含实验室指南，其中包含在整个实验室中要遵循的说明。

2.  **Resources** 选项卡已获取执行实验室所需的凭证。

    - **URL** – Azure 门户的 URL

    - **Subscription** – 这是 分配给你的**subscription**的 ID

    - **Username** – **login** **Azure services**时需要使用的 **user
      id** 。

    - **Password** – **Azure logi**名的**Password**。 

让我们将此用户名和密码称为 **Azure login credentials**。我们将在提及
**Azure login credentials**的任何地方使用这些凭据。

- **Resource Group** – 分配给您的**Resource group** 。

\[！Alert\] **重要提示**：请确保在此资源组下创建所有资源

![A screenshot of a computer Description automatically
generated](./media/image1.png)

3.  **Help** 选项卡包含 Support 信息。此处的 **ID** 值是
    将在实验室执行期间使用的 **Lab instance ID** 。

![A screenshot of a computer Description automatically
generated](./media/image2.png)

## 练习 2：创建 Azure OpenAI 资源和模型部署

1.  使用 Azure 登录凭据+++\*\*,

    - 用户名 - <+++@lab.CloudPortalCredential>(User1).Username+++

    - 密码 - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image3.png)

2.  从搜索栏中搜索 +++**Azure OpenAI**+++ 并选择它。

![A screenshot of a computer Description automatically
generated](./media/image4.png)

3.  选择 **+ Create**。

![A screenshot of a computer Description automatically
generated](./media/image5.png)

4.  在 **Basics** 选项卡中填写以下详细信息，然后选择 **Next**。

    - 订阅 – 选择您分配的**subscription**

    &nbsp;

    - Resource group （资源组） – 选择 分配给您的 Resource group

    &nbsp;

    - 地区 – @lab.CloudResourceGroup(ResourceGroup1).Location

    - 名字 –
      +++[**AOAI@lab.LabInstance.Id**](mailto:AOAI@lab.LabInstance.Id)+++

    - 定价层 – **Standard**

![A screenshot of a computer Description automatically
generated](./media/image6.png)

5.  接受 **Network** 和 **Tags** 页面中的默认值，然后单击 **Review +
    submit** 页面中的 Create。

![A screenshot of a computer Description automatically
generated](./media/image7.png)

6.  创建后，单击 **Go to resource** 并选择 您现在创建的 **Azure
    OpenAI**。

![A screenshot of a computer Description automatically
generated](./media/image8.png)

7.  在 **Resource Management** 下选择 **Keys and Endpoint**。将 **Key
    1** 和 **Endpoint** 值复制到记事本，以备将来在此实验中使用。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

8.  在 Azure OpenAI 资源的**“Overview**”页中，选择“**Go to Azure AI
    Foundry portal**”。

![A screenshot of a computer Description automatically
generated](./media/image10.png)

9.  从左侧窗格中，选择 **Deployments**。

![A screenshot of a computer Description automatically
generated](./media/image11.png)

10. 选择 **+ Deploy model** -\> **Deploy base model**

![A screenshot of a computer Description automatically
generated](./media/image12.png)

11. 搜索并选择 +++**gpt-35-turbo**+++。单击 **Confirm**。

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image13.png)

12. 接受默认值并选择 **Deploy**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

## 练习 3：使用 Azure OpenAI 服务设置 AI Travel Agent 项目

在本练习中，您将在 Visual Studio Code 中设置项目文件夹，并将其配置为与
Azure OpenAI 服务集成。通过执行这些步骤，您将学习如何使用 Azure OpenAI
部署详细信息设置本地开发环境、修改项目文件以及准备应用程序以执行。

1.  从 Windows 搜索栏中搜索 +++Command Prompt+++，然后打开**Command
    prompt**。

![A screenshot of a computer Description automatically
generated](./media/image15.png)

2.  逐个执行以下命令。

+++dotnet nuget list source+++

+++dotnet nuget add source <https://api.nuget.org/v3/index.json> --name
nuget.org+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

3.  打开固定到 Windows 任务栏的 **Visual Studio Code**。选择 **File**
    -\> **Open folder**。

![A screenshot of a computer Description automatically
generated](./media/image17.png)

4.  导航到 **C：\LabFiles** 并选择 **AITravelAgent** 文件夹，然后单击
    **Select Folder**。该文件夹将在 VS Code 中打开。

![A screenshot of a computer Description automatically
generated](./media/image18.png)

5.  选择 **Do you want to trust the authors of the files in this
    folder？**

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image19.png)

6.  在 Explorer 窗格中，导航到 **AITravelAgent/Starter**
    文件夹。右键单击该文件夹，然后选择 **Open in Integrated Terminal**。

![A screenshot of a computer Description automatically
generated](./media/image20.png)

7.  在 Explorer 面板中，展开 Starter 文件夹，您应该会看到 Plugins
    文件夹、Prompts 文件夹和 Program.cs 文件。

![A screenshot of a computer Description automatically
generated](./media/image21.png)

8.  打开 Starter/Program.cs 文件，并使用 Azure OpenAI 服务部署名称、API
    密钥和终结点更新以下变量。进行更改后，按 Ctrl + S 保存文件:

> string yourDeploymentName = +++**gpt-35-turbo**+++
>
> string yourEndpoint = The Azure OpenAI resource Endpoint value we
> saved earlier
>
> string yourKey = The Key1 of the AOAI resource that we saved earlier

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image22.png)

## 练习 4：使用 Semantic Kernel 创建和测试 Currency Converter 插件

在本练习中，您将使用 Semantic Kernel
创建一个货币转换器插件。您将编写和测试一个函数，该函数使用预定义的汇率将金额从一种货币转换为另一种货币。本练习将帮助您了解如何构建和调用自定义插件，利用装饰器实现功能和描述，以及如何将插件集成到更大的应用程序中。

1.  在 **Stater/Plugins/ConvertCurrency** 文件夹中创建一个名为
    +++CurrencyConverter.cs+++ 的新文件

![A screenshot of a computer Description automatically
generated](./media/image23.png)

2.  在 CurrencyConverter.cs 文件中，添加以下代码以创建插件函数

> using Microsoft.SemanticKernel;
>
> using System.ComponentModel;
>
> using AITravelAgent;
>
> class CurrencyConverter
>
> {
>
> \[KernelFunction,
>
> Description("Convert an amount from one currency to another")\]
>
> public static string ConvertAmount(
>
> {
>
> var currencyDictionary = Currency.Currencies;
>
> }
>
> }

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

在此代码中，您将使用 KernelFunction
装饰器来声明您的原生函数。您还可以使用 Description
修饰器添加函数功能的描述。您可以使用 Currency.Currencies
获取货币及其汇率的字典。接下来，添加一些逻辑以将给定金额从一种货币转换为另一种货币。

3.  修改 ConvertAmount 函数。将现有代码替换为以下代码。

> using Microsoft.SemanticKernel;
>
> using System.ComponentModel;
>
> using AITravelAgent;
>
> class CurrencyConverter
>
> {
>
> \[KernelFunction, Description(@"Converts an amount from one currency
> to another
>
> and returns a friendly message with the results")\]
>
> public static string ConvertAmount(
>
> \[Description("The starting currency code")\] string baseCurrencyCode,
>
> \[Description("The target currency code")\] string targetCurrencyCode,
>
> \[Description("The amount to convert")\] string amount)
>
> {
>
> var currencyDictionary = Currency.Currencies;
>
> Currency targetCurrency = currencyDictionary\[targetCurrencyCode\];
>
> Currency baseCurrency = currencyDictionary\[baseCurrencyCode\];
>
> if (targetCurrency == null)
>
> {
>
> return targetCurrencyCode + " was not found";
>
> }
>
> else if (baseCurrency == null)
>
> {
>
> return baseCurrencyCode + " was not found";
>
> }
>
> else
>
> {
>
> double amountInUSD = Double.Parse(amount) \* baseCurrency.USDPerUnit;
>
> double result = amountInUSD \* targetCurrency.UnitsPerUSD;
>
> return $"${amount} {baseCurrencyCode} is approximately
> {result.ToString("C")} in {targetCurrency.Name}s
> ({targetCurrencyCode})";
>
> }
>
> }
>
> }

在此代码中，您使用 Currency.Currencies 字典获取目标货币和基础货币的
Currency 对象。然后，使用 Currency
对象将金额从基础货币转换为目标货币。最后，您返回一个包含转换金额的字符串。接下来，让我们测试您的插件。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image25.png)

\[!Note\] **注意：**在您自己的项目中使用 Semantic Kernel SDK
时，如果您可以访问 RESTful
API，则无需将数据硬编码为文件。相反，您可以使用 Plugins.Core.HttpClient
插件从 API 检索数据。

4.  在 Starter/Program.cs
    文件中，使用以下代码导入并调用您的新插件函数。（删除 var kernel =
    builder 下面的代码。构建（）;并将其替换为给定的以下代码。)

> kernel.ImportPluginFromType\<CurrencyConverter\>();
>
> kernel.ImportPluginFromType\<ConversationSummaryPlugin\>();
>
> var prompts = kernel.ImportPluginFromPromptDirectory("Prompts");
>
> var result = await kernel.InvokeAsync("CurrencyConverter",
>
> "ConvertAmount",
>
> new() {
>
> {"targetCurrencyCode", "USD"},
>
> {"amount", "52000"},
>
> {"baseCurrencyCode", "VND"}
>
> }
>
> );
>
> Console.WriteLine(result);

在此代码中，您将使用 ImportPluginFromType 方法导入您的插件。然后，使用
InvokeAsync 方法调用插件函数。InvokeAsync
方法采用插件名称、函数名称和参数字典。最后，将结果打印到控制台。接下来，运行代码以确保其正常工作。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

5.  前往 **File** 从顶部栏并选择 **Save all.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

6.  在终端中，输入 +++**dotnet run**+++。您应该会看到以下输出:

**Output:** $52000 VND is approximately $2.13 in US Dollars (USD)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

现在你的插件已经正常工作了，让我们创建一个自然语言提示，它可以检测用户想要转换的货币和金额。

## 练习 5：配置用于语义处理的目标货币提示

在本练习中，您将配置一个提示系统，以从用户输入中识别目标货币、基础货币和金额。通过创建和设置配置和提示文件，您将定义
AI 如何解释和处理货币转换的自然语言请求。

1.  在 Visual Studio Code 中，找到 **Starter/Prompts**
    文件夹。导航到此文件夹以准备后续步骤。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

2.  在 **Starter/Prompts** 文件夹中，创建一个名为
    +++**GetTargetCurrencies**+++
    的新文件夹。此文件夹将包含与此练习相关的所有文件。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

3.  在 **GetTargetCurrencies** 文件夹中，创建一个名为
    +++**config.json**+++ 的新文件。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

4.  在 Visual Studio Code 中打开新创建的 **config.json**
    文件。将以下代码复制并粘贴到文件中。

> {
>
> "schema": 1,
>
> "type": "completion",
>
> "description": "Identify the target currency, base currency, and
> amount to convert",
>
> "execution_settings": {
>
> "default": {
>
> "max_tokens": 800,
>
> "temperature": 0
>
> }
>
> },
>
> "input_variables": \[
>
> {
>
> "name": "input",
>
> "description": "Text describing some currency amount to convert",
>
> "required": true
>
> }
>
> \]
>
> }

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

按 **Ctrl + S** 保存文件。此配置定义 AI 系统应如何解释和处理用户输入。

5.  在 **Prompts folder 下** ，创建另一个名为 +++**skprompt.txt**+++
    的新文件。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  在文本编辑器中打开 **skprompt.txt** 文件并粘贴以下内容:

> \<message role="system"\>Identify the target currency, base currency,
> and
>
> amount from the user's input in the format
> target|base|amount\</message\>
>
> For example:
>
> \<message role="user"\>How much in GBP is 750.000 VND?\</message\>
>
> \<message role="assistant"\>GBP|VND|750000\</message\>
>
> \<message role="user"\>How much is 60 USD in New Zealand
> Dollars?\</message\>
>
> \<message role="assistant"\>NZD|USD|60\</message\>
>
> \<message role="user"\>How many Korean Won is 33,000 yen?\</message\>
>
> \<message role="assistant"\>KRW|JPY|33000\</message\>
>
> \<message role="user"\>{{$input}}\</message\>
>
> \<message role="assistant"\>target|base|amount\</message\>

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

按 **Ctrl + S** 保存文件。此脚本定义用于处理货币换算请求的提示逻辑。

## 练习 6：配置差旅活动建议的提示系统

在本练习中，您将设置和自定义一个提示系统，以根据用户的旅行目的地建议活动和兴趣点。通过编辑配置和提示文件，您将定义系统的行为、语气和输入要求，以生成个性化和创造性的旅行推荐。

1.  在 Visual Studio Code 中，导航到文件夹
    **Starter/Prompts/SuggestActivities**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

2.  在 **SuggestActivities** 文件夹中找到 **config.json**
    文件并将其打开。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

3.  将 **config.json** 文件中的现有代码替换为以下内容:

> {
>
> "schema": 1,
>
> "type": "completion",
>
> "description": "Suggest activities and points of interest at a given
> destination",
>
> "execution_settings": {
>
> "default": {
>
> "max_tokens": 4000,
>
> "temperature": 0.5
>
> }
>
> },
>
> "input_variables": \[
>
> {
>
> "name": "history",
>
> "description": "Some background information about the user",
>
> "required": false
>
> },
>
> {
>
> "name": "destination",
>
> "description": "The destination a user wants to visit",
>
> "required": true
>
> }
>
> \]
>
> }

![A screenshot of a computer code AI-generated content may be
incorrect.](./media/image37.png)

按 **Ctrl + S**
进行更改后保存文件。此文件将系统配置为处理用户输入并生成活动建议。

4.  留在 SuggestActivities 文件夹中并找到 **skprompt.txt**
    文件。在编辑器中打开此文件。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

5.  将 **skprompt.txt** 的现有内容替换为 以下文本：

> You are an experienced travel agent.
>
> You are helpful, creative, and very friendly.
>
> Consider the traveler's background: {{$history}}
>
> The traveler would like some activity recommendations for their trip
> to {{$destination}}.
>
> Please suggest a list of things to do, see, and points of interest.

![A screenshot of a computer code AI-generated content may be
incorrect.](./media/image39.png)

按 **Ctrl + S** 保存文件。此脚本在生成活动推荐时设置系统的行为和基调。

## 练习 7：为 AI 工作流配置主程序

在本练习中，您将配置主 Program.cs 文件以与 Azure OpenAI 服务和 Microsoft
语义内核集成。通过自定义代码，您将启用货币换算、活动建议和旅行推荐等功能。此设置利用插件和基于提示的逻辑，为用户交互和意图识别建立了一个强大的
AI 驱动的工作流程。

1.  从 Visual Studio Code 中的项目中，导航到 **Starter/Program.cs**
    文件并打开它进行编辑。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  将 **Program.cs** 文件的全部内容替换为 以下代码，然后按 **cntrl +
    S** 保存代码。

\[!Note\] **注意：**替换代码后，请将 endpoint 和 Key
的占位符替换为其值。

using System.Text;

using Microsoft.SemanticKernel;

using Microsoft.SemanticKernel.ChatCompletion;

using Microsoft.SemanticKernel.Connectors.OpenAI;

using Microsoft.SemanticKernel.Plugins.Core;

\#pragma warning disable SKEXP0050

\#pragma warning disable SKEXP0060

string yourDeploymentName = "gpt-35-turbo";

string yourEndpoint = "EndPoint";

string yourApiKey = "API Key";

var builder = Kernel.CreateBuilder();

builder.Services.AddAzureOpenAIChatCompletion(

yourDeploymentName,

yourEndpoint,

yourApiKey,

"gpt-35-turbo");

var kernel = builder.Build();

kernel.ImportPluginFromType\<CurrencyConverter\>();

kernel.ImportPluginFromType\<ConversationSummaryPlugin\>();

var prompts = kernel.ImportPluginFromPromptDirectory("Prompts");

// Note: ChatHistory isn't working correctly as of SemanticKernel v
1.4.0

StringBuilder chatHistory = new();

OpenAIPromptExecutionSettings settings = new()

{

ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions

};

string input;

do {

Console.WriteLine("What would you like to do?");

input = Console.ReadLine()!;

var intent = await kernel.InvokeAsync\<string\>(

prompts\["GetIntent"\],

new() {{ "input", input }}

);

switch (intent) {

case "ConvertCurrency":

var currencyText = await kernel.InvokeAsync\<string\>(

prompts\["GetTargetCurrencies"\],

new() {{ "input", input }}

);

var currencyInfo = currencyText!.Split("|");

var result = await kernel.InvokeAsync("CurrencyConverter",

"ConvertAmount",

new() {

{"targetCurrencyCode", currencyInfo\[0\]},

{"baseCurrencyCode", currencyInfo\[1\]},

{"amount", currencyInfo\[2\]},

}

);

Console.WriteLine(result);

break;

case "SuggestDestinations":

chatHistory.AppendLine("User:" + input);

var recommendations = await kernel.InvokePromptAsync(input!);

Console.WriteLine(recommendations);

break;

case "SuggestActivities":

var chatSummary = await kernel.InvokeAsync(

"ConversationSummaryPlugin",

"SummarizeConversation",

new() {{ "input", chatHistory.ToString() }});

var activities = await kernel.InvokePromptAsync(

input!,

new () {

{"input", input},

{"history", chatSummary},

{"ToolCallBehavior", ToolCallBehavior.AutoInvokeKernelFunctions}

});

chatHistory.AppendLine("User:" + input);

chatHistory.AppendLine("Assistant:" + activities.ToString());

Console.WriteLine(activities);

break;

case "HelpfulPhrases":

case "Translate":

var autoInvokeResult = await kernel.InvokePromptAsync(input,
new(settings));

Console.WriteLine(autoInvokeResult);

break;

default:

Console.WriteLine("Sure, I can help with that.");

var otherIntentResult = await kernel.InvokePromptAsync(input);

Console.WriteLine(otherIntentResult);

break;

}

}

while (!string.IsNullOrWhiteSpace(input));

该程序首先导入基本命名空间，例如用于文本处理的 System.Text 和用于 AI
驱动的对话工作流的 Microsoft.SemanticKernel。它通过
Microsoft.SemanticKernel.Connectors.OpenAI 命名空间集成 Microsoft Azure
OpenAI 服务，允许与 GPT 模型 （gpt-35-turbo） 通信。配置涉及设置
yourDeploymentName、yourEndpoint 和 yourApiKey
等变量，以进行身份验证并连接到 Azure OpenAI 终结点。

Semantic Kernel 使用 builder 模式进行初始化。导入其他功能的插件，例如
CurrencyConverter 和 ConversationSummaryPlugin。此外，存储在目录
（Prompts） 中的提示是动态加载的，以方便 intent 识别和任务执行。

程序的主循环通过请求输入并使用 GetIntent
提示确定意图来与用户交互。根据意图，程序分支为不同的功能:

1.  **货币换算**：如果目的是换算货币，则程序将使用 GetTargetCurrencies
    提示提取详细信息（目标货币、基础货币和金额）。然后，它调用
    CurrencyConverter 插件的 ConvertAmount 方法并显示结果。

2.  **目的地建议**：如果目的是建议目的地，则程序使用语义内核的
    InvokePromptAsync 方法根据用户输入提供建议。

3.  **活动建议**：此功能通过 ConversationSummaryPlugin
    利用对话摘要来提供与上下文相关的活动建议。对话历史记录使用
    StringBuilder 对象进行维护，以实现连续的对话流。

4.  **有用的短语和翻译**：对于“HelpfulPhrases”或“Translate”等
    intent，内核会根据输入和设置自动调用相关函数。

其他用户意图通常通过调用提示系统来处理，从而确保响应的灵活性。交互循环将继续，直到用户不提供任何输入（空字符串）。

## 练习 8：测试应用程序

在本练习中，您将通过运行货币换算、目标建议和活动建议的查询来测试应用程序的功能。这将确保您的
AI 驱动的系统按预期工作，并提供准确、上下文相关的输出。

**测试步骤**

1.  **运行应用程序**

    - 右键单击 Starter 文件夹并选择 **Open in Integrated Terminal**。

    &nbsp;

    - 在终端中，输入以下命令以执行应用程序:

+++dotnet run+++

1.  **测试货币换算**

    - 出现提示时 **What would you want to do？**
      输入货币兑换查询，如下所示+++**How much is 60 USD in New Zealand
      dollars?**+++

    &nbsp;

    - 预期输出t:  
      **$60 USD is approximately $97.88 in New Zealand Dollars (NZD)**

2.  **测试目标建议**

    - 输入目标建议的查询，并提供如下所示的上下文,

> **+++I'm planning an anniversary trip with my spouse, but they are
> currently using a wheelchair and accessibility is a must. What are
> some destinations that would be romantic for us?+++**

- **预期输出：**无障碍浪漫目的地列表，例如：

  1)  希腊圣托里尼岛：浪漫的日落和某些地区的轮椅通道。

  2)  意大利威尼斯：乘坐缆车，提供无障碍登船选项。

  3)  夏威夷毛伊岛：壮丽的景色和无障碍度假村。

3.  **测试活动建议**

    - 输入对特定目标中活动推荐的查询。例如:  
      **+++What are some things to do in Barcelona?+++**

    - 预期输出：为目标定制的推荐，例如:

      1)  参观圣家堂：高迪的杰作，配备无障碍设施。

      2)  探索桂尔公园：独特的马赛克设计，适合轮椅使用者的路线。

      3)  探索毕加索博物馆：一个可供轮椅通行的艺术场所。

## 练习 7：清理资源

1.  在 Azure 门户
    （+++[https://portal.azure.com+++](https://portal.azure.com+++/)）
    中，选择分配给你的资源组。

2.  选择其下的资源，然后单击 **Delete** （删除）。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  键入 +++delete+++ 在确认删除文本框中，然后单击 **Delete**。

4.  在 Delete 确认对话框中选择 **Delete**。

5.  查找资源已删除确认通知。

## 总结

在本实验中，我们学习了如何使用语义内核和 Azure OpenAI 服务创建代理。
