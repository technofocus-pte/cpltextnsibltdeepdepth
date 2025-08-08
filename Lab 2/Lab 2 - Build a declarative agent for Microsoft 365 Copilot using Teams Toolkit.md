# 실습 2: Teams Toolkit를 사용하여 Microsoft 365 Copilot에 대한 선언적 (declarative) 에이전트 빌드

**예상 소요 시간: 30분**

## 목표

이 실습의 목표는 참가자가 Teams Toolkit를 사용하여 Microsoft 365
Copilot에 대한 선언적 에이전트를 빌드할 수 있도록 하는 것입니다. 실습을
완료함으로써 참가자는 직장에서 재미있고 교육적인 휴식을 제공하는 지리적
위치 게임을 생성하게 됩니다. 실습은 선언적 에이전트의 구조를 이해하고,
지침으로 구성하고, 사용자 지정된 Copilot 상호 작용을 위해 Microsoft 365
ecosystem에 통합하는 데 중점을 둡니다.

## 솔루션

참가자는 Visual Studio Code에 Teams Toolkit를 설치하고 개발 환경을
설정합니다. 템플릿을 사용하여 Geo Locator Game이라는 선언적 에이전트를
스캐폴딩합니다. 에이전트의 지침을 사용자 정의하고 instruction.txt 및
manifest.json와 같은 구성 파일을 업데이트합니다. 이 실습은 또한
참가자들이 고유 식별자, 사용자 지정 아이콘 및 테스트 기능으로 에이전트를
향상시키는 방법을 안내합니다. 그 결과 Microsoft 365와 원활하게 통합되는
동시에 도시에 대한 단서를 제공하도록 맞춤화된 완전한 기능을 갖춘
매력적인 Copilot 애플리케이션이 탄생했습니다.

## 연습 1: Microsoft 365 Copilot에 대한 개발 환경 설정

### 작업 1: Teams Toolkit를 설치하기

이러한 실습은 Teams Toolkit 버전 5.0을 기반으로 합니다. 아래 스크린샷에
표시된 대로 단계를 따릅니다.

1.  Visual Studio Code를 열고 이미 열려있는 **Appliances.csv** 닫으세요.

2.  Restricted Mode is intended 메시지에서 **Manage**를 선택하세요.

![](./media/image1.png)

3.  **You are in Restricted mode** 대화 상자에서 **Trust**를 선택하세요.

![](./media/image2.png)

4.  Extensions 도구 모음 버튼을 클릭하세요.

![](./media/image3.png)

5.  +++**Teams**+++를 검색하고 Teams **Toolkit**을 찾은 후 **Install**를
    클릭하세요.

![](./media/image4.png)

6.  설치가 완료되면 **Teams Toolkit**아이콘이 왼쪽 탐색 창에
    나타납니다. ![](./media/image5.png)

## 연습2: 첫 번째 선언적 에이전트

이 실습에서는 Visual Studio Code용 Teams Toolkit를 사용하여 간단한
선언적 에이전트를 빌드합니다. 귀하의 에이전트는 귀하가 전 세계 도시를
탐험할 수 있도록 도와줌으로써 직장에서 벗어나 재미있고 교육적인 휴식을
취할 수 있도록 설계되었습니다. 도시를 추측할 수 있는 추상적인 단서를
제공하며, 더 많은 단서를 사용할수록 더 적은 점수가 부여됩니다. 마지막에
최종 점수가 공개됩니다.

이 연습에서는 다음을 배우게 됩니다:

- Microsoft 365 Copilot에 대한 선언적 에이전트란?

- Teams Toolkit 템플릿을 사용하여 선언적 에이전트 생성

- 지침에 따라 지오 로케이터 게임을 생성하도록 에이전트를 사용자
  지정하기.

- 앱을 실행하고 테스트하는 방법 알아보기

&nbsp;

- 보너스 연습을 위해서는 SharePoint 팀 사이트가 필요

**소개**

선언적 에이전트는 Microsoft 365 Copilot의 확장 가능한 인프라와 플랫폼을
동일하게 활용하며, 특정 요구 영역에 대한 집중을 충족하도록 특별히
조정됩니다. 특정 영역 또는 비즈니스 요구 사항에 대한 주제 전문가로
기능하므로 표준 Microsoft 365 Copilot 채팅과 동일한 인터페이스를
사용하면서 당면한 특정 작업에만 독점적으로 집중할 수 있습니다.

