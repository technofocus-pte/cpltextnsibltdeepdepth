# Lab 6 - Azure OpenAI とSemantic Kernel SDK を使用して Contoso AI Travel アシスタントエージェントを開発する

**所要時間：40分**

## 客観的

このLabでは、Azure OpenAIとSemantic Kernel
SDKを用いて、Contoso社向けのAI-poweredトラベルエージェントを構築します。AIを活用して、ユーザーの問い合わせを理解し、旅行の推奨事項を提示し、航空券やホテルの予約、旅程管理などのタスクを実行できる会話型エージェントを作成する方法を示すことが目的です。Lab終了時には、参加者はAIモデルを実際のアプリケーションに統合し、Semantic
Kernel
SDKを活用してトラベルエージェントの機能を強化し、シミュレーション環境でエージェントのパフォーマンスをテストする実践的な経験を積むことができます。

## ソリューションの焦点領域

このLabで、Azure OpenAIとSemantic Kernel
SDKを活用したAI-poweredトラベルエージェントの構築を学びます。これにより、航空券や宿泊施設の予約、旅行のおすすめ情報の提供など、旅行計画に関するユーザーからの問い合わせをnatural
language processing（NLP）で処理できるようになります。

このLabは、ユーザーと対話し、質問に答え、旅行関連のタスクを支援する会話型AIインターフェースの開発に重点を置いています。Semantic
Kernel
SDKを使用して、旅程管理などのタスクを設けて、リアルタイムの旅行データ用のAPIを統合します。

このソリューションは、個人化された迅速な旅行支援を提供することで、ユーザーエクスペリエンスの向上を目指しています。一般的な旅行業務を自動化することで、ワークフローを最適化し、旅行計画プロセスを合理化します。

## 演習1: VMと資格情報を理解する

この演習では、本Labの全体で使用する資格情報を特定し、理解します。

1.  **Instructions**タブには、Lab全体にわたって従うべき手順が記載されたLab
    ガイドが含まれています。

2.  **Resources**タブには、Labの実行に必要な資格情報が表示されます。

    - **URL** – Azure ポータルへの URL

    - **Subscription**–
      これはあなたに割り当てられた**サブスクリプション**の**IDです**

    - **Username**– **Azure service**に**login**するために必要な**user
      id** 。

    - **Password**– **Azure login**の**Password**。

**Azureログイン資格情報**と呼びます。Azure**ログイン資格情報**について言及する際には、必ずこの資格情報を使用します。

- **Resource Group**–割り当てられた**Resource Group。**

**重要**: すべてのリソースをこのリソース
グループの下に作成してください。

![A screenshot of a computer Description automatically
generated](./media/image1.png)

3.  **Help**
    タブにはサポート情報が表示されます。ここで表示される**ID値は**、Lab実行時に使用される**Lab
    instance ID**です。

![A screenshot of a computer Description automatically
generated](./media/image2.png)

## 演習 2: Azure OpenAI リソースとモデルのデプロイを作成する

1.  Azureログイン資格情報を使用して、++\*\*
    <https://portal.azure.com**+++>にログインします

    - ユーザー名 - <+++@lab.CloudPortalCredential> (User1).Username+++

    - パスワード - <+++@lab.CloudPortalCredential> (User1).Password+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image3.png)

2.  検索バーから+++ **Azure OpenAI +++** を検索して選択します。

![A screenshot of a computer Description automatically
generated](./media/image4.png)

3.  **+ Create** を選択します。

![A screenshot of a computer Description automatically
generated](./media/image5.png)

4.  **Basics**タブで以下の詳細を入力し、 **Next**を選択します。

    - Subscription – 割り当てられた**Subscription**を選択します

    - Resource group –割り当てられた**Resource group**を選択します

    - Region– @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name – +++
      [**AOAI@lab.LabInstance.Id**](mailto:AOAI@lab.LabInstance.Id) +++

    - Pricing tier –**Standard**

![A screenshot of a computer Description automatically
generated](./media/image6.png)

5.  **Network**ページと**Tag**ページでデフォルトを受け入れ、 **Review +
    submit **ページで**Create**をクリックします。

![A screenshot of a computer Description automatically
generated](./media/image7.png)

6.  **Go to resource** をクリックし、今作成した**Azure
    OpenAI**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image8.png)

7.  **Resource Management**の**Keys and Endpoint**を選択します。**Key
    1**と**Endpoint**の値をメモ帳にコピーし、このLabで後で使用できるようにします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

8.  Azure OpenAI リソースの**Overview**ページで、 **Azure AI Foundry
    portal**に移動を選択します。

![A screenshot of a computer Description automatically
generated](./media/image10.png)

9.  左側のペインから、 **Deployments**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image11.png)

10. **+Deploy model** -\>**Deploy base model**を選択します

![A screenshot of a computer Description automatically
generated](./media/image12.png)

