# 실습 5 - Azure AI Foundry 및 검색 통합을 사용하여 사용자 지정 AI 에이전트 생성하기

**에상 소요 시간: 45분**

## 목표

이 실습의 목표는 참가자가 Azure AI 서비스 및 검색 통합을 사용하여 AI
기반 에이전트를 빌드하도록 안내하는 것입니다. Retrieval Augmented
Generation (RAG)는 사용자 지정 데이터 소스의 데이터를 generative AI
모델에 대한 프롬프트로 통합하는 애플리케이션을 구축하는 데 사용되는
기술입니다. RAG는 언어 모델을 사용하여 입력을 해석하고 적절한 응답을
생성하는 채팅 기반 애플리케이션인 generative AI 앱을 개발하는 데
일반적으로 사용되는 패턴입니다. 참가자는 Azure AI Foundry 포털을
사용하여 사용자 지정 데이터를 generative AI 프롬프트 흐름에 통합하는
방법을 배웁니다.

## 솔루션

이 실습에서는 Azure AI 서비스를 고급 검색 기능과 통합하여 강력하고
지능적인 솔루션을 생성하는 데 중점을 둡니다. AI 기반 에이전트를
구성하고, 원활한 데이터 검색을 가능하게 하고, 상황에 맞는 응답을
제공하는 것을 강조합니다. 이 솔루션은 AI와 검색 통합을 활용하여
워크플로를 간소화하고, 의사 결정을 개선하고, 직관적이고 효율적인 상호
작용을 통해 사용자 참여를 향상시키는 것을 목표로 합니다.

## 작업 1: Azure AI Search 리소스 생성하기

1.  웹 브라우저에서
    +++[https://portal.azure.com++에서](https://portal.azure.com+++/)
    Azure Portal을 열고 다음을 사용하여 **Sign in**하세요.

- Username - <+++@lab.CloudPortalCredential>(User1).Username+++

- Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer Description automatically
generated](./media/image1.png)

2.  홈페이지에서 **+ Create a resource**를 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image2.png)

3.   검색바에서 +++**Azure AI Search**+++를 검색하고 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image3.png)

4.  **Create** 옆에 있는 드롭다운을 선택하고 **Azure AI Search**를
    선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image4.png)

5.  Create a search service 페이지에서 다음 세부 정보를 입력하고
    **Review + create**를 클릭하세요.

    - **Subscription**: 드롭다운에서 Azure subscription을 선택하세요.

    - **Resource group**: 할당된 구독된 (ResourceGroup1) Resource
      group을 선택하세요

    - **Service name**: <+++aisearch@lab.LabInstance.Id>+++

    - **Location**: @lab.CloudResourceGroup(ResourceGroup1).Location을
      선택하세요

    - **Pricing tier**: Standard

![A screenshot of a computer Description automatically
generated](./media/image5.png)

6.  설정을 검토하고 **Create**를 클릭하세요.

![A screenshot of a search service Description automatically
generated](./media/image6.png)

7.  Azure AI Search 리소스 배포가 완료될 때까지 기다리세요.

![A screenshot of a computer Description automatically
generated](./media/image7.png)

## 작업 2: Azure AI Hub 리소스 및 프로젝트를 생성하기

1.  Azure portal **Home** 페이지에서 **Azure AI Foundry** 를 선택하세요.

![image](./media/image8.png)

2.  **Use with AI Foundry** -\> **AI Hubs**를 선택하세요. **+
    Create** -\> **Hub**를 선택하세요

![image](./media/image9.png)

3.  아래 세부 정보를 입력하고, 다른 기본값을 적용하고, **Review +
    create**를 선택하세요.

    - Subscription - **assigned subscription**을 선택하세요

    - Resource group – 할당된 Resource group (**ResourceGroup1**)을
      선택하세요

    - Region - @lab.CloudResourceGroup(ResourceGroup1).Location을
      선택하세요

    - Name -
      +++[**hub@lab.LabInstance.Id**](mailto:hub@lab.LabInstance.Id)+++

![image](./media/image10.png)

