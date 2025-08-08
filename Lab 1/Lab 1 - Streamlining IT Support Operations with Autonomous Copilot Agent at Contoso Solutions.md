# 실습 1 - Copilot Studio를 사용하는 Autonomous Copilot Agent로 IT 지원 운영 간소화

**예상 소요 시간: 60분**

## 목표

이 실습의 목표는 참가자가 자율적인 Copilot 에이전트를 생성하고 Contoso
Solutions에서 IT 지원 작업을 간소화할 수 있도록 하는 것입니다. 참가자는
Microsoft Copilot Studio를 설정하고, IT 지원 에이전트를 구성하고, Power
Apps 및 Dataverse를 통합하고, 기술 자료로 봇의 기능을 향상하고, Power
Automate를 사용하여 티켓 생성을 자동화하는 방법을 배웁니다. 이 실습을
통해 사용자는 IT 워크플로우를 개선하고, 수동 작업을 줄이고, 지원
효율성을 높일 수 있는 기술을 습득할 수 있습니다.

## 솔루션

참가자는 Microsoft Copilot Studio를 사용하여 사용자 지정된 Contoso IT
지원 에이전트를 생성하고, 일반적인 IT 문제를 처리하도록 구성하고, 지원
데이터를 저장하기 위해 Dataverse와 통합합니다. 개발 환경을 설정하고,
지식 소스를 추가하고, 더 나은 사용자 상호 작용을 위해 봇의 대화 흐름을
구체화합니다. 참가자는 Power Apps를 활용하여 Dataverse 테이블을 생성하고
IT 지원 기록을 관리합니다. Power Automate를 사용하여 해결되지 않은
문제에 대한 티켓 생성 및 이메일 알림을 자동화합니다. 마지막으로,
참가자는 에이전트를 테스트하여 문제 해결의 정확성과 워크플로 자동화를
검증하여 원활한 IT 지원 운영을 보장합니다.

## 연습 1: Power Apps 시작하기

이 연습에서는 참가자에게 Power Apps 및 Dataverse를 소개합니다. 목표는
Power Apps에 로그인하고, 작업 환경을 설정하고, Excel 파일에서 데이터를
가져와서 Dataverse 테이블을 생성하는 것입니다. 참가자는 데이터 기반
애플리케이션 작업에 필요한 필수 기술을 배웁니다.

### 작업 1: Power Apps로 로그인하기

1.  Lab VM에서 브라우저를 여세요.

2.  Power apps
    웹사이트+++<https://www.microsoft.com/en-us/power-platform/products/power-apps+++> 로
    이동하고 **Try for Free** 버튼을 클릭하세요.

![](./media/image1.png)

3.  이메일 필드에**Resources** 탭의 **Office 365 Tenant**섹션에서
    **Administrative Username** 를 입력하고 **checkbox**를
    **select**하고 **Start free** 버튼을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

4.  **Administrative Password**를 입력하면 Power Apps Home 페이지로
    이동합니다.

5.  Stay Signed in 대화 상자에서 **Yes**를 선택하고 Save password
    프롬프트에서 **Got it**을 선택하고 Sign in to Microsoft Edge
    팝업에서 **No, Thanks**를 선택하세요.

\[!참고\] **참고:** 사용자 이름, 비밀번호나 로그인할 정보를 입력하려는
메시지가 다시 표시되면 동일한 정보를 제공하고 로그인하세요.

### 작업 2: Dataverse 테이블을 설정하기

1.  **Dev One** 환경이 선택되었는지 확인하세요. 아직 수행하지 않은 경우
    선택하세요.

![](./media/image3.png)

2.  왼쪽 탐색바에서 **Tables**를 선택하세요. 테이블 섹션 상단 표시줄에서
    **+ New table**를 클릭하고 **Create new tables**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

3.  새 테이블을 생성하려면 **Import an Excel file or CSV** 옵션을
    선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image5.png)

