# 실습 3: Teams AI 라이브러리 및 Teams Toolkit를 사용하여 데이터와 채팅하는 사용자 지정 Contoso 에이전트 빌드

**예상 소요 시간: 45분**

## 목표

이 실습의 목표는 참가자가 Teams AI 라이브러리 및 Teams Toolkit를
활용하여 사용자 지정 Contoso 에이전트를 빌드할 수 있도록 하는 것입니다.
참가자는 GPT 기능을 통합하고, Azure OpenAI 및 Azure Blob Storage를
사용하여 데이터를 설정 및 관리하고, AI 기반 상호 작용에 맞게 조정된
사용자 지정 채팅 모델을 배포하도록 Azure OpenAI API를 구성합니다. 실습이
끝날 때쯤이면 Visual Studio Code 및 Teams Toolkit을 사용하여 Teams AI
기반 사용자 지정 에이전트를 생성하고 구성하여 AI 지원 애플리케이션을
배포하고 관리하는 데 대한 실질적인 경험을 얻게 됩니다.

## 솔루션 초점 영역

이 실습 가이드는 참가자가 Azure OpenAI API를 활용하여 지능적인 컨텍스트
인식 채팅 상호 작용을 생성할 수 있도록 하는 데 중점을 둡니다. 참가자는
GPT 기반 모델을 구성하고 효율적인 데이터 관리를 위해 Blob Storage 및
Azure AI Search와 같은 Azure 서비스와 통합합니다.

이 실습은 비즈니스 요구 사항을 충족하기 위해 맞춤형 프롬프트와 설정을
사용하여 채팅 모델을 배포하고 사용자 지정하는 실습 경험을 제공합니다.
또한 참가자는 Teams AI 라이브러리 및 Teams Toolkit를 사용하여 사용자
지정 AI 에이전트를 구축하여 조직 워크플로에 원활하게 통합합니다.

## 연습 1: Azure OpenAI API 및 역할 권한 구성하기

### 작업 1: OpenAI의 GPT를 사용하기 위해 Azure OpenAI API 키 생성하기

1.  브라우저를 열고 다음 URL +++<https://oai.azure.com/portal+++> 로
    이동하고 다음을 사용하여 로그인하세요.

    - Username - <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image1.png)

2.  **Azure AI Foundry** 홈페이지에서 **Create new Azure OpenAI
    resource**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

3.  Create Azure OpenAI 창이 열리고 프롬프트되면 다시 로그인하세요. 아래
    주어진 세부 정보를 해당 필드에 입력하고 **Next**를 클릭하세요.

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image3.png)

4.  **Network** 및 **Tags** 탭 아래 기본값을 수락하고 **Next**를
    클릭하세요

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image5.png)

5.  **Review + submit** 탭에서 **Create**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

6.  배포가 성공되면 창이 자동으로 CognitiveServiceOpenAI 페이지로
    이동하세요. Resource Group 페이지로 이동하려면 **Go to resource**를
    클릭하세요page.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

7.  생성된Azure OpenAI 리소스를 선택하세요. AzureOpenAI 리소스 페이지의
    왼쪽 창에서 **Resource Management** 아래 있는 **Keys and
    Endpoint**를 선택하고 나중에 참조할 수 있도록 **Key** 및
    **Endpoint** 값을 복사하여 메모장에 저장하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

### 작업 2: Cognitive 기여자 역할 할당하기

1.  Resource Group 개요 페이지에서 **ResourceGroup1**을 선택하세요.

2.  Resource group 페이지의 왼쪽 창에서 **Access control (IAM)**을
    선택하세요. **+** **Add**를 선택하고 **Add role assignment**을
    클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

3.  +++**cognitive service contributor+++**를 검색하고
    선택하고 **Next**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

4.  구성원을 할당하려면 **Select members**를 클릭하세요.
    <+++@lab.CloudPortalCredential(User1).Username>+++를 검색하고
    **Select**를 클릭하세요. **Next**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