나만의 선언적 에이전트를 구축하는 것을 환영합니다! 뛰어들어 코파일럿을
마법처럼 생성해 보세요!

이 실습에서는 도구에 사용되는 기본 템플릿과 함께 Teams Toolkit를
사용하여 선언적 에이전트를 빌드하기 시작합니다. 무언가를 시작하는 데
도움이 됩니다. 다음으로, 지리적 위치 게임에 집중하도록 에이전트를
수정합니다.

AI의 목표는 전 세계의 여러 도시에 대해 배울 수 있도록 도와주면서
직장에서 즐거운 휴식을 제공하는 것입니다. 도시를 식별할 수 있는 추상적인
단서를 제공합니다. 필요한 단서가 많을수록 획득하는 점수가 줄어듭니다.
게임이 끝나면 최종 점수가 공개됩니다.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image6.png)

또한 에이전트에게 비밀 일기를 🕵🏽 참조할 수 있는 몇 가지 파일과
플레이어에게 더 많은 도전을 제공할 수 있는 지도를 🗺️ 제공합니다.

자, 시작하겠습니다

**선언적 에이전트의 분석**

Copilot에 대한 확장 기능이 점점 더 많아짐에 따라 결국 빌드하게 될 것은
zip 파일에 있는 몇 가지 파일 모음이라는 것을 알게 될 것입니다.이를 앱
패키지라고 하여 설치하고 사용할 수 있습니다. 따라서 앱 패키지가 무엇으로
구성되어 있는지에 대한 기본적인 이해를 하는 것이 중요합니다. 선언적
에이전트의 앱 패키지는 이전에 추가 요소를 사용하여 빌드한 경우 Teams
앱과 같습니다. 모든 핵심 요소를 보려면 표를 참조하세요. 또한 앱 배포
프로세스가 Teams 앱 배포와 매우 유사하다는 것을 알 수 있습니다.

[TABLE]

**참고:** SharePoint, OneDrive, 웹 검색 등에서 참조 데이터를 추가하고
플러그 인 및 커넥터와 같은 선언적 에이전트에 확장 기능을 추가할 수
있습니다. 이 경로의 향후 실습에서 플러그인을 추가하는 방법을 알아봅니다.

**선언적 에이전트의 기능**

에이전트를 컨텍스트와 데이터에 대한 집중도를 높일 수 있는 방법은 지침을
추가하는 것뿐만 아니라 에이전트가 액세스해야 하는 기술 자료를 지정하는
것입니다. 이를 기능이라고 하며 지원되는 세 가지 유형의 기능이 있습니다.

- **Microsoft Graph 커넥터** - Graph 커넥터의 연결을 에이전트에 전달하여
  에이전트가 커넥터의 지식에 액세스하고 활용할 수 있도록 합니다.

- **OneDrive 및 SharePoint** - 에이전트에서 해당 콘텐츠에 액세스할 수
  있도록 파일 및 사이트의 URL을 제공합니다.

- **웹 검색** - 에이전트의 지식 기반의 일부로 웹 콘텐츠를 활성화하거나
  비활성화합니다.

![](./media/image7.png)

**One Drive 및 SharePoint**

URL은 SharePoint 항목(사이트, 문서 라이브러리, 폴더 또는 파일)에 대한
전체 경로여야 합니다. SharePoint에서 "직접 링크 복사" 옵션을 사용하여
전체 경로 또는 파일 및 폴더를 가져올 수 있습니다. 이렇게 하려면 파일
또는 폴더를 마우스 오른쪽 버튼으로 클릭하고 세부 정보를 선택합니다.
경로로 이동하여 복사 아이콘을 클릭합니다. URL을 지정하지 않으면 로그인한
사용자가 사용할 수 있는 OneDrive 및 SharePoint 콘텐츠의 전체 코퍼스가
에이전트에 의해 사용됩니다.

**Microsoft Graph 커넥터**

연결을 지정하지 않으면 로그인한 사용자가 사용할 수 있는 Graph Connectors
콘텐츠의 전체 코퍼스가 에이전트에 의해 사용됩니다.

**웹 검색**