4.  **Select form device** 옵션을 클릭하고 **C:\LabFiles** 폴더에서
    **Support Ticket** excel 파일을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

5.  테이블을 선택하고 **View data**를 선택하고 테이블을 보세요.

\[!참고\] **참고:** 이 경우 테이블 이름은 *Employee Technical Support
Record*입니다. 이름은 각 실행에 따라 달라질 수 있습니다. 나중에 참조할
수 있도록 테이블 이름을 저장하세요. 열 이름도 실행에서 달라질 수
있습니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

6.  테이블 데이터를 이동하고 **Technical Issue Description** 필드 옆에
    있는 드롭다운을 선택하고 **Edit column**을 선택하세요. 데이터
    유형을 **Text** 🡪 **Multiple line** 🡪 **Plain** Text를 설정하고
    **Update**를 클릭하세요. 열 이름은 경우에 따라 다를 수 있습니다.

\[!참고\] **참고:** **column name might be slightly different**하지만
Copilot에서 생성되었기 때문에 문제 설명과 유사한 것입니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

7.  **Current Status** 필드 옆에 있는 드롭다운을 선택하세요. **Edit
    column**을 선택하고 Choices를 +++**Unresolved**+++,
    +++**Resolved**+++, +++**Processing**+++로 설정하세요. Default
    choice를 **Unresolved**로 설정하고 **Update**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

8.  오른쪽 상단에서 테이블을 저장하려면 **Save and exit**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

**결론**

이 연습을 완료하면 참가자는 다음을 배우게 됩니다:

- Office 365 관리자 테넌트 자격 증명을 사용하여 Power Apps에 액세스하고
  탐색하는 방법.

- 데이터를 가져와서 Dataverse 테이블을 생성하고 구성하는 단계.

- 앱 개발 워크플로를 지원하기 위한 환경 설정에 대한 실용적인 지식.

## 연습 2: Contoso IT Support Agent를 생성하기

이 연습에서는 Microsoft Copilot Studio에 로그인하고 Contoso의 IT 지원
작업에 맞게 조정된 사용자 지정 Copilot 에이전트를 생성하는 데
집중합니다. 참가자는 Copilot Studio를 탐색하고, 환경을 구성하고, AI 기반
에이전트를 구축하여 IT 워크플로를 간소화하는 실습 경험을 얻을 수
있습니다.

### 작업 1: Microsoft Copilot Studio를 로그인하기

1.  브라우저에서 url
    +++[https://copilotstudio.microsoft.com+++](https://copilotstudio.microsoft.com+++/)로
    이동하세요.

2.  아래 스크린샷과 같이 **Setting up your copilot**이라 표시되면 오른쪽
    상단 메뉴에서 **Environments**를 선택하고 **Dev One**을 선택하세요.
    그렇지 않으면 이 단계를 무시하고 3 단계를 계속하세요.

![image](./media/image12.png)

3.  Copilot Studio 체험판을 시작하려면 **Start free trial** 을
    클릭하세요.

![](./media/image13.png)

### 작업 2: Contoso IT Support Agent를 생성하고 구성하기

1.  이전 작업의 2단계가 완료되면 이 단계를 무시하세요. 그렇지 않으면 이
    단계를 수행하세요. 오른쪽 상단의 Copilot Studio 홈 섹션에서
    **environment**을 선택하고 **DevOne** 환경을 선택하세요.

![](./media/image14.png)

2.  Welcome copilot studio 탭에서 앞으로 이동하려면 **Skip**을
    클릭하세요.

![](./media/image15.png)

3.  왼쪽 탐색 바에서**Create**를 선택하고 새 에이전트를 생성하려면 **New
    agent**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

4.  오른쪽 상단에서 **Skip to configure** 버튼을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

5.  아래와 같이 에이전트의 **Name, Description and Instruction**을
    입력하고 **Create** 버튼을 클릭하세요.

> **Name:** +++Contoso IT Support Agent+++
>
> **Description:** +++Create a Contoso IT Support Agent which transforms
> IT support at Contoso Solutions by providing instant troubleshooting
> for common issues, automating ticket creation for unresolved problems,
> and storing all interactions in Dataverse. This solution enhances
> response times, reduces manual workloads, and boosts employee
> productivity.+++
>
> **Instruction:** +++Create the Copilot Agent and configure it to
> handle IT support operations. Add a knowledge source containing
> solutions for common IT issues like hardware troubleshooting,
> connectivity, and software glitches. Set up a trigger to detect
> incoming emails from employees describing unresolved issues. Create an
> action to save these technical issues into a Dataverse table, ensuring
> all details are stored for tracking and reporting. Test the agent to
> validate its troubleshooting accuracy and ticket automation workflow
> before deployment.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image18.png)

