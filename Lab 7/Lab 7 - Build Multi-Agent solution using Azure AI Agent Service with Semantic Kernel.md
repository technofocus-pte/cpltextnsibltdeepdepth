# 실습 7 - Semantic Kernel과 함께 Azure AI 에이전트 서비스를 사용하여 다중 에이전트 솔루션 빌드

Azure AI Agent Service를 통해 엔터프라이즈 지향 AI 에이전트를 구축할 수
있습니다.

**소개**

다음은 블로그 작성 시나리오를 소개합니다. 이 시나리오에는 두 개의 AI
에이전트가 포함되는데, 하나는 쓰기 지원을 위한 것이고 다른 하나는 콘텐츠
스토리지 및 관리를 위한 것입니다. 이러한 에이전트는 AutoGen 또는
Semantic Kernel을 사용하여 원활하게 오케스트레이션할 수 있습니다. 이
실습에서는 Semantic Kernel Orchestration을 사용합니다.

![A diagram of a diagram of a business AI-generated content may be
incorrect.](./media/image1.png)

## 목표:

개발자는 Azure AI Foundry SDK를 사용하여 Python 또는 C#을 사용하여 Azure
AI Agent Service를 기반으로 에이전트를 빠르게 빌드할 수 있습니다. 기업은
비즈니스에 따라 다양한 AI 에이전트를 갖게 될 것인데, 이러한 AI
에이전트를 워크플로에서 어떻게 결합해야 할까요? AutoGen 또는 Semantic
Kernel을 사용하여 AI 에이전트를 오케스트레이션해야 합니다. 이 실습에서는
Semantic Kernel을 사용하여 Azure AI 에이전트 서비스를 사용하는 다중
에이전트 솔루션을 개발합니다.

## 연습1: Azure AI Hub 리소스 및 프로젝트 생성하기

이 연습에서는 Azure Portal에서 허브를 생성한 후, Azure AI Foundry에서
프로젝트를 생성하고, 모델을 배포하고, 실행에 필요한 에이전트를
생성합니다.

1.  브라우저에서
    +++[\*\*https://portal.azure.com/\*\*++를](https://portal.azure.com/**+++)
    열고 **login credentials**을 사용하여 로그인한 후
    **Home** 페이지에서 **Azure AI Foundry**를 선택하세요.

    - User name – <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password – <+++@lab.CloudPortalCredential>(User1).Password+++

![image](./media/image2.png)

2.  **Use with AI Foundry** -\> **AI Hubs**를 선택하세요. **+
    Create** -\> **Hub**를 선택하세요.

![image](./media/image3.png)

3.  아래 세부 정보를 입력하고, 다른 기본값을 적용하고, **Review +
    create**를 선택하세요.

    - Subscription - **assigned subscription**을 선택하세요

    - Resource group – 할당된 Resource group (**ResourceGroup1**)을
      선택하세요

    - Region - @lab.CloudResourceGroup(ResourceGroup1).Location을
      선택하세요

    - Name - <+++hub@lab.LabInstance.Id>+++

![image](./media/image4.png)

![image](./media/image5.png)

4.  유효성 검사가 통과되면 **Create**를 선택하세요.

![image](./media/image6.png)

5.  배포가 완료되면 **Go to resource**를 클릭하세요.

![image](./media/image7.png)

6.  허브 리소스 페이지에서 **Launch Azure AI Foundry**를 선택하세요.

![image](./media/image8.png)

7.  시작된 허브 리소스에서 아래로 스크롤하여 **+ New project**를
    선택하세요.

![image](./media/image9.png)

![image](./media/image10.png)

8.  이름을 <+++multiagent@lab.LabInstance.Id>+++로 입력하고 **Create**를
    선택하세요.

![image](./media/image11.png)

9.  **Explore and experiment**을 닫으세요.

![image](./media/image12.png)

10. 생성된 프로젝트 페이지로 이동합니다..

![image](./media/image13.png)

11. 페이지를 아래로 스크롤하여 **Project connection string** 값을
    메모장에 복사하세요.

![image](./media/image14.png)

12. 왼쪽 창에서 아래로 스크롤하여 **Management Center**를 선택하세요.

![image](./media/image15.png)

13. 허브 리소스에서 **Connected resources**를 선택한 후, **+ New
    connection**을 클릭하여 Azure AI Foundry 리소스와의 연결을
    생성하세요.

![image](./media/image16.png)

14. 사용 가능한 외부 자산에서 **Azure AI Foundry**를 선택하세요.

![image](./media/image17.png)

15. 연결을 추가하기 위해 **Add connection**을 선택하세요.

![image](./media/image18.png)

![image](./media/image19.png)

16. 연결되면 **Close**를 클릭하세요. **Close** 버튼이 표시되지 않으면
    브라우저의 **zoom size**를 줄인 후 **Close**를 선택하세요.

![image](./media/image20.png)

17. 왼쪽 창에서 **Go to project**를 선택하세요.

![image](./media/image21.png)

18. 프로젝트 페이지에서 **API Key** 및 **Azure OpenAI endpoint** 의 값을
    복사하여 메모장에 저장하세요.

![image](./media/image22.png)

19. 왼쪽 창의 **Build and customize** 에서**Agents**를 선택하세요.
    **Azure AI Agent Service** 페이지에서 생성된 **Azure OpenAI
    Service** 를 선택한 후, **Let’s go**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

20. **gpt-4o-mini**를 선택하고 **Confirm**을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

21. 배포 이름을 +++**gpt-4o-mini**+++로 수락하고 Deployment type을
    **Standard**으로 선택하세요. 다른 기본값을 적용하고 **Deploy**를
    클릭하여 모델을 배포하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

22. 이제 Azure 리소스가 준비되었습니다.

## 연습 2: Multi Agent Orchestration

이 연습에서는 Visual Studio Code를 설정하고 실행에 필요한 필수 구성
요소를 설치합니다.

1.  VM에서 Visual Studio Code를 여세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

2.  **File -\> Open Folder**를 선택하고 **C:\LabFiles**에서
    **MultiAgent** 폴더를 선택한 후 **Select Folder**을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

3.  팝업에서 **Yes, I trust the authors**를 선택하세요.

![A screenshot of a computer error AI-generated content may be
incorrect.](./media/image30.png)

4.  노트북을 마우스 오른쪽 버튼으로 클릭하고 **Open in Integrated
    Terminal**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

5.  아래 명령을 차례로 실행하여 **nuget source**를 추가하세요.

+++dotnet nuget list source+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

> +++dotnet nuget add
> source <https://api.nuget.org/v3/index.json> --name nuget.org+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  아래 명령을 실행하여 dotnet interacrive를 설치하세요.

+++dotnet tool install --global Microsoft.dotnet-interactive --version
1.0.556801+++

![](./media/image34.png)

7.  +++pip install jupyter+++를 실행하고 Jupyter를 설치하세요.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image35.png)