현재로서는 특정 웹사이트나 도메인을 전달할 수 없으며 이는 웹을 사용하기
위한 토글 켜기 및 끄기 역할만 합니다.

## 연습 3: 템플릿에서 선언적 에이전트를 스캐폴드

위에서 언급한 앱 패키지의 파일 구조를 알고 있는 경우 아무 편집기나
사용하여 선언적 에이전트를 생성할 수 있습니다. 그러나 Teams Toolkit와
같은 도구를 사용하여 이러한 파일을 생성할 뿐만 아니라 앱을 배포하고
게시하는 데 도움이 되는 경우 작업이 더 쉬워집니다. 따라서 가능한 한
간단하게 유지하기 위해 Teams Toolkit을 사용합니다.

### 작업 1: Teams Toolkit를 사용하여 선언적 에이전트 앱 생성하기

1.  Visual Studio Code 편집기에서 Teams Toolkit확장으로 이동하여
    **Create a New App**을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

2.  프로젝트 유형 목록에서 **Agent 를** 선택해야 하는 패널이 열립니다.

![](./media/image9.png)

3.  다음으로 Copilot Agent의 앱 기능을 선택하라는 메시지가 표시됩니다.
    **Declarative agent**를 선택하고 **Enter** 키를 누르세요.

![](./media/image10.png)

4.  다음으로, 기본 선언적 에이전트를 생성할 것인지 아니면 API 플러그인이
    있는 에이전트를 생성할 것인지 선택하라는 메시지가 표시됩니다. **No
    Plugin** 옵션을 선택하세요.

![](./media/image11.png)

5.  다음으로, 프로젝트 폴더를 생성해야 하는 위치를 지정하기 위해
    **Default folder** 옵션을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

6.  애플리케이션 이름을 +++**Geo Locator Game**+++으로 지정하고
    **Enter**를 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

프로젝트는 언급 한 폴더에 몇 초 안에 생성해지고 Visual Studio Code의 새
프로젝트 창에서 열립니다. 이것은 작업 폴더입니다.

7.  프롬프트되면 **Yes, I trust the authors**를 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

> ![](./media/image15.png)

잘 했어요! 기본 선언적 에이전트를 성공적으로 설정했습니다! 이제 지리적
위치 찾기 게임 앱을 생성하기 위해 사용자 지정할 수 있도록 그 안에 포함
된 파일을 검사하세요.

### 작업 2: Teams Toolkit에서 계정 설정하기

1.  이제 왼쪽 창에서 Teams Toolkit 아이콘을 선택하세요.
    "**Accounts**"에서 "**Sign in to Microsoft 365**"을 클릭하고 **User1
    credentials**로 로그인하세요. Visual Studio Code 팝업에서 로그인을
    클릭하세요.

- Username - <+++@lab.CloudPortalCredential>(User1).Username+++

- Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![](./media/image16.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

3.  Security Alert 대화 상자에서 **Allow access**를 선택하세요.

![](./media/image18.png)

4.  로그인하면 브라우저가 열리고 " You are signed in now and close this
    page"라는 메시지가 표시됩니다. 그렇게 해주세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

5.  **Custom App Upload Enabled**검사기에 녹색 확인 표시가 있는지
    확인하세요.

6.  **Copilot Access Enabled** 검사기에 녹색 확인 표시가 있는지
    확인하세요.

![](./media/image20.png)

### 작업 3: 앱의 파일 이해

기본 프로젝트의 모양은 다음과 같습니다:

[TABLE]

1.  실습에서 관심 있는 파일은 주로 에이전트에 필요한 핵심 지시문인
    **appPackage/instruction.txt** 파일입니다. 일반 텍스트 파일이며
    자연어 명령을 작성할 수 있습니다.

![](./media/image21.png)

2.  또 다른 중요한 파일은 새 선언적 에이전트로 Microsoft 365 Copilot을
    확장하기 위해 따라야 할 스키마가 있는
    **appPackage/declarativeAgent.json**입니다. 이 파일의 스키마에 어떤
    속성이 있는지 살펴보겠습니다.

- $schema은 스키마 참조입니다

- 버전은 스키마 버전입니다

- name 키는 선언적 에이전트의 이름을 나타냅니다.

- 설명은 설명을 제공합니다.

- 지침은 작동 동작을 결정하는 지시문을 포함하는 **instructions.txt**
  파일의 경로입니다. 여기에 지침을 일반 텍스트로 값으로 넣을 수도
  있습니다. 그러나 이 실습 에서는 **instructions.txt** 파일을
  사용합니다.

![](./media/image22.png)

3.  또 다른 중요한 파일은 패키지 이름, 개발자 이름 및 애플리케이션에서
    사용하는 copilot 에이전트에 대한 참조를 포함하여 중요한 메타데이터가
    포함된 **appPackage/manifest.json** 파일입니다. manifest.json 파일의
    다음 섹션에서는 이러한 세부 정보를 보여 줍니다:

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

4.  로고 파일을 color.png 및 outline.png 업데이트하여 애플리케이션의
    브랜드와 일치하도록 생성할 수도 있습니다. 오늘 실습에서는 에이전트가
    눈에 띄게 **color.png** 아이콘을 변경합니다.

## 연습 4: 지침 및 아이콘 업데이트하기

### 작업 1: 업데이트 아이콘 및 매니페스트

1.  먼저 로고를 교체합니다. 프로젝트의 color.png 이미지를 새 이미지로
    교체합니다. **C:\LabFiles**에 있는 **color.png** 이미지를 복사하고
    루트 프로젝트의 **appPackage** 폴더에서 동일한 이름의 이미지를
    바꾸세요 (경로는 **C:\Users\Student\TeamsApps\Geo Locator
    Game\appPackage**여야 함).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![](./media/image26.png)

2.  다음으로, 루트 프로젝트의 **appPackage/manifest.json** 파일로
    이동하여 **copilotAgents** 노드를 찾으세요. 이 ID를 고유하게
    생성하려면 declarativeAgent에서 declarativeAgent의 첫 번째 항목
    declarativeAgents ID 값을 +++dcGeolocator+++로 업데이트하세요.

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

3.  **appPackage/instruction txt** 파일로 이동하여 아래 지침을 복사하여
    파일의 기존 내용을 덮으세요.

> System Role: You are the game host for a geo-location guessing game.
> Your goal is to provide the player with clues about a specific city
> and guide them through the game until they guess the correct answer.
> You will progressively offer more detailed clues if the player guesses
> incorrectly. You will also reference PDF files in special rounds to
> create a clever and immersive game experience.
>
> Game play Instructions:
>
> Game Introduction Prompt
>
> Use the following prompt to welcome the player and explain the rules:
>
> Welcome to the Geo Location Game! I’ll give you clues about a city,
> and your task is to guess the name of the city. After each wrong
> guess, I’ll give you a more detailed clue. The fewer clues you use,
> the more points you score! Let’s get started. Here’s your first clue:
>
> Clue Progression Prompts
>
> Start with vague clues and become progressively specific if the player
> guesses incorrectly. Use the following structure:
>
> Clue 1: Provide a general geographical clue about the city (e.g.,
> continent, climate, latitude/longitude).
>
> Clue 2: Offer a hint about the city’s landmarks or natural features
> (e.g., a famous monument, a river).
>
> Clue 3: Give a historical or cultural clue about the city (e.g.,
> famous events, cultural significance).
>
> Clue 4: Offer a specific clue related to the city’s cuisine, local
> people, or industry.
>
> Response Handling
>
> After the player’s guess, respond accordingly:
>
> If the player guesses correctly, say:
>
> That’s correct! You’ve guessed the city in \[number of clues\] clues
> and earned \[score\] points. Would you like to play another round?
>
> If the guess is wrong, say:
>
> Nice try! \[followed by more clues\]
>
> PDF-Based Scenario
>
> For special rounds, use a PDF file to provide clues from a historical
> document, traveler's diary, or ancient map:
>
> This round is different! I’ve got a secret document to help us. I’ll
> read clues from this \[historical map/traveler’s diary\] and guide you
> to guess the city. Here’s the first clue:
>
> Reference the specific PDF to extract details:
>
> Traveler's Diary PDF,Historical Map PDF.
>
> Use emojis where necessary to have friendly tone.
>
> Scorekeeping System
>
> Track how many clues the player uses and calculate points:
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
> After the player guesses the city or exhausts all clues, prompt:
>
> Would you like to play another round, try a special challenge?

![](./media/image29.png)

4.  **appPackage/declarativeAgent.json** 에서 다음 줄을 주목하세요:

> "instructions": "$\[file('instruction.txt')\]",
>
> 이렇게 하면 **instruction.txt** 파일에서 지침을 가져옵니다. 패키징
> 파일을 모듈화하려면 **appPackage** 폴더의 JSON 파일에서 이 기술을
> 사용할 수 있습니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

### 작업 2 : 대화 시작 도구 추가하기

선언적 에이전트에 대화 시작을 추가하여 사용자 참여를 향상시킬 수
있습니다.

대화를 시작하는 것의 이점 중 일부는 다음과 같습니다:

- **참여**: 상호 작용을 시작하여 사용자가 더 편안하게 느끼고 참여를
  장려하는 데 도움이 됩니다.

- **컨텍스트 설정**: 스타터는 대화의 어조와 주제를 설정하고 사용자에게
  진행 방법을 안내합니다.

- **효율성**: 명확한 초점으로 이끌면 스타터가 모호성을 줄여 대화가
  원활하게 진행될 수 있습니다.

- **사용자 유지**: 잘 설계된 스타터는 사용자의 관심을 유지하여 AI와의
  반복적인 상호 작용을 장려합니다.

1.  파일 **declarativeAgent.json** 열고 지침 노드 바로 뒤에 쉼표를
    추가하고 Enter 키를 누른 다음 코드 아래에 붙여넣으세요.

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

이제 에이전트에 대한 모든 변경 사항이 완료되었으므로 테스트할
차례입니다.

2.  상단 표시줄에서 **Files로** 이동하여 **Save All**을 클릭하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

### 작업 3: 앱을 테스트하기

1.  앱을 테스트하려면 Visual Studio Code Teams Toolkit 확장으로
    이동하세요. 그러면 왼쪽 창이 열립니다. "**LIFECYCLE"**에서
    "**Provision"**을 선택하세요. Teams Toolkit의 가치는 게시를 매우
    간단하게 생성하므로 여기에서 확인할 수 있습니다.

![](./media/image33.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

2.  메시지가 표시되면 자격 증명으로 로그인하세요.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image35.png)

3.  이 단계에서 Teams Toolkit는 appPackage 폴더 내의 모든 파일을 zip
    파일로 패키지하고 선언적 에이전트를 사용자 고유의 앱 카탈로그에
    설치하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

4.  **5/5 actions in provision stage executed successfully**라는
    메시지가 표시되면 프로세스가 완료된 것입니다.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image37.png)