6.  Contoso IT Support Agent의 개요 페이지에서 에이전트의 orchestrator를
    **Enable**하세요.

![](./media/image19.png)

7.  에이전트의 개요 페이지에서 “**Allow the AI to use its own general
    knowledge**” 옵션을 **Disable**하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

8.  에이전트의 오른쪽 상단에서 **Settings** 버튼을 클릭하세요.

![](./media/image21.png)

9.  **Generative AI** 섹션으로 이동하고 **Generative**를 선택하세요.
    Content moderation을 **Medium**으로 설정하고 설정을
    저장하려면**Save**를 클릭하세요.

![](./media/image22.png)

**결론**

이 연습을 완료하면 참가자는 다음을 배우게 됩니다:

- Microsoft Copilot Studio에 액세스하고 설정하는 방법.

- 사용자 지정 Copilot 에이전트를 생성하고 구성하는 단계.

- 에이전트에 대한 생성 AI 및 오케스트레이터 설정을 사용하도록 설정하는
  실용적인 기술.

- 티켓 생성을 자동화하고 문제 해결을 위해 AI를 활용하여 IT 운영을
  개선하는 방법.

## 연습 3: Bot 기술을 강화하기

이 연습에서는 기술 자료를 추가하고 상호 작용을 개선하기 위해 봇 항목을
사용자 지정하여 Contoso IT 지원 에이전트의 기능을 향상시키는 데 중점을
둡니다. 참가자는 봇의 응답을 구체화하고 사용자의 문제 해결 및
에스컬레이션을 효과적으로 지원하는지 확인합니다.

### 작업 1: Knowledge Base를 추가하기

1.  Contoso agent 개요 페이지에서 아래로 스크롤하여 **+ Add
    Knowledge** 버튼을 클릭하세요.

![](./media/image23.png)

2.  **C:\LabFiles** 폴더에서 실습 파일 **Contoso Common IT
    Issue.docx**을 추가하려면 **Upload file** 을 선택하고 파일을
    저장하려면 **Add**를 클릭하세요.

![image](./media/image24.png) ![image](./media/image25.png)

3.  다시 한 번 에이전트 개요 페이지로 이동하고 아래로 스크롤하고 **+ Add
    knowledge**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

4.  **Dataverse (preview)** 옵션을 데이터 소스로 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

5.  오른쪽 상단 모서리 검색 창에서 +++**Employee**+++를 입력하여
    검색하고 **Employee Technical Support Record** 테이블을 선택하세요.
    지식 소스를 추가하려면 **Next, Next** 및 **Add** 버튼을 클릭하세요.

**참고:**  Copilot에서 생성한 테이블 이름이므로 **table name might be
different**입니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image29.png)

\[!알림\] **중요:** 지식 페이지에서 추가된 지식 소스가 성공적으로
업로드되었는지 확인합니다. 이 작업은 일반적으로 완료하는 데 10-15분 정도
걸립니다.

### 작업 2: Conversation Start Topic을 사용자 지정하기

1.  상단 표시줄 옵션에서 **Topics** -\> **System**을 클릭하고
    **Conversation Start** topic을 클릭하고 여세요.

![image](./media/image30.png)