8.  jupyter interactive에 대한 다음 명령을 실행하세요.

+++dotnet interactive jupyter install+++

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image36.png)

9.  **Terminal을 닫으세요**. **Visual Studio Code**의 왼쪽 창에서
    **Extensions** 을 선택하세요. +++**Jupyter**+++를 검색하고 선택하고
    **Install**을 클릭하고 Jupyter 확장을 설치하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

10. Visual Studio Code를 닫고 다시 여세요.

11. Notebook **AzureAIMultiAgentWithSK.ipynb**을 여세요. 열려면 **Select
    Kernel**을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

12. **Jupyter Kernel**을 선택하세요.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image39.png)

13. 다음 옵션 집합에서 **.NET(C#) dotnet**을 선택하세요.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image40.png)

14. **Security Alert**에서 **Allow access**를 선택하세요.

![A screenshot of a computer security alert AI-generated content may be
incorrect.](./media/image41.png)

15. 첫 번째 셀을 실행하여 필요한 모든 **패키지**를 **설치하세요**.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image42.png)

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image43.png)

16. 다음 셀을 실행하여 네임스페이스를 가져오세요.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image44.png)

17. 다음 셀에서 **deployment **변수 값이 생성한 **model**배포와 동일한지
    확인하세요. 바꾸세요,

    - Endpoint – **Azure OpenAI Endpoint**

    - Key – **API Key**

위의 두 값은 모두 Azure AI Foundry에서 프로젝트를 생성한 후 이전에
메모장에 저장했습니다.

값을 바꾼 후 셀을 **실행하세요**.

이렇게 하면 이러한 값이 추가로 사용할 해당 변수로 설정됩니다.

![A black screen with numbers AI-generated content may be
incorrect.](./media/image45.png)

18. 다음 셀은 새 **KernelBuilder** 인스턴스를 생성하고, 마지막 단계의
    변수를 입력으로 사용하여 Kernel에 AI 서비스 공급자로 **Azure OpenAI
    Chat Completion**을 추가하고, **Build**()를 호출하여 Kernel
    인스턴스를 생성하세요.

이를 **실행하여** Kernel 인스턴스를 생성하세요.

![A screen shot of a computer code AI-generated content may be
incorrect.](./media/image46.png)

