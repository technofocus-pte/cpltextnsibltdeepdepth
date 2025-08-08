# 실습 6 - Azure OpenAI 및 Semantic Kernel SDK를 사용하여 Contoso AI 여행 도우미 에이전트 개발

**예상 소요 시간: 40분**

## 목표

이 실습에서 참가자는 Azure OpenAI 및 Semantic Kernel SDK를 사용하여
Contoso를 위한 AI 기반 여행사를 빌드합니다. 목표는 AI 기술을 활용하여
사용자 쿼리를 이해하고, 여행 추천을 제공하고, 항공편, 호텔 예약 및 일정
관리와 같은 작업을 수행할 수 있는 대화형 에이전트를 만드는 방법을
보여주는 것입니다. 실습이 끝날 무렵 참가자들은 AI 모델을 실제
애플리케이션과 통합하고, Semantic Kernel SDK를 활용하여 여행사의 기능을
향상시키고, 시뮬레이션 환경에서 여행사의 성능을 테스트하는 실습 경험을
하게 됩니다.

## 솔루션 중점 영역

이 실습은 Azure OpenAI 및 Semantic Kernel SDK를 사용하여 AI 기반
여행사를 빌드하는 데 중점을 둡니다. Natural language processing (NLP)를
통해 항공편, 숙박 시설 예약, 여행 추천 제공 등 여행 계획과 관련된 사용자
쿼리를 처리할 수 있습니다.

이 실습은 사용자와 상호 작용하고, 질문에 답변하고, 여행 관련 작업을
지원하는 대화형 AI 인터페이스를 생성하는 데 중점을 둡니다. Semantic
Kernel SDK를 사용하여 여정 관리와 같은 작업을 오케스트레이션하고 실시간
여행 데이터를 위한 API를 통합합니다.

이 솔루션은 개인화되고 반응이 빠른 여행 지원을 제공하여 사용자 경험을
향상시키는 것을 목표로 합니다. 일반적인 출장 작업을 자동화하여
워크플로우를 최적화하고 출장 계획 프로세스를 간소화합니다.

## 연습 1: VM 및 자격 증명 이해하기

이 연습에서는 실습 전체에서 사용할 자격 증명을 식별하고 이해합니다.

1.  **Instructions** 탭에는 실습 전반에 걸쳐 따라야 할 지침이 있는 실습
    가이드가 있습니다.

2.  **Resources** 탭에는 실습을 실행하는 데 필요한 자격 증명이 있습니다.

    - **URL** – Azure portal에 대한 URL

    - **Subscription** – 사용자에게 할당된 **subscription** 의
      **ID**입니다

    - **Username** – **Azure services**에 **login**하는 데 사용하는
      **user id **입니다

    - **Password** –  **Azure login**에 대한 **Password**.

이 사용자 이름과 암호를 **Azure login credentials**이라고 하겠습니다.
**Azure login credentials**을 언급할 때마다 이러한 자격 증명을
사용하세요.

- **Resource Group** – 사용자에게 할당된 **Resource group** you.

\[!경고\] **중요**: 이 Resource group 아래에 모든 리소스를 생성해야
합니다.

![A screenshot of a computer Description automatically
generated](./media/image1.png)

1.  **Help **탭에는 지원 정보가 있습니다. 여기서 **ID** 값은 실습 실행
    중에 사용되는 **Lab Instance ID**입니다.

![A screenshot of a computer Description automatically
generated](./media/image2.png)

## 연습 2: Azure OpenAI 리소스 및 모델 배포 생성하기

1.  Azure 로그인 자격 증명을 사용하여https://portal.azure.com\*\*++에
    로그인하세요,

    - Username - <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image3.png)

2.  검색 바에서 +++**Azure OpenAI**+++를 검색하고 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image4.png)

3.  **+ Create**를 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image5.png)

4.  **Basics** 탭에 다음 세부 정보를 입력하고 **Next**을 선택하세요.

    - Subscription – 할당된 **subscription**을 선택하세요

    - Resource group – 자신에게 할당된 **Resource group을** 선택하세요.

    - Region – @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name –
      +++[**AOAI@lab.LabInstance.Id**](mailto:AOAI@lab.LabInstance.Id)+++

    - Pricing tier – **Standard**