![image](./media/image11.png)

4.  유효성 검사가 통과되면 **Create**를 선택하세요.

![image](./media/image12.png)

5.  배포가 완료되면 **Go to resource**를 클릭하세요.

![image](./media/image13.png)

6.  허브 리소스 페이지에서 **Launch Azure AI Foundry**를 선택하세요.

![image](./media/image14.png)

7.  시작된 허브 리소스에서 아래로 스크롤하여 **+ New project**를
    선택하세요.

![image](./media/image15.png)

![image](./media/image16.png)

8.  이름을
    +++[**ragpfproject@lab.LabInstance.Id**](mailto:ragpfproject@lab.LabInstance.Id)+++로
    입력하고 **Create**를 선택하세요.

![image](./media/image17.png)

9.  Explore and experiment 팝업을 닫으세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image18.png)

10. You will land in the created project page.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

## 작업 3: 모델을 배포하기

솔루션을 구현하려면 두 가지 모델이 필요합니다:

- 효율적인 인덱싱 및 처리를 위해 텍스트 데이터를 벡터화하는 임베딩 모델.

- 데이터를 기반으로 질문에 대한 자연어 응답을 생성할 수 있는 모델.

1.  왼쪽 창의 **My assets**에서 **Models + endpoints를** 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

2.  **Manage deployments of your models and services
    page**에서 **+Deploy model**을 클릭하고 **Deploy base model**을
    선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image21.png)

3.  **Select a model** 페이지에서
    +++**text-embedding-ada-002**+++ 모델을 검색하고 선택하고
    **Confirm**을 클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image22.png)

4.  **Deploy model text-embedding-ada-002** 창에서 **Deployment name**에
    대해 미리 채워진 값을 수락하고 **Deployment type**을
    **standard**으로 선택하세요. **Customize**를 클릭하고 Deploy model
    wizard에서 다음 세부 정보를 입력하세요.

![A screenshot of a computer Description automatically
generated](./media/image23.png)

- **Model version**: 기본 버전을 선택하세요

- **AI resource**: 이전에 만든 리소스(즉, 드롭다운에 나열되는 리소스)를
  선택하세요.

- **Tokens per Minute Rate Limit (thousands)**: 5K

- **Content filter**: DefaultV2

- **Enable dynamic quota**: Disabled

![A screenshot of a computer Description automatically
generated](./media/image24.png)

![A screenshot of a computer Description automatically
generated](./media/image25.png)

![A screenshot of a computer Description automatically
generated](./media/image26.png)

5.  이전 단계를 반복하여 배포 이름이 gpt-4o인 +++**gpt-4o**+++ 모델을
    배포하세요.

![A screenshot of a computer Description automatically
generated](./media/image27.png)

6.  이제 두 가지 배포가 준비되었습니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

\[!참고\] **참고:**  Tokens Per Minute (TPM)을 줄이면 사용 중인 구독에서
사용할 수 있는 할당량을 과도하게 사용하지 않도록 방지할 수 있습니다. 이
연습에서 사용되는 데이터에는 5,000TPM이면 충분합니다.

## 작업 4: 프로젝트에 데이터 추가하기

Copilot의 데이터는 가상의 여행사 *Margie's Travel*에서 제공하는 PDF
형식의 여행 브로셔 세트로 구성됩니다. 프로젝트에 추가해 보겠습니다.

1.  왼쪽 창의 **My assets**에서 **Data + indexes**를 선택하세요. **+ New
    data**를 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image29.png)

2.  **Add your data** wizard에서, 드롭다운에서 **Upload
    files/folders**를 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image30.png)

3.  **Upload folder**를 선택하고 **C:\LabFiles**에서
    **brochures** 폴더를 선택하고 **Upload**를 클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image31.png)

![A screenshot of a computer Description automatically
generated](./media/image32.png)

4.  폴더가 업로드될 때까지 기다렸다가 여러 .pdf 파일이 포함되어 있는지
    확인하세요. 파일이 모두 업로드되면 **Next** 을 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image33.png)

