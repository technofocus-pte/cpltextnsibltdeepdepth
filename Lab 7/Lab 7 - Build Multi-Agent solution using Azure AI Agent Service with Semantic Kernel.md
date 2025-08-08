# ラボ 7 - Semantic KernelとAzure AI Agent Solutionを使用してMulti-Agent ソリューションを構築する

Azure AI Agent Service を通じて、エンタープライズ向けの AI
エージェントを構築できます。

**導入**

以下では、ブログ執筆のシナリオを紹介します。このシナリオには、執筆支援用とコンテンツの保存・管理用の2つのAIエージェントが関与します。これらのエージェントは、AutoGenまたはSemantic
Kernelを使用してシームレスにオーケストレーションできます。本ラボでは、Semantic
Kernel Orchestrationを使用します。

![A diagram of a diagram of a business AI-generated content may be
incorrect.](./media/image1.png)

## 目的：

Azure AI Foundry
SDKを使用すると、開発者はPythonまたはC#を使用して、Azure AI Agent
Serviceをベースにしたエージェントを迅速に構築できます。企業は事業内容に応じて異なるAIエージェントを使用するため、どのようにこれらのAIエージェントをワークフロー内で組み合わせるべきでしょうか？AIエージェントをオーケストレーションするには、AutoGenまたはSemantic
Kernelを使用する必要があります。本ラボでは、Semantic
Kernelを使用してとAzure AI Agent
Serviceを活用したマルチエージェントソリューションを開発します。

## 演習 1: Azure AI Hub リソースとプロジェクトを作成する

この演習では、Azure ポータルでハブを作成し、Azure AI Foundry
でプロジェクトを作成し、モデルをデプロイして、実行に必要なエージェントを作成します。

1.  ブラウザから、++\*\*
    <https://portal.azure.com/**>+++を開き、**ログイン資格情報**を使用してログインします**。** ログインの上、**Home ページ**から**Azure
    AI Foundry**を選択します。

    - ユーザー名 – <+++@lab.CloudPortalCredential> (User1).Username+++

    - パスワード – <+++@lab.CloudPortalCredential> (User1).Password+++

![image](./media/image2.png)

2.  **Use with AI Foundry ** -\> **AI Hubs**を選択します。 **+
    Create -\> Hub**を選択します。

![image](./media/image3.png)

3.  以下の詳細を入力し、他のデフォルトを受け入れて、 **Review +
    create**を選択します。

    - Subscription -**割り当てられたサブスクリプション**を選択します

    - Resource group - 割り当てられたリソース グループ (
      **ResourceGroup1** )を選択します。

    - Region - @lab.CloudResourceGroup(ResourceGroup1).Location
      を選択します。

    - Name - <+++hub@lab.LabInstance.Id> +++

![image](./media/image4.png)

![image](./media/image5.png)

4.  検証に合格したらCreateを選択します。

![image](./media/image6.png)

5.  デプロイが完了したら、 **Go to resource**をクリックします。

![image](./media/image7.png)

6.  ハブ リソース ページから**Launch Azure AI Foundry**を選択します。

![image](./media/image8.png)

7.  起動したハブ リソースから下にスクロールして、 **+ New
    project**を選択します。

![image](./media/image9.png)

![image](./media/image10.png)

8.  名前を<+++multiagent@lab.LabInstance.Id> +++
    として入力しCreateを選択します。

![image](./media/image11.png)

9.  Explore and experimentポップアップを**Close**します**。**

![image](./media/image12.png)

10. 作成されたプロジェクト ページに移動されます。

![image](./media/image13.png)

11. ページを下にスクロールし、**Project connection
    string の値**をメモ帳にコピーします。

![image](./media/image14.png)

12. 左側のペインで下にスクロールし、**Management center**を選択します。

![image](./media/image15.png)

13. ハブ リソースの下にある **Connected resources** を選択し、 **+ New
    connection **をクリックして、Azure AI Foundry
    リソースとの接続を作成します。

![image](./media/image16.png)

14. 利用可能な外部アセットから**Azure AI Foundry** を選択します。

![image](./media/image17.png)

15. **Add connection **を選択します。