5.  Assignment type 탭에서assignment type을 **Active**로
    duration을**Permanent**로 입력하고 **Review +Assign**을 클릭하고
    다시 **Review + Assign**을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

6.  역할 할당이 성공적으로 수행되면 성공 메시지가 표시됩니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image15.png)

## 연습 2: Azure OpenAI에서 데이터 설정하기

### 작업 1: AI Foundry에서 채팅 배포하기

1.  왼쪽 상단에서 햄버거 메뉴를 선택하고 **All resources**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

2.  이전에 생성한 Azure OpenAI
    서비스 [**ContosoAgent@lab.LabInstance.Id**](mailto:ContosoAgent@lab.LabInstance.Id) 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

3.  **Go to Azure AI Foundry portal**을 선택하세요.

4.  왼쪽 창에서 **Model Catalog** 를 선택하세요.

![image](./media/image18.png)

5.  **Select a chat completion model** 페이지에서 +++gpt-4o+++를
    검색하고 선택하고 **Confirm**을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

6.  **Deploy model gpt-4o** 창에서 **Customize** 탭을 확장하고 다음 세부
    정보를 입력하고 **Deploy**를 클릭하세요.

    - **Deployment type**: Standard

    - **Deployment name**: gpt-4o

    - **Token per Minute Rate**: 5K (스크롤하여 한도를 조정합니다.
      작동하지 않으면 해당 항목을 클릭한 다음 Shift+오른쪽/왼쪽 화살표
      키를 사용하여 제한을 조정하세요)

    - **Content Filter**: defaultv2

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image21.png)

7.  YShared resources **à** Deployments(배포)에서 배포를 확인할 수
    있습니다**.**

\![ 컴퓨터 AI 생성 콘텐츠의 스크린샷이 올바르지 않을 수
있습니다.\](./media/image25.png)

### 작업 2: 스토리지 계정 생성하기

1.  Azure portal +++<https://portal.azure.com/+++> 홈페이지에서
    +++Storage accounts+++를 검색하고 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image22.png)

2.  **+ Create**를 클릭하고 다음 세부 정보를 입력하고 **Review +
    create**를 클릭하세요.

    - Subscription – 구독을 선택하세요

    - Resource group – 할당된 Resourcegroup을 선택하세요

    - Storage account name - <+++contosostorage@lab.LabInstance.Id>+++

    - Region – @lab.CloudResourceGroup(ResourceGroup1).Location을
      선택하세요

    - Primary service – Azure Blob storage or Azure Data Lake Storage
      Gen 2

    - Performance – Standard

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

3.  **Create**를 클릭하고  배포가 완료될 때까지 기다린 후 **Go to
    resource**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

4.  새로 생성한 스토리지 계정에서 데이터 스토리지 아래의
    **Containers** 로 이동하고 **+ Containers **를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

5.  Container name을 +++**source**+++를 입력하고 **create**를
    클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

6.  **Source** container를 클릭하고 여세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

7.  소스 컨테이네에 데이터를 추가하려면 **Upload** --\_ **Browse for
    files**을 클릭하고 C:\Labfiles에서 **TF-AzureOpenAI.pdf**를
    선택하세요. 파일을 선택한 후 **upload** 버튼을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

### 작업 3: Azure AI search를 생성하기

1.  Azure portal +++<https://portal.azure.com/+++> 홈페이지에서 +++**AI
    search**+++를 검색하고 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

2.  새 Azure AI Search 리소스를 셍성하려면 **+ Create** 를 클릭하세요.

다음 세부 정보를 입력하고 **Review + create**를 클릭하고 **Create**를
선택하세요.

- Subscription: 구독을 선택하세요

- Resource Group: 할당된 Resource group을 선택하세요

- Service name: <+++contoso-ai-search-@lab.LabInstance.Id>+++

- Location: @lab.CloudResourceGroup(ResourceGroup1).Location

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