5.  Name and finish의 다음 페이지에서 데이터 이름을
    +++[**data@lab.LabInstance.Id**](mailto:data@lab.LabInstance.Id)+++로
    입력하고 **Create**를 클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image34.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

## 작업 5: 데이터에 대한 인덱스 생성하기

이제 프로젝트에 데이터 원본을 추가했으므로 이를 사용하여 Azure AI Search
리소스에 인덱스를 생성할수 있습니다.

1.  **Data + indexes** 페이지에서 **Indexes** 탭을 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image36.png)

2.  **Indexes** 탭에서 새 인덱스를 추가하기 위해 **+ New index**를
    클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image37.png)

3.  아래 세부 정보를 입력하고 **Next**을 클릭하세요.

    - **Data source** - **Data in Azure AI Foundry**를 선택하세요

나열된 **data source를** 선택하고 **Next**을 클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image38.png)

4.  Create a vector index – Index configuration 페이지에 아래 세부
    정보를 입력하고 **Next**를 클릭하세요.

    - **Select Azure AI Search service**: **AzureAISearch**를 선택허세요

    - Vector index - +++**brochures-index**+++

    - **Virtual machine**: **Auto select**를 선택하세요

![A screenshot of a computer Description automatically
generated](./media/image39.png)

5.  Create a vector index – Search settings 페이지에서

**Vector settings** - **Add vector search to this search resource**를
선택하세요

다른 기본값을 적용하고 **Next**을 선택하세요.

![A screenshot of a search box Description automatically
generated](./media/image40.png)

6.  **Review and finish** 페이지에서 세부 정보를 검토하고 **Create
    vector index**를 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image41.png)

7.  인덱싱 프로세스가 완료될 때까지 기다리며 몇 분 정도 걸릴 수
    있습니다. 인덱스 생성 작업은 다음 작업으로 구성됩니다:

    - 크랙, 청크 및 브로셔 데이터에 텍스트 토큰을 포함

    - Azure AI Search 인덱스를 생성

    - 인덱스 자산을 등록

![A screenshot of a computer error Description automatically
generated](./media/image42.png)

![A screenshot of a computer program Description automatically
generated](./media/image43.png)

## 작업 6: 인덱스 테스트하기

RAG 기반 프롬프트 플로우에서 인덱스를 사용하기 전에 generative AI 응답에
영향을 미치는 데 사용할 수 있는지 확인하겠습니다.

1.  왼쪽 창에서 **Playgrounds**를 선택하고 **Chat Playground**를
    선택하세요.

![A screenshot of a chat Description automatically
generated](./media/image44.png)

2.  **Show setup**이 기본적으로 표시되지 않는 경우 클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image45.png)

3.  **gpt-4o** 모델 배포가 선택되어 있는지 확인하세요. 그런 다음 메인
    채팅 세션 패널에서 프롬프트 +++**Where can I stay in New
    York?**+++를 제출하세요

![A screenshot of a computer program Description automatically
generated](./media/image46.png)

![A screenshot of a chat Description automatically
generated](./media/image47.png)

4.  인덱스의 데이터가 없는 모델의 일반적인 답변이어야 하는 응답을
    검토하세요.

5.  Setup 창에서 **Add your data** 필드를 확장하고, **brochures-index**
    프로젝트 인덱스를 선택하고, **hybrid (vector + keyword)** 검색
    유형을 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image48.png)

\[!참고\] **참고:** 일부 사용자는 새로 생성된 인덱스를 즉시 사용할 수
없다는 것을 발견하고 있습니다. 일반적으로 브라우저를 새로 고치면 도움이
되지만 인덱스를 찾을 수 없는 문제가 계속 발생하는 경우 인덱스가 인식될
때까지 기다려야 할 수 있습니다.

6.  이렇게 데이터 소스를 추가하면 새 세션이 시작됩니다. 이 작업이
    완료되면 프롬프트를+++ Where can I stay in New York?+++ 다시
    제출하세요

![A screenshot of a chat Description automatically
generated](./media/image49.png)