![image](./media/image18.png)

![image](./media/image19.png)

16. 接続したら、 **Close**をクリックします。
    **Close**ボタンが表示されない場合は、ブラウザの**ズームサイズ**を縮小してから**Closeを選択してください**。

![image](./media/image20.png)

17. 左側のペインから**Go to project **を選択します。

![image](./media/image21.png)

18. **API Key **と**Azure OpenAI
    endpoint**の値をコピーし、メモ帳に保存します。

![image](./media/image22.png)

19. 左ペインの**Build and customize **から**Agents **を選択します。Azure
    **AI Agent Service**ページで、作成した**Azure OpenAI Service**
    を選択し**、 Let's go**をクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

20. **gpt-4o-mini**を選択し、 **Confirm**をクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

21. デプロイメント名は+++ **gpt-4o-mini**
    +++とし、デプロイメントタイプは**Standard**を選択します。その他のデフォルト設定はそのままで、
    **Deploy**をクリックしてモデルをデプロイします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

22. これで、Azure リソースの準備が整いました。

## 演習2: Multi Agent Orchestration

この演習では、Visual Studio Code
をセットアップし、実行に必要な前提条件をインストールします。

1.  VM から**Visual Studio Code**を開きます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

2.  **File**-\> **Open Folder **を選択し、
    **C:\LabFiles**から**MultiAgent**フォルダーを選択して、 **Select
    Folder**をクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

3.  ポップアップで**Yes, I trust the authors **を選択します。

![A screenshot of a computer error AI-generated content may be
incorrect.](./media/image30.png)

4.  ノートブックを右クリックし、 **Open in Integrated
    Terminal**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

5.  以下のコマンドを順に実行して、 **nuget source**を追加します。

+++dotnet nuget list source+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

> +++ dotnet nuget add
> source <https://api.nuget.org/v3/index.json> --name nuget.org ++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  以下のコマンドを実行して、dotnet interacrive をインストールします。

+++dotnet tool install --global Microsoft.dotnet-interactive --version
1.0.556801+++

![](./media/image34.png)

7.  +++pip install jupyter+++ を実行して Jupyter をインストールします。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image35.png)

8.  次のコマンドを実行、jupyter interactiveをインストール

+++dotnet interactive jupyter install+++

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image36.png)

9.  **ターミナルを閉じ**。Visual **Studio
    Code**の左ペインから**Extensions **を選択します**。+++ Jupyter
    +++**を検索して選択し、
    **Install **をクリックしてJupyter拡張機能をインストールします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

10. Visual Studio Code**を閉じて、**もう一度**開きます**。

11. ノートブック**AzureAIMultiAgentWithSK.ipynbを開きます**。開いたら、
    **Select Kernel**をクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

12. **Jupyter Kernel**を選択します。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image39.png)

13. 次のオプション セットで**.NET (C#) dotnet** を選択します。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image40.png)

14. **Security Alert**で**Allow access **を選択します。

![A screenshot of a computer security alert AI-generated content may be
incorrect.](./media/image41.png)

15. 最初のセルを実行して、必要な**パッケージ**をすべて**インストールします**。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image42.png)

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image43.png)

16. 次のセルを実行して名前空間をインポートします。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image44.png)

17. 次のセルで、**deployment **変数の値が、作成した**model
    deployment **と同じであることを確認します。

    - Endpoint – **Azure OpenAI Endpoint**

    - Key – **API Key**

上記の両方の値は、Azure AI Foundry
でプロジェクトを作成した後、以前にメモ帳に保存したものです

値を置き換えた後、セルを**実行します。**

これにより、これらの値が対応する変数に設定され、さらに使用されるようになります。

![A black screen with numbers AI-generated content may be
incorrect.](./media/image45.png)

18. 次のセルは、新しい**KernelBuilder**インスタンスを作成し、最後のステップの変数を入力として使用して**、Azure
    OpenAI Chat Completion** をAI サービス
    プロバイダーとしてカーネルに追加し、 **Build** () を呼び出して
    Kernel のインスタンスを作成します。

**実行する**とカーネルインスタンスが作成されます。

![A screen shot of a computer code AI-generated content may be
incorrect.](./media/image46.png)