![A screenshot of a search service AI-generated content may be
incorrect.](./media/image35.png)

![A screenshot of a search engine AI-generated content may be
incorrect.](./media/image36.png)

3.  search-service-contoso-ai-search-01overview에서 **Go to resource**를
    클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

4.  <contoso-ai-search-@lab.LabInstance.Id> 개요에서 나중에 사용할 수
    있도록 **URL** endpoint를 저장하세요. 왼쪽 탐색 모음에서
    **Settings** 아래의 **keys**를 선택하고 나중에 사용할 수 있도록
    **primary** 및 **secondary** **key**를 저장하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

### 작업 4: Azure AI Foundry에서 채팅에 데이터 추가하기

1.  **Azure AI Foundry** 페이지에서 **Chat** -\> **Add your data -\> Add
    a data source**를 선택하세요.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image40.png)

2.  드롭다운에서 **Azure Blob Storage (preview)**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  **Add data** 페이지에서 다음 세부 정보를 입력하고 **Next**를
    클릭하세요.

    - Select data source – Azure Blob Storage(preview)

    - Subscription - subscription을 선택하세요

    - Select Azure Blob storage resource
      –[**contosostorage@lab.LabInstance.Id**](mailto:contosostorage@lab.LabInstance.Id)를
      선택하세요

    - Select storage container – **source**를 선택하세요

    - Select Azure AI Search resource
      – [**contoso-ai-search-@lab.LabInstance.Id**](mailto:contoso-ai-search-@lab.LabInstance.Id)를
      선택하세요

    - Index Name - <+++contosoindex@lab.LabInstance.Id>+++를 입력하세요

    - Indexer schedule - Once

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

4.  **Data management** 페이지에서search type을 **keyword**로 선택하고
    **Next**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

5.  **Data connection** 페이지에서 **API key**를 선택하고 **Next**를
    클릭하세요**.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image44.png)

6.  **Review and finish** 페이지에서 **Save and close**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image45.png)

7.  수집에는 다소 시간이 걸리며, 완료되면 데이터 세부 정보가 창에
    반영됩니다. 데이터 수집 프로세스가 완료되면 Teams AI 라이브러리 및
    Teams Toolkit를 사용하여 사용자 지정 엔진 에이전트 생성하기를 시작할
    수 있습니다.

\[!참고\] **참고:** 파일은 .txt, .md, .html, .pdf, .docx 또는 .pptx
형식이어야 하며 크기는 16MB로 제한됩니다.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image46.png)

## 연습 3: 사용자 지정 에이전트 생성하고 구성

### 작업 1: Teams Toolkit 확장 추가하기

1.  PC에서 **Visual Studio Code**를 여세요. Select **Trust**를 선택하여
    Visual Studio Code에서 제한된 모드를 제거하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

2.  VS 홈페이지의 왼쪽 탐색 창에서 **Extensions** 아이콘을 클릭하고
    +++**Teams Toolkit**+++을 검색한 후 **Install**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image48.png)

3.  설치가 완료되면 Visual Studio Code Activity Bar작업 표시줄에서
    ![](./media/image49.png)Teams Toolkit 아이콘을 선택하고 **Create a
    New App**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

4.  **Custom Engine Agent**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

5.  **Basic AI Chatbot**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image52.png)

6.  Programming language를 **JavaScript**로 선택하세요.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image53.png)

7.  **Azure OpenAI**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

8.  메모장에 복사하여 저장한 Azure 포털의 값을 입력하세요.

    - **Azure OpenAI key**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

- **Azure OpenAI endpoint**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image56.png)

- **Deployment name** - +++gpt-4o+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

9.  팀과 관련된 데이터를 포함할 새 폴더를 생성하고 **Browse**를 클릭하여
    해당 위치로 이동하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

10. 사용자 지정 엔진 에이전트의 이름으로 +++**TeamsContosoAgent**+++를
    입력하고 **Enter** 키를 선택하세요. 사용자 지정 엔진 에이전트는 몇
    초 안에 생성해집니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