19. 다음 셀을 실행하여 필요한 **Azure** 패키지를 설치하고 다음 셀을
    실행하여 참조를 가져오세요.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image47.png)

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image48.png)

20. 다음 셀의 클래스는 ** custom HTTP pipeline policy for Azure
    SDK requests을** 정의 하고 나가는 모든 요청에 사용자 지정 HTTP
    헤더(x-ms-enable-preview: true)를 추가합니다. **실행하세요**.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image49.png)

## 연습 3: 블로그 에이전트 저장하기

1.  다음 셀은 **Azure AI Projects and the Semantic Kernel**을 사용하여
    **save blog content ** 메서드를 구현하는 **SavePlugin** 클래스를
    정의하세요.

    - **blog content**를 입력으로 받습니다.

    - **Azure AI Projects** 와 상호 작용 하여 AI 에이전트를 생성합니다.

    - Python 코드를 생성하고 실행하여 콘텐츠를 **Markdown**(.md) 파일로
      저장합니다.

    - 생성된 파일을 로컬에 다운로드하고 저장합니다.

    - **확인** 메시지("Saved")를 반환합니다.

이 셀을 실행하려면 **Your Connection String**을 이전에 메모장에 저장한
**Project Connection String**로 바꾸세요. Azure AI Foundry 포털의
프로젝트 개요 페이지에서 액세스할 수 있습니다.

연결 문자열을 바꾼 후 **Execute 을** 클릭하세요.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image50.png)

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image51.png)

2.  다음 셀은 특정 값 저장을 사용하여 **constants** 를 초기화합니다.
    **그것을 실행하세요**. 이러한 상수는 다음 셀에서 사용됩니다.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image52.png)

3.  다음 셀은 **save_blog_agent**라는 **ChatCompletionAgent**를
    생성합니다. 에이전트를 생성하려면 실행하세요.

![A computer screen shot of a computer program AI-generated content may
be incorrect.](./media/image53.png)

## 연습 4: Writer agent

1.  Writer 특정 값으로 상수를 선언하는 노트북의 다음 셀을 실행하세요.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image54.png)

2.  다음 셀은 Microsoft Semantic Kernel 및 Azure OpenAI 채팅 모델을
    사용하여 블로그 게시물 작성을 담당하는 write-blog_content라는
    **ChatCompletionAgent**를 만듭니다. 에이전트를 생성하려면
    실행하세요.

![A computer screen shot of a black screen AI-generated content may be
incorrect.](./media/image55.png)

3.  다음 셀의 코드는 **SavePlugin**을 **save_blog_agent** 내에서 함수로
    사용할 수 있도록 합니다. **SavePlugin**에서 **Kernel Plugin** 을
    생성합니다. **Agent's Kernel** 에 플러그인을 **추가**합니다. AI는
    저장 관련 요청을 감지하면 **SavePlugin.Save** 함수를 호출합니다.

이를 실행하여 Kernel Plugin을 생성하세요.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image56.png)

4.  다음 셀에는 **ApprovalTerminationStrategy** 클래스에 대한 코드가
    포함되어 있습니다

5.  이 **사용자 지정 종료 전략은 AI 에이전트의 실행을 중지해야 하는
    시기**를 결정하는 데 사용됩니다. **그것을 실행하세요**.

![A computer screen with text on it AI-generated content may be
incorrect.](./media/image57.png)

6.  다음 셀에는 **AgentGroupChat** 코드가 포함되어 있습니다. 이렇게 하면
    두 개의 **AI** 에이전트**(write_blog_agent 및 save_blog_agent)**가
    협업하는 **multi-agent chat** 시스템이 생성됩니다.
    **ApprovalTerminationStrategy**를 사용하여 채팅을 중지해야 하는
    시점을 결정합니다.

**save_blog_agent** 만이 종료를 승인할 수 있습니다.

이를 **실행하여** 다중 에이전트 채팅을 구성하세요.

![A computer screen shot of a program AI-generated content may be
incorrect.](./media/image58.png)

7.  다음 셀에는 에이전트에 대한 지침이 포함되어 있습니다. **다중
    에이전트 채팅 시스템에 사용자 메시지를 추가하여** AI에게
    **GraphRAG에서 정보를 검색하고, 블로그를 작성하고, 저장하도록
    지시합니다**.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image59.png)

8.  다음 셀을 실행하세요. 이는 다중 에이전트 채팅에서 **AI가 생성한
    응답이 스트리밍될 때 반복됩니다.**

실행시 블로그를 작성하고 저장합니다.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image60.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

## 요약

Semantic Kernel과 함께 Azure AI 에이전트 서비스를 사용하여 다중 에이전트
시스템을 구현했습니다.