19. 次のセルを実行して必要な**Azure**パッケージをインストールし、次のセルを実行して参照をインポートします。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image47.png)

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image48.png)

20. 次のセルのクラスは、 **Azure
    SDKリクエスト用のカスタムHTTPパイプラインポリシーを定義し**、すべての送信リクエストにカスタムHTTPヘッダー（x-ms-enable-preview:
    true）を追加します。**実行してください**。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image49.png)

## 演習3: ブログエージェントを保存する

1.  次のセルは、 **Azure AI Projects and the Semantic
    Kernel**を使用して**ブログ
    コンテンツを保存する**メソッドを実装する**SavePlugin**クラスを定義します。

    - **ブログのコンテンツ**を入力として受け取ります。

    - **Azure AI Projects **と対話してAI エージェントを作成します。

    - Python コードを生成して実行し、コンテンツ**をMarkdown** (.md)
      ファイルとして**保存します。**

    - 生成されたファイル**をダウンロードし**てローカルに**保存します。**

    - **確認**メッセージ("Saved")を**返します。**

このセルを実行するには、**Your Connection
Stringを、**先ほどメモ帳に保存した**Project Connection
String **に置き換えてください。この接続文字列は、Azure AI
Foundryポータルのプロジェクト概要ページからアクセスできます。

接続文字列を置き換えた後、 **Execute **をクリックします。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image50.png)

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image51.png)

2.  次のセルはSave固有の値で**定数**を初期化します。**実行してください**。これらの定数は次のセルで使用されます。

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image52.png)

3.  次のセルは**save_blog_agent**という名前の**ChatCompletionAgent**を作成します。これを実行してエージェントを作成します。

![A computer screen shot of a computer program AI-generated content may
be incorrect.](./media/image53.png)

## 練習4: Writerエージェント　

1.  次のセルをノートブックの実行すると、Writer
    固有の値を持つ定数を宣言します。

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image54.png)

2.  次のセルは、 write-blog_content
    という名前の**ChatCompletionAgent**を作成します。これは、Microsoft
    Semantic Kernel と Azure OpenAI
    チャットモデルを使用してブログ投稿を作成する役割を担います。これを実行してエージェントを作成します。

![A computer screen shot of a black screen AI-generated content may be
incorrect.](./media/image55.png)

3.  次のセルのコードは、 **SavePlugin**
    を**save_blog_agent**内の関数として利用できるようにします。これにより、
    SavePluginから**Kernel
    Plugin **が作成されます**。** **エージェントのKernel **にプラグイン**を追加します**。AIは保存関連のリクエストを検出すると、
    **SavePlugin.Save**関数を呼び出します。

これを実行するとKernel Pluginが作成されます。

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image56.png)

4.  **次のセールは、ApprovalTerminationStrategy**クラスのコードが含まれています。

5.  この**カスタム終了戦略は、
    AIエージェントの実行を停止するタイミング**を決定するために使用されます。**実行してください**。

![A computer screen with text on it AI-generated content may be
incorrect.](./media/image57.png)

6.  次のセルには**AgentGroupChat**コードが含まれています。これは、
    2つのAIエージェント（ **write_blog_agent**と**save_blog_agent
    ）**が連携する**マルチエージェントチャットシステム**を作成します。チャットの終了タイミングを決定するために、
    **ApprovalTerminationStrategy**を使用します。

**save_blog_agent**のみがチャットの終了を承認できます。

**実行して**マルチエージェントチャットを構成します。

![A computer screen shot of a program AI-generated content may be
incorrect.](./media/image58.png)

7.  次のセルにはエージェントへの指示が含まれています。**マルチエージェントチャットシステムにユーザーメッセージを追加し**、AIに**GraphRAGに関する情報を検索し、ブログを書いて保存するように**指示します。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image59.png)

8.  次のセル**を実行します。**これは、マルチエージェントチャットで**AIが生成した応答がストリーミングされるたびに反復処理を行います**。

実行するとブログを書いて保存します。

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image60.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

## 要旨

Semantic KernelとAzure AI Agent Serviceを使用して、Multi
Agentシステムを実装しました。