![A screenshot of a computer Description automatically
generated](./media/image6.png)

5.  **Network and Tags** 페이지에서 기본값을 수락하고 **Review +
    submit** 페이지에서 **Create**를 클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image7.png)

6.  생성되면 **Go to resource**을 클릭하고 지금 만든 **Azure OpenAI**를
    선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image8.png)

7.  **Resource Management**에서 **Keys** 및 **Endpoint**를 선택하세요.
    이 실습에서 나중에 사용할 수 있도록 **Key 1** 및 **Endpoint** 값을
    메모장에 복사하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

8.  Azure OpenAI 리소스 **Overview** 페이지에서 **Go to Azure AI Foundry
    portal**로 이동을 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image10.png)

9.  왼쪽 창에서 **Deployments**을 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image11.png)

10. **+ Deploy model** -\> **Deploy base model**을 선택하세요

![A screenshot of a computer Description automatically
generated](./media/image12.png)

11. +++**gpt-35-turbo**+++를 검색하고 선택하세요. **Confirm**을
    클릭하세요.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image13.png)

12. 기본 사항을 수락하고 **Deploy**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

## 연습 3: Azure OpenAI 서비스를 사용하여 AI 여행사 프로젝트 설정하기

이 연습에서는 Visual Studio Code에서 프로젝트 폴더를 설정하고 Azure
OpenAI Services와 통합되도록 구성합니다. 단계에 따라 로컬 개발 환경을
설정하고, 프로젝트 파일을 수정하고, Azure OpenAI 배포 세부 정보를
사용하여 실행할 애플리케이션을 준비하는 방법을 배울 것입니다.

1.  Windows 검색 창에서 +++**Command Prompt**+++를 검색하고 **Command
    Prompt**를 여세요.

![A screenshot of a computer Description automatically
generated](./media/image15.png)

2.  아래 명령을 하나씩 실행하세요.

+++dotnet nuget list source+++

+++dotnet nuget add source <https://api.nuget.org/v3/index.json> --name
nuget.org+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

3.  Windows 작업 표시줄에 고정된 **Visual Studio Code**를 여세요.
    **File -\> Open folder**를 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image17.png)

4.  **C:\LabFiles**로 이동하여 **AITravelAgent** 폴더를 선택하고
    **Select Folder**을 클릭하세요. 폴더가 VS Code에서 열립니다.

![A screenshot of a computer Description automatically
generated](./media/image18.png)

5.  Do you want to trust the authors of the files in this folder?에서
    **Yes, I trust the authors**를 선택하세요

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image19.png)

6.  Explorer창에서 **AITravelAgent/Starter** 폴더로 이동하세요. 폴더를
    마우스 오른쪽 버튼으로 클릭하고 **Open in Integrated Terminal**을
    선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image20.png)

7.  Explorer 패널에서 Starter 폴더를 확장하면 Plugins 폴더, Prompts 폴더
    및 Program.cs 파일이 표시됩니다.

![A screenshot of a computer Description automatically
generated](./media/image21.png)

8.  Starter/Program.cs 파일을 열고 Azure OpenAI Services 배포 이름, API
    키 및 엔드포인트로 다음 변수를 업데이트합니다. 변경한 후 Ctrl + S를
    눌러 파일을 저장하세요:

> string yourDeploymentName = +++**gpt-35-turbo**+++
>
> string yourEndpoint = The Azure OpenAI resource Endpoint value we
> saved earlier
>
> string yourKey = The Key1 of the AOAI resource that we saved earlier

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image22.png)

## 연습 4: Semantic Kernel을 사용한 통화 변환기 플러그인 생성 및 테스트하기

이 연습에서는 Semantic Kernel을 사용하여 환율 변환기 플러그인을
만듭니다. 미리 정의된 환율을 사용하여 한 통화에서 다른 통화로 금액을
변환하는 함수를 작성하고 테스트합니다. 이 연습은 사용자 정의 플러그인을
빌드 및 호출하고, 기능 및 설명에 데코레이터를 활용하고, 플러그인을 더 큰
애플리케이션에 통합하는 방법을 이해하는 데 도움이 됩니다.