2.  아래로 스크롤하여 메시지 노드로 이동하세요. 아래와 같이 봇 이름 뒤의
    메시지를 업데이트하세요:

Hello. I’m Bot Name, a virtual assistant. +++How can I help you?+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

3.  상단에서 주제를 저장하려면 **Save**를 클릭하세요.

![](./media/image32.png)

### 작업 3: Fallback Topic을 업데이트하기

1.  상단 바 옵션에서 **Topics** -\> **System**을 클릭하고
    **Fallback** topic을 여세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

2.  아래로 스크롤하여 메시지 노드로 이동하세요. 아래와 같이 메시지를
    업데이트하세요:

+++I’m sorry. This information is not available in my system. You can
raise the support ticket via mail for this issue.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

3.  오른쪽 상단에서 **Save** 버튼을 클릭하여 주제를 저장하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

**결론**

이 연습을 완료하면 참가자는 다음을 배우게 됩니다:

- 봇의 기능을 향상시키기 위해 기술 자료를 업로드하고 통합하는 방법.

- 더 매력적인 사용자 환경을 위해 대화 시작 메시지를 사용자 지정하는
  단계.

- 지원되지 않는 쿼리를 더 잘 처리하기 위해 대체 응답을 업데이트하는
  기술.

## 연습 4: 에이전트를 테스트하기

이 연습은 참가자가 Contoso IT 지원 에이전트를 테스트하여 기능의 유효성을
검사하는 과정을 안내합니다. 참가자는 봇이 기술 자료 및 대체 주제를
사용하여 프롬프트를 처리하는 방법을 확인하여 원활한 상호 작용 및
에스컬레이션을 보장합니다.

1.  오른쪽 상단에서 **Test ** 버튼을 클릭하세요. 테스트 섹션에서
    **Map**을 클릭하고 **On**을 클릭한 후 **Refresh**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

2.  +++**My printer is not working how to fix it**+++ 프롬프트를
    입력허세요. 지식 소스에 따라 솔루션을 제공합니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

3.  다시 한 번 +++**Two factor Authentication (2FA) issue**+++
    프롬프트를 제공하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

4.  2FA 문제 및 솔루션은 지식 소스에서 사용할 수 없으므로 대체 주제로
    이동하고 티켓 발생과 관련된 프롬프트를 반환합니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

**결론**

이 연습을 완료하면 참가자는 다음을 배우게 됩니다:

- 문제 해결을 위해 AI 에이전트를 테스트하고 활성화하는 방법.

- 기술 자료를 사용하여 응답하는 봇의 능력에 대한 유효성 검사.

- 대체 주제가 지원되지 않는 쿼리를 처리하고 사용자를 효과적으로
  리디렉션하는 방법.

## 연습 5: Power Automate를 사용하여 Support Ticket Creation을 자동화하기

이 연습에서는 Power Automate를 사용하여 지원 티켓 생성을 자동화하고
Contoso IT 지원 에이전트와 통합하는 방법을 보여 줍니다. 참가자는 문제
보고를 간소화하고, Dataverse에 데이터를 기록하고, 이메일을 통해 지원
엔지니어에게 알리는 플로우를 생성합니다.

1.  에이전트의 개요 페이지로 이동하여 아래로 스크롤하여 **+ Add
    action**을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  작업 선택 창의 왼쪽 상단에서 **+ New Action**을 클릭하고 **New Power
    Automate Flow**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  Power automate 플로우에서 **When an agent calls the flow**를
    클릭하고 **Add an Input**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

4.  Select입력의 데이터 유형으로 **Text**를 선택하고 입력
    이름을 +++**Name**+++로 바꾸세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image44.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image45.png)

5.  동일한 절차로 아래 세부 사항에 따라 더 많은 입력을 생성하세요.

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image46.png)

6.  아레에서 **When an agent calls the flow**, **(+)** 기호를 클릭하고
    **Add an action**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