5.  브라우저에서
    +++[https://teams.microsoft.com/v2/+로](https://teams.microsoft.com/v2/+++%C2%A0from)
    이동하고 메시지가 표시되면 테넌트에 로그인하세요. 새 앱은 채팅 위에
    자동으로 고정됩니다. Teams를 열고 "채팅"을 선택하면 **Copilot**이
    표시됩니다. 그것을 선택하세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

\[!알림\] 현재 이 지역에서 Copilot을 사용할 수 없다는 메시지가 표시되면
+++<https://m365.cloud.microsoft/chat/+++> 링크를 사용하고 동일한 단계에
따라 앱을 테스트하세요.

5.  Copilot 앱이 로드되면 그림과 같이 오른쪽 패널에서 +++Geo Locator
    Game+++을 찾으세요.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

찾을 수 없는 경우 목록이 길어질 수 있으며 "see more"를 선택하여 목록을
확장하여 에이전트를 찾을 수 있습니다.

6.  일단 실행되면 에이전트와 함께 이 집중 채팅 창에 있게 됩니다. 그리고
    아래에 표시된 대로 대화 시작이 표시됩니다:

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

7.  대화 시작 항목 중 하나를 선택하면 작성 메시지 상자가 시작 프롬프트로
    채워지고 "Enter"를 누를 때까지 기다리세요. 그것은 여전히 당신의
    조수일 뿐이며 당신이 조치를 취하기를 기다릴 것입니다.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

8.  질문에 답하고 개발한 게임을 탐색해 보세요.

## 요약

이 실습에서는 Teams Toolkit를 사용하여 선언적 에이전트를 빌드하고
에이전트의 기능을 테스트하는 방법을 알아보았습니다.