1.  **Stater/Plugins/ConvertCurrency** 폴더에
    +++CurrencyConverter.cs+++라는 새 파일을 생성하세요.

![A screenshot of a computer Description automatically
generated](./media/image23.png)

2.  CurrencyConverter.cs 파일에서 다음 코드를 추가하여 플러그인 함수를
    생성하세요

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

이 코드에서는 KernelFunction 데코레이터를 사용하여 네이티브 함수를
선언합니다. 또한 Description 데코레이터를 사용하여 함수가 수행하는
작업에 대한 설명을 추가합니다. Currency.Currencies를 사용하여 통화 및
해당 환율 사전을 가져올 수 있습니다. 다음으로, 주어진 금액을 한 통화에서
다른 통화로 변환하는 논리를 추가하세요.

3.  ConvertAmount 함수를 수정합니다. 기존 코드를 아래 코드로 바꾸세요.

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

이 코드에서는 Currency.Currencies 사전을 사용하여 대상 통화와 기본
통화에 대한 Currency 개체를 가져옵니다. 그런 다음 Currency 개체를
사용하여 기본 통화에서 대상 통화로 금액을 변환합니다. 마지막으로 변환된
금액이 포함된 문자열을 반환합니다. 다음으로 플러그인을 테스트해
보겠습니다.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image25.png)

\[!참고\] **참고:** 자체 프로젝트에서 Semantic Kernel SDK를 사용할 때
RESTful API에 액세스할 수 있는 경우 데이터를 파일로 하드코딩할 필요가
없습니다. 대신 Plugins.Core.HttpClient 플러그인을 사용하여 API에서
데이터를 검색할 수 있습니다.

4.  Starter/Program.cs 파일에서 다음 코드를 사용하여 새 플러그인 함수를
    가져오고 호출하세요. (아래 코드를 삭제하세요. var kernel = builder.
    빌드(); 아래 주어진 코드로 교체하세요.)

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

이 코드에서는 ImportPluginFromType 메서드를 사용하여 플러그인을
가져옵니다. 그런 다음 InvokeAsync 메서드를 사용하여 플러그인 함수를
호출합니다. InvokeAsync 메서드는 플러그인 이름, 함수 이름 및 매개 변수
사전을 사용합니다. 마지막으로 결과를 콘솔에 출력합니다. 그런 다음 코드를
실행하여 작동하는지 확인하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

5.  상단 표시줄에서 **File **로 이동하여 **Save all**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

6.  터미널에서 +++**dotnet run**+++을 입력하세요. 다음 출력이 표시되어야
    합니다:

**Output:** $52000 VND is approximately $2.13 in US Dollars (USD)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

이제 플러그인이 올바르게 작동하므로 사용자가 변환하려는 통화와 금액을
감지할 수 있는 자연어 프롬프트를 생성해 보겠습니다.

## 연습 5: Semantic Processing을 위한 Target Currency Prompt 구성하기

이 연습에서는 사용자 입력에서 대상 통화, 기본 통화 및 금액을 식별하도록
프롬프트 시스템을 구성합니다. 구성 및 프롬프트 파일을 생성하고 설정하여
AI가 통화 변환에 대한 자연어 요청을 해석하고 처리하는 방법을 정의합니다.

1.  Visual Studio Code에서 **Starter/Prompts** 폴더를 찾으세요. 이
    폴더로 이동하여 다음 단계를 준비하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

2.  **Starter/Prompts** 폴더 내에 +++**GetTargetCurrencies**+++라는 새
    폴더를 생성하세요. 이 폴더에는 이 연습과 관련된 모든 파일이
    포함됩니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

3.  **GetTargetCurrencies** 폴더 내에 +++**config.json**+++라는 새
    파일을 생성하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

4.  Visual Studio Code에서 새로 생성한 **config.json** 파일을 여세요.
    다음 코드를 복사하여 파일에 붙여넣으세요.

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

**Ctrl + S**를 눌러 파일을 저장하세요. 이 구성은 AI 시스템이 사용자
입력을 해석하고 처리하는 방법을 정의하세요.

5.  **Prompts **폴더에서 +++**skprompt.txt**+++라는 다른 새 파일을
    생성하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  텍스트 편집기에서 **skprompt.txt** 파일을 열고 다음 내용을
    붙여넣으세요:

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