7.  Add an action 검색 바에서 +++**Add a new row**+++를 입력하세요.
    Microsoft Dataverse 섹션에서 **Add a new row**를 선택하세요.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image48.png)

참고: 경우에 따라 Dataverse 연결이 자동으로 생성되지 않습니다.
**OAuth** 인증 자격 증명으로 다시 **sign in** 해야 할 수도 있습니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image49.png)

8.  **Table Name** 섹션에서 +++**Employee Technical Support Record**+++
    (또는 생성된 해당 테이블 이름)을 검색하고 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

9.  아래 테이블 이름 아래에서 **Show all**을 선택한 후 특정 필드를
    클릭하고 아래 표와 같이 동적 콘텐츠 버튼 (Thunder Bolt)을 사용하여
    입력을 추가하세여. **Current Status** 필드는 드롭다운을
    **Unresolved**로 선택해야 합니다.

[TABLE]

> ![A blue line on a white background AI-generated content may be
> incorrect.](./media/image51.png)
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image52.png)

10. Add a new row 작업 아래에서 (+)를 클릭하고 **Add an action**을
    선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image53.png)

11. Add an action 섹션에서, 검색 창에 +++ **Send an email** +++를
    입력하고 Office 365 Outlook 섹션에서 **send an email (V2)**를
    선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

1.  Send an email 섹션에서 해당 섹션에 아래 주어진 세부 정보를
    입력하세요.

> **Name, ID, Details**에 대한 자리 표시자를 동적 콘텐츠를 사용하는
> 변수로 바꾸세요.
>
> **To**
>
> Enter support engineer email (**Use any email ID** - It will be to
> this id, the mail will be sent by the agent to when Support Ticket is
> raised)
>
> **Subject**
>
> New Technical Support Ticket Raised
>
> **Body**
>
> A new technical support ticket has been raised and requires your
> attention. Please find details below:
>
> Employee Name: \< Name \>
>
> Employee ID: \< ID \>
>
> Technical Issue: \< Details \>
>
> Thank you for your prompt attention to this matter.'
>
> Best Regards

![A screenshot of a email AI-generated content may be
incorrect.](./media/image56.png)

12. 왼쪽 위 모서리에서 흐름의 이름을 +++ Create an Employee Support
    Ticket+++로 바꾸세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

13. 상단 표시줄에서 **Save draft**를 클릭한 후 **Publish**를 클릭하세요.
    Power automate 탭을 닫으세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

14. Copilot 창으로 이동하고 **Refresh** 버튼을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

15. Choose an action 창에서**Create an Employee Support
    Ticket** 플로우를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

16. 플로우를 추가하려면 **Add action** 버튼을 클릭하세요.

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image61.png)

17. 에이전트의 **Overview** 페이지에서 **Action** 섹션 아래에서 작업의
    파라미터를 편집하려면 **Edit**을 선택하세요. **Inputs** 섹션을
    선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

![A screenshot of a support ticket AI-generated content may be
incorrect.](./media/image63.png)

18. 해당 입력 필드에 주어진 설명을 입력하고 설명을 입력한 후
    **Save **버튼을 클릭하세요.

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image64.png)
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image65.png)

**결론**

이 연습을 완료하면 참가자는 다음을 배우게 됩니다.:

- 티켓 생성을 위해 Power Automate 흐름을 Copilot 에이전트와 통합하는
  방법.

- 사용자 상호 작용에서 입력 데이터를 동적으로 수집하고 매핑하는 단계.

- 기술 문제 에스컬레이션을 위해 이메일 알림을 자동화하는 기술.

- 효율적인 지원 티켓 관리를 위해 워크플로를 구성하는 기능.

## 연습 6: 자동화된 작업에 대한 이메일 기반 트리거 구성하기

지원 티켓 생성 자동화의 이 계속은 Contoso IT 지원 에이전트에서 트리거를
설정하여 이메일 입력을 자동화된 Power Automate 흐름과 연결하는 데 중점을
둡니다. 참가자는 트리거를 구성하고 배포를 위해 에이전트를 마무리합니다.