11. +++**gpt-35-turbo** +++を検索して選択します。
    **Confirm**をクリックします。

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image13.png)

12. デフォルトを受け入れて、 **Deploy**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

## 演習 3: Azure OpenAI Servicesを使用した AI Travel Agent Projectの設定

この演習では、Visual Studio Code でプロジェクトフォルダーを設定し、Azure
OpenAI
Servicesと統合するように構成します。手順に従うことで、ローカル開発環境の設定、プロジェクトファイルの修正、Azure
OpenAI
デプロイの詳細を使用したアプリケーションの実行準備の方法を学習できます。

1.  Windows Searchバーから+++**Command Prompt**+++を検索し、**Command
    prompt**を開きます。

![A screenshot of a computer Description automatically
generated](./media/image15.png)

2.  以下のコマンドを1つずつ実行します。

+++dotnet nuget リスト ソース+++

+++dotnet nuget add source<https://api.nuget.org/v3/index.json> --name
nuget.org++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

3.  Windows Taskbarにピンされている**Visual Studio Code**を開きます。
    **File**→ **Open Folder**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image17.png)

4.  **C: \LabFiles**に移動し、
    **AITravelAgent**フォルダを選択して**Select
    Folder**をクリックします。フォルダが VS Code で開きます。

![A screenshot of a computer Description automatically
generated](./media/image18.png)

5.  \[Do you want to trust the authors of the files in this folder?\]
    で**Yes, I trust the authors **オプションを選択します。

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image19.png)

6.  エクスプローラーペインで、
    **AITravelAgent/Starter**フォルダに移動します。フォルダを右クリックし、
    **Open in Integrated Terminal**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image20.png)

7.  Explorerパネルで、Starter フォルダーを展開すると、Plugins
    フォルダー、Prompts フォルダー、Program.cs ファイルが表示されます。

![A screenshot of a computer Description automatically
generated](./media/image21.png)

8.  Starter/Program.cs ファイルを開き、以下の変数を Azure OpenAI
    Services のデプロイ名、API
    キー、エンドポイントに更新します。変更後、Ctrl + S
    を押してファイルを保存します。

> string yourDeploymentName = +++ **gpt-35-turbo** +++
>
> string yourEndpoint = 先保存した Azure OpenAI リソースEndpoint値
>
> string yourKey = 先保存したAOAIリソースのKey1

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image22.png)

## 演習4: Semantic Kernelを使ったCurrency Converter Pluginの作成とテスト

この演習では、Semantic
Kernelを用いて通貨換算プラグインを作成します。定義済みの為替レートを用いて、ある通貨から別の通貨に金額を換算する関数を作成し、テストします。この演習を通して、カスタムプラグインの構築と呼び出し方法、機能や説明のためのデコレータの利用方法、そしてプラグインを大規模なアプリケーションに統合する方法を習得できます。

1.  **Stater/Plugins/ConvertCurrency**フォルダに+++CurrencyConverter.cs+++という新しいファイルを作成します。

![A screenshot of a computer Description automatically
generated](./media/image23.png)

2.  CurrencyConverter.csファイルに次のコードを追加してプラグイン関数を作成します。

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

このコードでは、KernelFunctionデコレータを使用してネイティブ関数を宣言しています。また、Descriptionデコレータを使用して関数の動作の説明を追加しています。Currency.Currenciesを使用すると、通貨とその為替レートの辞書を取得できます。次に、指定された金額をある通貨から別の通貨に変換するロジックを追加します。

3.  ConvertAmount関数を修正してください。既存のコードを以下のコードに置き換えてください

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

このコードでは、Currency.Currenciesディクショナリを使用して、対象通貨と基準通貨のCurrencyオブジェクトを取得します。次に、Currencyオブジェクトを使用して、基準通貨から対象通貨への金額を換算します。最後に、換算後の金額を含む文字列を返します。次に、プラグインをテストしてみましょう。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image25.png)

**注:** Semantic Kernel SDK を独自のプロジェクトで使用する場合、RESTful
API
にアクセスできる場合は、データをファイルにハードコードする必要はありません。代わりに、Plugins.Core.HttpClient
プラグインを使用して API からデータを取得できます。

4.  Starter/Program.cs
    ファイルで、次のコードを使用して新しいプラグイン関数をインポートして呼び出します。(var
    kernel = builder.Build();
    の以下のコードを削除し、以下のコードに置き換えます。)  
    kernel.ImportPluginFromType\<CurrencyConverter\>();

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

このコードでは、ImportPluginFromTypeメソッドを使ってプラグインをインポートします。次に、InvokeAsyncメソッドを使ってプラグイン関数を呼び出します。InvokeAsyncメソッドは、プラグイン名、関数名、そしてパラメータを含むディクショナリを受け取ります。最後に、結果をコンソールに出力します。次に、コードを実行して動作を確認します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