**Ctrl + S**를 눌러 파일을 저장하세요. 이 스크립트는 통화 변환 요청을
처리하기 위한 프롬프트 논리를 정의하세요.

## 연습 6: 여행 활동 권장 사항에 대한 프롬프트 시스템 구성하기

이 연습에서는 프롬프트 시스템을 설정하고 사용자 정의하여 사용자의 여행
목적지를 기반으로 활동과 관심 지점을 제안합니다. 구성 및 프롬프트 파일을
편집하여 시스템의 동작, 톤 및 입력 요구 사항을 정의하여 개인화되고
창의적인 여행 추천을 생성할 수 있습니다.

1.  Visual Studio Code에서 **Starter/Prompts/SuggestActivities** 폴더로
    이동하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

2.  SuggestActivities 폴더 내에서 **config.json** 파일을 찾아 여세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

3.  **config.json** 파일의 기존 코드를 다음으로 바꾸세요:

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

변경한 후 **Ctrl + S**를 눌러 파일을 저장하세요. 이 파일은 사용자 입력을
처리하고 활동에 대한 제안을 생성하도록 시스템을 구성하세요.

4.  SuggestActivities 폴더 내에 머물면서 **skprompt.txt** 파일을
    찾으세요. 편집기에서 이 파일 여세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

5.  **skprompt.txt**의 기존 내용을 다음 텍스트로 바꾸세요:

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

**Ctrl + S**를 눌러 파일을 저장하세요. 이 스크립트는 활동 추천을 생성할
때 시스템의 동작과 톤을 설정하세요.

## 연습 7: AI Workflow를 위한 메인 프로그램 구성하기

이 연습에서는 Azure OpenAI 서비스 및 Microsoft Semantic Kernel과
통합하도록 기본 Program.cs 파일을 구성합니다. 코드를 사용자 지정하면
통화 변환, 활동 제안 및 여행 추천과 같은 기능을 사용할 수 있습니다. 이
설정은 플러그인 및 프롬프트 기반 로직을 활용하여 사용자 상호 작용 및
의도 인식을 위한 강력한 AI 기반 워크플로를 설정합니다.

1.  Visual Studio Code의 프로젝트에서 **Starter/Program.cs** 파일로
    이동하여 편집을 위해 여세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  **Program.cs** 파일의 전체 내용을 다음 코드로 바꾼 후 **cntrl + S를
    눌러** 코드를 저장하세요.

\[!참고\] **참고:** 코드를 바꾼 후 endpoint 및 Key의 자리 표시자를 해당
값으로 바꾸세요.

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

이 프로그램은 텍스트 처리를 위한 System.Text와 AI 기반 대화형 워크플로를
위한 Microsoft.SemanticKernel과 같은 필수 네임스페이스를 가져오는 것으로
시작합니다. Microsoft.SemanticKernel.Connectors.OpenAI 네임스페이스를
통해 Microsoft Azure OpenAI 서비스를 통합하여 GPT 모델 (gpt-35-turbo)과
통신할 수 있습니다. 구성에는 Azure OpenAI 엔드포인트를 인증하고 연결하기
위해 yourDeploymentName, yourEndpoint 및 yourApiKey와 같은 변수를
설정하는 작업이 포함됩니다.

Semantic Kernel은 빌더 패턴을 사용하여 초기화됩니다. CurrencyConverter
및 ConversationSummaryPlugin과 같은 추가 기능을 위한 플러그인을
가져옵니다. 또한 디렉토리(Prompts)에 저장된 프롬프트는 의도 인식과 작업
실행을 용이하게 하기 위해 동적으로 로드됩니다.

프로그램의 메인 루프는 입력을 요청하고 GetIntent 프롬프트를 사용하여
의도를 결정하여 사용자와 상호 작용합니다. 의도에 따라 프로그램은 다양한
기능으로 분기됩니다:

- **통화 변환**: 통화를 변환하려는 경우 프로그램은 GetTargetCurrencies
  프롬프트를 사용하여 세부 정보(대상 통화, 기본 통화 및 금액)를
  추출합니다. 그런 다음 CurrencyConverter 플러그인의 ConvertAmount
  메소드를 호출하고 결과를 표시합니다.