1.  에이전트의 개요 페이지로 이동하고 아래로 스크롤하여 **+ Add
    trigger**를 클릭하세요.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image66.png)

2.  Add trigger 창에서 **When a new email arrives (V3)** 트리거를
    선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

3.  Copilot 및 outlook이 성공적으로 연결되고 녹색 체크 표시가 나타나면
    **Next **버튼을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image68.png)

4.  폴더 필드에서 폴더 아이콘을 선택하고 **Inbox** 폴더를 선택한 후
    **Create trigger**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image69.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image70.png)

5.  **Time to test your trigger** 프롬프트를 닫으세요. Support 상담원
    개요 페이지에서 아래로 스크롤하고 트리거 섹션에서 세 개의 점을
    클릭합니다 **(...)** 을 클릭하고 **Edit in Power Automate**을
    선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image71.png)

6.  When a new email arrives 트리거를 마우스 오른쪽 버튼으로
    클릭하고**Delete**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image72.png)

7.  Add a trigger를 클릭하고 +++**When new email arrives**+++를
    검색하고 **Office 365 outlook** 섹션에서 **When a new email
    arrives** 트리거를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image73.png)

8.  **Send a prompt to the specified copilot for processing**를 클릭하고
    body/message 섹션에 +++**Run Create an Employee Support Ticket flow
    and use content from Body From.**+++프롬프트를 입력허세요.
    **Body**와 **From**을 dynamic content variable로 바꾸세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image74.png)

9.  플로우를 **Save** 및Publish하고 Power Automate 창을 닫고 Copilot
    창으로 돌아가세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image75.png)

10. 개요 섹션으로 이동하여 오른쪽 상단 모서리에서 **Publish** 를
    클릭하고 다시 **Publish** 를 클릭하여 copilot을 게시하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image76.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image77.png)

**결론**

이 연습을 완료하면 참가자는 다음을 배우게 됩니다.:

- 이메일 입력을 기반으로 워크플로를 자동화하기 위해 Copilot에서 트리거를
  설정하는 방법.

- 이메일 콘텐츠를 Power Automate 플로우에 동적으로 매핑하는 단계.

- 운영용 AI 에이전트를 게시하고 마무리하는 프로세스.

- Outlook과 같은 커뮤니케이션 도구를 자동화된 워크플로와 연결하는
  실용적인 기술.

## 연습 7: 에이전트를 테스트하기

이 연습에서는 Contoso IT 지원 에이전트와 Power Automate 및 Outlook의
통합을 테스트하는 데 중점을 둡니다. 참가자는 이메일을 처리하고, 지원
티켓을 생성하고, 자동화된 워크플로를 효과적으로 트리거하는 에이전트의
능력을 확인합니다.

1.  에이전트의 개요 페이지로 이동하여 아래로 스크롤하여 **(...)**
    트리거를 실행하고 **Edit in power automate**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image78.png)

2.  Power Automate 플로우로 이동하고 상단 표시줄에서 **Test** 버튼을
    클릭한 후 **Manually**를 선택하고**Test**를 다시 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image79.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image80.png)

3.  **Trigger the action**하기 위해 다른 사서함에서 365 관리 테넌트 메일
    ID로 **이메일을 보내세요**. 메일은 문제를 설명해야 하며 아래
    스크린샷과 유사하게 직원 ID와 같은 세부 정보가 포함되어야 합니다.
    예시 내용은 다음과 같습니다.

> Hi Support Team,
>
> I hope this message finds you well.
>
> Iam Mark Brown, working as a Software Engineer at Contoso. My employee
> ID is CONTOSO099
>
> Issue: Monitor is completely balank and not functioning.
>
> Kindly raise a support ticket and assist in resolving this issue at
> the earlierst.
>
> Thank you for your support.
>
> Best Regards,
>
> Mark Brown

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image81.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image82.png)