7.  응답을 검토하고 이제 응답이 인덱스의 데이터를 기반으로 한다는 점에
    유의하세요.

![A screenshot of a chat Description automatically
generated](./media/image50.png)

## 작업 7: 프롬프트 플로우에서 인덱스 사용하기

벡터 인덱스가 Azure AI Foundry 프로젝트에 저장되어 프롬프트 플로우에서
쉽게 사용할 수 있습니다.

1.  왼쪽 탐색 창에서 **Build and customize**에서 **Prompt flow**를
    선택한 후 **Create**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

2.  **Multi-Round Q&A on Your Data** 아래에서 **Clone**를 선택하세요.

![A screenshot of a computer Description automatically
generated](./media/image52.png)

3.  폴더 이름을 +++**brochure-flow**+++ 로 정하고 **Clone**를
    클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image53.png)

\[!참고\] **참고:** 사용 권한 오류가 발생하는 경우 2분 후에 새 이름으로
다시 시도하면 플로우가 복제됩니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

4.  프롬프트 흐름 디자이너 페이지가 열리면 **brochure-flow**를
    검토하세요. 해당 그래프는 다음 이미지와 유사해야 합니다:

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

![A screenshot a a prompt flow graph](./media/image56.png)

사용 중인 샘플 프롬프트 플로우는 사용자가 채팅 인터페이스에 텍스트
입력을 반복적으로 제출할 수 있는 채팅 애플리케이션에 대한 프롬프트
논리를 구현합니다. 대화 기록은 유지되며 각 반복의 컨텍스트에 포함됩니다.
프롬프트 흐름은 일련의 *도구*를 조정하여 다음을 수행하세요.

- 채팅 입력에 기록을 추가하여 상황에 맞는 질문 형식의 형태로 프롬프트를
  정의.

- 인덱스를 사용하여 컨텍스트를 검색하고 질문에 따라 선택한 쿼리 유형을
  검색.

- 인덱스를 사용하여 프롬프트 컨텍스트를 생성하고 질문을 보강.

- 시스템 메시지를 추가하고 채팅 기록을 구조화하여 프롬프트 변형을 생성.

- 프롬프트를 언어 모델에 제출하여 자연어 응답을 생성.

5.  **Start compute session** 버튼을 사용하여 흐름에 대한 런타임
    컴퓨팅을 시작하세요.

런타임이 시작될 때까지 기다리세요. 이는 프롬프트 흐름에 대한 컴퓨팅
컨텍스트를 제공합니다. 기다리는 동안 **Flow** 탭에서 흐름의 도구에 대한
섹션을 검토하세요.

![A screenshot of a computer screen Description automatically
generated](./media/image57.png)

6.  **Inputs** 섹션에서 입력에 다음이 포함되는지 확인하세요:

    - **chat_history**

    - **chat_input**

이 샘플의 기본 채팅 기록에는 AI에 대한 몇 가지 대화가 포함되어 있습니다.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image58.png)

7.  **Outputs** 섹션에서 출력에 다음이 포함되어 있는지 확인하세요:

    - **chat_output** with value ${chat_with_context.output}

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

8.  **modify_query_with_history** 섹션에서 다음 설정을 선택하세요
    (나머지는 그대로 두고):

    - **Connection**:  나열되는 AI 허브에 대한 **Azure OpenAI
      resource 를** 선택하세요.

    - **Api**: **chat**를 선택하세요

    - **deployment_name**: **gpt-4o**를 선택하세요

    - **response_format**: **{“type”:”text”}**를 선택하세요

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

9.  연산 세션이 시작되면, **lookup** 섹션에서 다음 파라미터 값들을
    설정하세요:

    - **mlindex_content**: *빈 필드를 선택하여 Generate 창을 여세요.*

      - **index_type**: **Registered Index**를 선택하세요

 

- **mlindex_asset_id**: **brochures-index:1**을 선택하세요

![A screenshot of a computer Description automatically
generated](./media/image61.png)

![A screenshot of a computer Description automatically
generated](./media/image62.png)