- **대상 제안**: 대상을 제안하려는 경우 프로그램은 시맨틱 커널의
  InvokePromptAsync 메서드를 사용하여 사용자 입력에 따라 권장 사항을
  제공합니다.

- **활동 제안**: 이 기능은 ConversationSummaryPlugin을 통한 대화 요약을
  활용하여 상황에 맞는 활동 제안을 제공합니다. 대화 기록은 지속적인 대화
  흐름을 위해 StringBuilder 개체를 사용하여 유지됩니다.

- **유용한 문구 및 번역**: "HelpfulPhrases" 또는 "Translate"와 같은
  의도의 경우 커널은 입력 및 설정에 따라 관련 함수를 자동으로
  호출합니다.

다른 사용자 의도는 프롬프트 시스템을 호출하여 일반적으로 처리되어 응답의
유연성을 보장합니다. 상호 작용 루프는 사용자가 입력(빈 문자열)을
제공하지 않을 때까지 계속됩니다.

## 연습 8: 애플리케이션 테스트하기

이 연습에서는 통화 변환, 목적지 제안 및 활동 권장 사항에 대한 쿼리를
실행하여 응용 프로그램의 기능을 테스트합니다. 이를 통해 AI 기반 시스템이
의도한 대로 작동하고 상황에 맞는 정확한 출력을 제공할 수 있습니다.

**테스트 단계**

1.  **애플리케이션 실행**

    - Starter 폴더를 마우스 오른쪽 버튼으로 클릭하고 **Open in
      Integrated Terminal**을 선택하세요.

    - 터미널에서 다음 명령을 입력하여 애플리케이션을 실행하세요:

+++dotnet run+++

2.  **통화 변환 테스트하기**

    - 메시지가 표시되면 **What would you like to do?** 아래와 같이 통화
      변환 쿼리를 입력하세요.  
      +++**How much is 60 USD in New Zealand dollars?**+++

    - **예상 출력**:  
      **$60 USD is approximately $97.88 in New Zealand Dollars (NZD)**

3.  **테스트 대상 제안**

    - 목적지 제안에 대한 쿼리를 입력하여 아래와 같이 컨텍스트를
      제공하세요,

> **+++I'm planning an anniversary trip with my spouse, but they are
> currently using a wheelchair and accessibility is a must. What are
> some destinations that would be romantic for us?+++**

- **예상 출력:** 다음과 같이 접근 가능한 낭만적 인 목적지 목록:

  - 그리스 산토리니: 로맨틱한 일몰과 특정 지역의 휠체어 접근 가능한 길.

  - 이탈리아 베니스: 접근 가능한 탑승 옵션이 있는 곤돌라 타기.

  - 하와이 마우이: 멋진 전망과 접근 가능한 리조트.

4.  **테스트 활동 제안**

    - 특정 대상에서 활동 권장 사항에 대한 쿼리를 입력하세요. 예를
      들어:  
      **+++What are some things to do in Barcelona?+++**

    - 예상 출력: 다음과 같이 목적지에 맞는 추천:

      - 사그라 다 파밀리아 (Sagrada Família) : 접근 가능한 시설을 갖춘
        가우디의 걸작을 방문.

      - 구엘 공원 둘러보기: 휠체어 친화적인 경로가 있는 독특한 모자이크
        디자인.

      - 피카소 미술관(Picasso Museum)은 휠체어 접근이 가능한 예술
        공간입니다.

## 연습 7: 리소스 정리하기

1.  Azure
    Portal(+++[https://portal.azure.com+++](https://portal.azure.com+++/))에서
    할당된 리소스 그룹을 선택하세요.

2.  그 아래에 있는 리소스를 선택하고 **Delete**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  삭제 확인 텍스트 상자에 +++**delete**+++를 입력하고 **Delete**를
    클릭하세요.

4.  삭제 확인 대화 상자에서 **Delete**를 선택하세요.

5.  리소스 삭제 확인 알림을 찾으세요.

## 요약

이 실습에서는 Semantic Kernel 및 Azure OpenAI 서비스를 사용하여
에이전트를 생성하는 방법을 배웠습니다.