11. Yes, I author를 선택하세요

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

**Take a tour of the source code**

이 사용자 지정 엔진 에이전트 \> Basic AI Chatbot템플릿의 내용을
살펴보세요.

[TABLE]

### 작업 2: 사용자 에이전트를 구성하기

사용자 지정 엔진 에이전트에 대한 프롬프트를 사용자 지정해 보겠습니다.

1.  src/prompts/chat/skprompt.txt로 이동하여 기존 코드를 아래 코드로
    바꾸세요. 업데이트 후 **ctrl+s**를 눌러 파일을 저장하세요.

> The following is a conversation with an AI assistant, who is an expert
> on answering questions over the given context.
>
> Responses should be in a short journalistic style with no more than 80
> words.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

2.  프롬프트/채팅 아래의 **config.json** 파일로 이동하세요. 기존 코드를
    다음 코드로 바꾸고 **endpoint**, **index_name** 및 **key** 값을
    **Azure AI Search** 리소스 세부 정보로 바꾸세요. 업데이트 후
    **ctrl+s**를 눌러 파일을 저장하세요.

> {
>
> "schema": 1.1,
>
> "description": "A bot that can chat with users",
>
> "type": "completion",
>
> "completion": {
>
> "completion_type": "chat",
>
> "include_history": true,
>
> "include_input": true,
>
> "max_input_tokens": 2800,
>
> "max_tokens": 1000,
>
> "temperature": 0.9,
>
> "top_p": 1.0,
>
> "presence_penalty": 0.6,
>
> "frequency_penalty": 0.0
>
> },
>
> "data_sources": \[
>
> {
>
> "type": "azure_search",
>
> "parameters": {
>
> "endpoint": "AZURE-AI-SEARCH-ENDPOINT",
>
> "index_name": "YOUR-INDEX_NAME",
>
> "authentication": {
>
> "type": "api_key",
>
> "key": "AZURE-AI-SEARCH-KEY"
>
> }
>
> }
>
> }
>
> \]
>
> }

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image63.png)

3.  src/app/app.js 파일로 이동하여 OpenAIModel 내에서 azureEndpoint 항목
    뒤에 다음 변수를 추가하세요.

+++azureApiVersion: '2024-02-15-preview',+++

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image64.png)

4.  관리자 권한으로 Powershell을 열고 다음 명령을 실행한 후 A를
    입력하세요.

5.  Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image65.png)

6.  **Visual Studio Code**로 돌아가서 왼쪽 창에서 **Run and Debug
    (Ctrl+Shift+D)**를 선택하세요. **Debug in Test Tool를** 선택하여
    디버깅을 시작하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image66.png)

7.  Windows 보안 경고가 표시되면 Allow access를 선택하새요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

8.  사용자 지정 엔진 에이전트는 브라우저에서 열리는 Teams App Test Tool
    내에서 실행됩니다.

![A black screen with white text AI-generated content may be
incorrect.](./media/image68.png)

9.  브라우저에서 새 탭이 열리고 Teams App Test Tool이 열리며 앱에서
    쿼리를 실행할 수 있습니다.

![A screenshot of a computer Description automatically
generated](./media/image69.png)

## 결론

이 실습을 완료함으로써 참가자는 Teams AI 라이브러리 및 Teams Toolkit를
사용하여 사용자 지정 AI 기반 챗봇을 빌드하고 배포하는 실습 경험을
얻었습니다. 여기에는 Azure OpenAI 리소스 설정, 데이터 스토리지 및 AI
검색 기능 통합, 컨텍스트 인식 상호 작용을 위한 챗봇 사용자 지정이
포함되었습니다. 이 연습을 통해 참가자는 비즈니스 요구 사항에 맞게 조정된
지능형 에이전트를 구성하고 조직 워크플로에 통합하여 Microsoft Teams 내의
최신 AI 기능을 효과적으로 활용하는 방법을 배웠습니다.

 