Lookup 섹션으로 돌아가서 아래 세부 정보를 입력하세요.

- **queries**: ${modify_query_with_history.output}

- **query_type**: Hybrid (vector + keyword)

- **top_k**: 2

![A screenshot of a computer Description automatically
generated](./media/image63.png)

10. **generate_prompt_context** 섹션에서 Python 스크립트를 검토하고 이
    도구에 대한 **inputs** 에 다음 매개 변수가 포함되어 있는지
    확인하세요:

    - **search_result** *(object)*: ${lookup.output}

![A screenshot of a computer Description automatically
generated](./media/image64.png)

11. **Prompt_variants** 섹션에서 Python 스크립트를 검토하고 이 도구에
    대한 **inputs** 에 다음 매개 변수가 포함되어 있는지 확인하세요:

    - **contexts** *(string)*: ${generate_prompt_context.output}

    - **chat_history** *(string)*: ${inputs.chat_history}

    - **chat_input** *(string)*: ${inputs.chat_input}

![A screenshot of a chat Description automatically
generated](./media/image65.png)

12. **chat_with_context** 섹션에서 다음 설정을 선택하세요 (다른 설정은
    그대로 두고):

    - **Connection**: **Azure OpenAI resource**를 선택하세요

    - **Api**: Chat

    - **deployment_name**: gpt-4o

    - **response_format**: {“type”:”text”}

이 도구에 대한 **inputs** 에 다음 매개 변수가 포함되어 있는지
확인하세요.

- **prompt_text** *(string)*: ${Prompt_variants.output}

![A screenshot of a computer Description automatically
generated](./media/image66.png)

13. 도구 모음에서 **Save** 버튼을 선택하여 프롬프트 흐름에서 도구에 대한
    변경 사항을 저장하세요.

![A screenshot of a computer Description automatically
generated](./media/image67.png)

14. 도구 모음에서 **Chat**을 선택하세요. 샘플 대화 기록과 샘플 값을
    기반으로 이미 채워진 입력이 있는 채팅 창이 열립니다. 무시할 수
    있습니다.

![A screenshot of a computer Description automatically
generated](./media/image68.png)

15. 채팅 창에서 기본 입력을 +++ Where can I stay in London?+++ 질문으로
    바꾸고 제출하세요.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image69.png)

16. 응답은 인덱스의 데이터를 기반으로 합니다.

17. 플로우의 각 도구에 대한 출력을 검토하세요.

![A screenshot of a computer Description automatically
generated](./media/image70.png)

18. 채팅 창에 질문을 +++ What can I do there?+++ 입력하세요

19. 인덱스의 데이터를 기반으로 해야 하며 **chat history**를 고려해야
    하는 응답을 검토합니다. (그래서 "**there**"는 "in London"으로
    이해됩니다).

![A screenshot of a chat Description automatically
generated](./media/image71.png)

20. 플로우의 각 도구에 대한 출력을 검토하고, 플로우의 각 도구가 상황에
    맞는 프롬프트를 준비하고 적절한 응답을 얻기 위해 입력에 대해 어떻게
    작동했는지 확인하세요.

## 작업 8: 리소스 정리하기:

1.  Azure portal
    (+++[https://portal.azure.com+++](https://portal.azure.com+++/))에서**ResourceGroup1**
    (사용자에게 할당된 것)를 선택하세요.

2.  그 아래에 있는 모든 리소스를 선택하고 **Delete**를 클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image72.png)

3.  +++**delete**+++를 입력하고 **Delete **버튼을 클릭하여 삭제를
    확인하세요. 삭제 확인 대화 상자에서 **Delete** 를 클릭하세요.

![A screenshot of a computer Description automatically
generated](./media/image73.png)

4.  삭제 확인 메시지를 통해 리소스가 삭제되었는지 확인하세요.

![A screenshot of a computer screen Description automatically
generated](./media/image74.png)

## 요약

이 실습에서는 **Azure AI Foundry**의 사용자 고유의 데이터를 사용하는
사용자 지정 에이전트를 생성하는 방법을 배웠습니다.