4.  Copilot 에이전트 개요 페이지로 이동하여 아래로 스크롤하여 **Test
    trigger**를 선택하세요.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

5.  **Start testing**을 클릭하면 테스트가 시작됩니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image84.png)

6.  테스트 섹션에서 **Connect**를 클릭하면 연결 창이 열립니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image85.png)

7.  **Connect**를 다시 클릭한 후 **Submit**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image86.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image87.png)

8.  copilot 스튜디오 창으로 이동하여 **Test**를 다시 실행하세요.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

9.  지원 요청이 자동으로 생성됩니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image88.png)

10. Power Apps로 이동하여 Employee support ticket record테이블로
    이동하여 세부 정보를 확인하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image89.png)

11. Power Automate 플로우에서 구성한 지원 메일을 확인하여 이메일을
    보내세요. 이메일은 자동으로 지원팀으로 전송됩니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image90.png)

12. 테스트 창 및 작성기 사용자 쿼리로 +++**Mark Brown Ticket Current
    Status**+++로 이동하세요. 문제의 상태를 해결되지 않음으로
    제공합니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image91.png)

13. Support Engineer로서 테스트 섹션에 프롬프트 +++ **I want to know
    about all Unresolved ticket** +++를 작성하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image92.png)

**결론**

이 연습을 완료하면 참가자는 다음을 배우게 됩니다:

- 실제 시나리오를 시뮬레이션하여 에이전트의 기능을 테스트하는 방법.

- Power Automate에서 이메일 트리거 워크플로 및 티켓 생성의 유효성을
  검사하는 단계.

- Dataverse에서 생성된 레코드를 검토하고 알림이 지원 팀에 전송되었는지
  확인하는 방법.

- 자동화 워크플로우의 디버깅 및 마무리에 대한 실용적인 통찰력.

## 실습 가이드의 최종 결론

이 실습 가이드는 참가자에게 Contoso Solutions의 IT 지원 서비스 데스크를
위한 Autonomous Copilot 에이전트를 배포하는 실습 환경을 제공했습니다.
참가자들은 단계별 연습을 통해 다음을 수행할 수 있었습니다:

1.  **Copilot Studio 설정**: 참가자들은 Copilot Studio에 로그인하고, IT
    지원 에이전트를 생성 및 구성하고, 효과적인 문제 해결 및 티켓
    자동화를 위해 generative AI 및 오케스트레이터와 같은 필수 설정을
    활성화하는 방법을 배웠습니다.

2.  **Power Apps 탐색**: 참가자는 Power Apps에 로그인하고, Dataverse
    테이블을 설정하고, Excel에서 데이터를 가져와 지원 티켓을 효율적으로
    추적하고 관리하는 데 대한 실용적인 지식을 얻었습니다.

3.  **봇 기능 향상**: 연습에서는 봇에 기술 자료를 추가하고, 대화 시작 및
    대체 주제를 사용자 지정하여 사용자 상호 작용을 개선하고, 봇이
    광범위한 IT 지원 시나리오를 처리할 수 있도록 하는 데 중점을
    두었습니다.

4.  **IT 지원 작업 자동화**: 참가자들은 Power Automate를 사용하여 지원
    티켓 생성을 자동화하여 해결되지 않은 문제를 관리하고 IT 팀
    워크플로를 개선하는 봇의 기능을 향상시키는 방법도 배웠습니다.

참가자들은 이러한 실습을 통해 응답 시간을 개선하고, 수동 작업량을
줄이고, IT 지원 운영의 전반적인 생산성을 향상시키는 강력한 자율 지원
시스템을 구현할 수 있었습니다. Copilot Studio, Power Apps 및 Dataverse의
통합은 원활한 정보 흐름을 보장하고, 일상적인 작업을 자동화하고, 지원
워크플로를 최적화하여 직원에게 즉각적인 문제 해결 솔루션을 제공하고
해결되지 않은 문제에 대한 자동화된 티켓 관리를 제공합니다.