5.  上部のバーから**File**に移動し、 **Save all**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

6.  ターミナルで+++ **dotnet run**
    +++を入力します。以下の出力が表示されます。

**Output:** $52000 VND is approximately $2.13 in US Dollars (USD)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

プラグインが正しく動作するようになったので、ユーザーが変換したい通貨と金額を検出できる自然言語プロンプトを作成しましょう。

## 演習5: Semantic ProcessingのためのTarget Currency Promptの設定

この演習では、ユーザー入力から対象通貨、基準通貨、金額を識別するプロンプトシステムを設定します。設定ファイルとプロンプトファイルを作成して設定することで、AIが自然言語による通貨換算リクエストをどのように解釈し、処理するかを定義します。

1.  Visual Studio Code
    から**Starter/Prompts**フォルダを見つけます。このフォルダに移動して、次の手順の準備をします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

2.  **Starter/Prompts**フォルダ内に、+++ **GetTargetCurrencies
    +++**という新しいフォルダを作成します。このフォルダに、この演習に関連するすべてのファイルを保存します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

3.  **GetTargetCurrencies**フォルダー内に、+++ **config.json
    +++**という名前の新しいファイルを作成します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

> 新しく作成した**config.json**ファイルを開きます。以下のコードをコピーしてファイルに貼り付けます。  
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
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image32.png)

**Ctrl +
S**を押してファイルを保存します。この設定は、AIシステムがユーザー入力をどのように解釈し処理するかを定義します。

5.  **Prompts**フォルダーの下に、+++ **skprompt.txt
    +++**という名前の別の新しいファイルを作成します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  テキスト
    エディターで**skprompt.txt**ファイルを開き、次の内容を貼り付けます。

> \<message role="system"\>Identify the target currency, base currency,
> and
>
> amount from the user's input in the format
> target|base|amount\</message\>

For example:

\<message role="user"\>How much in GBP is 750.000 VND?\</message\>  
\<message role="assistant"\>GBP|VND|750000\</message\>

\<message role="user"\>How much is 60 USD in New Zealand
Dollars?\</message\>  
\<message role="assistant"\>NZD|USD|60\</message\>

\<message role="user"\>How many Korean Won is 33,000 yen?\</message\>  
\<message role="assistant"\>KRW|JPY|33000\</message\>

\<message role="user"\>{{$input}}\</message\>  
\<message role="assistant"\>target|base|amount\</message\>

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

**Ctrl +
S**を押してファイルを保存します。このスクリプトは、通貨換算リクエストを処理するためのプロンプトロジックを定義します。

## 演習6: 旅行アクティビティの推奨のためのプロンプトシステムの設定

この演習では、ユーザーの旅行先に基づいてアクティビティや興味のある場所を提案するプロンプトシステムを設定およびカスタマイズします。設定ファイルとプロンプトファイルを編集することで、システムの動作、トーン、入力要件を定義し、パーソナライズされたクリエイティブな旅行のおすすめを生成します。

1.  Visual Studio
    Codeから**Starter/Prompts/SuggestActivities**フォルダーに移動します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

2.  SuggestActivities
    フォルダー内の**config.json**ファイルを見つけて開きます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

3.  **config.json**ファイル内の既存のコードを次のコードに置き換えます。

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

変更を加えたら、 **Ctrl +
S**を押してファイルを保存します。このファイルは、ユーザー入力を処理し、アクティビティの提案を生成するようにシステムを構成します。

4.  SuggestActivitiesフォルダ内で**skprompt.txt**ファイルを見つけます。このファイルをエディタで開きます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

5.  **skprompt.txt**の既存の内容を次のテキストに置き換えます。

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

**Ctrl +
S**を押してファイルを保存します。このスクリプトは、アクティビティの推奨を生成する際のシステムの動作とトーンを設定します。

## 演習7: AI WorkflowのためのMain Programの構成

この演習では、メインのProgram.csファイルをAzure OpenAI
ServicesとMicrosoft Semantic
Kernelと統合するように構成します。コードをカスタマイズすることで、通貨換算、アクティビティの提案、旅行のおすすめといった機能を有効にできます。この設定により、プラグインとプロンプトベースのロジックを活用し、ユーザーインタラクションとインテント認識のためのAI-poweredベースのワークフローが構築されます。

1.  Visual Studio Code のプロジェクトから、
    **Starter/Program.cs**ファイルに移動し、編集用に開きます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  **Program.csファイル**の内容全体を次のコードに置き換え、 **Ctrl + S
    を押して**コードを保存します。

**注:**コードを置き換えた後、エンドポイントとキーのプレースホルダーをその値に置き換えます。

System.Text を使用します。

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

このプログラムは、テキスト処理用のSystem.TextやAI-powered会話型ワークフロー用のMicrosoft.SemanticKernelといった重要な名前空間をインポートすることから始まります。Microsoft.SemanticKernel.Connectors.OpenAI名前空間を介してMicrosoft
Azure OpenAI
Servicesを統合し、GPTモデル（gpt-35-turbo）との通信を可能にします。構成には、Azure
OpenAIエンドポイントへの認証と接続にyourDeploymentName、yourEndpoint、yourApiKeyなどの必要な変数の設定が含まれます。

Semantic
Kernelはbuilderパターンを用いて初期化されます。CurrencyConverterやConversationSummaryPluginといった追加機能のためのPluginsがインポートされます。さらに、ディレクトリ（Prompts）に保存されたプロンプトが動的に読み込まれ、インテント認識とタスク実行が容易になります。

プログラムのメインループは、ユーザーに入力を求め、GetIntentプロンプトを使用してそのインテントを判断することでユーザーと対話します。インテントに基づいて、プログラムは様々な機能に分岐します。

1.  **Currency
    Conversion**：インテントが通貨換算の場合、プログラムはGetTargetCurrenciesプロンプトを使用して詳細情報（換算対象通貨、基準通貨、金額）を抽出します。その後、CurrencyConverterプラグインのConvertAmountメソッドを呼び出して結果を表示します。

2.  **Destination Suggestions**:
    インテントが目的地を提案することの場合、プログラムはSemantic
    Kernel'sの InvokePromptAsync
    メソッドを使用して、ユーザー入力に基づいた推奨事項を提供します。

3.  **Activity Suggestions:**この機能は、ConversationSummaryPlugin
    による会話要約機能を活用し、状況に応じた適切なアクティビティ提案を提供します。会話履歴は、継続的な対話フローを実現するために
    StringBuilder オブジェクトを使用して維持されます。

4.  **Helpful Phrases and
    Translation**:「HelpfulPhrases」や「Translate」などのインテントの場合、kernelは入力と設定に基づいて関連する機能を自動的に呼び出します。

その他のユーザーインテントは、プロンプトシステムを呼び出すことで汎用的に処理され、応答の柔軟性が確保されます。インタラクションループは、ユーザーが何も入力しない（空の文字列を返す）まで継続されます。　

## 演習8: アプリケーションのテスト

この演習では、通貨換算、目的地の提案、アクティビティの推奨などのクエリを実行して、アプリケーションの機能をテストします。これにより、AI-poweredシステムが予想通りに動作し、正確で状況に応じた出力を提供していることを確認できます。

**テスト手順**

1.  **アプリケーションを実行する**

    - Starter フォルダーを右クリックし、 **Open in Integrated
      Terminal**を選択します。

    - ターミナルで次のコマンドを入力してアプリケーションを実行します。

+++dotnet run+++

2.  **通貨換算テスト**

    - **What would you like to
      do? **とプロンプトが表示された場合、以下のように通貨換算クエリを入力します  
      +++**How much is 60 USD in New Zealand dollars?**+++

    - 予想出力:  
      **$60 USD is approximately $97.88 in New Zealand Dollars (NZD)**

3.  **目的地の提案のテスト**

    - 目的地の候補を検索するクエリを入力し、以下のようなコンテキストを指定します。

> **+++I'm planning an anniversary trip with my spouse, but they are
> currently using a wheelchair and accessibility is a must. What are
> some destinations that would be romantic for us?+++**

- **予想出力:**アクセス可能なロマンチックな目的地のリスト:　

  1.  Santorini, Greece: Romantic sunsets and wheelchair-accessible
      paths in certain areas.

  2.  Venice, Italy: Gondola rides with accessible boarding options.

  3.  Maui, Hawaii: Stunning views and accessible resorts.

4.  **アクティビティ提案のテスト**

    - 特定の目的地でのアクティビティのおすすめを検索するクエリを入力してください。例：  
      **+++What are some things to do in Barcelona?+++**

    - **予想出力**: 次のような、目的地に合わせた推奨事項:

      1.  Visit the Sagrada Família: A Gaudí masterpiece with accessible
          facilities.

      2.  Explore Park Güell: Unique mosaic designs with
          wheelchair-friendly routes.

      3.  Discover the Picasso Museum: A wheelchair-accessible art
          venue.

## 演習9: リソースをクリーンアップする

1.  Azure ポータル (+++
    [https://portal.azure.com+++](https://portal.azure.com+++/) )
    から、割り当てられているリソース グループを選択します。

2.  その下のリソースを選択し、 **Delete** をクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  削除確認テキストボックスに+++delete+++と入力し、
    **Delete**をクリックします。

4.  削除確認ダイアログボックスで**Delete**を選択します。

5.  リソース削除の通知を確認します。

## 要旨

このLabでは、Semantic Kernelと Azure OpenAI
Servicesを使用してエージェントを作成する方法を学習しました。
