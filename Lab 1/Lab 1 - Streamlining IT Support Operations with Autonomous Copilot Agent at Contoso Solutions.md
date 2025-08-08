# Lab 1 - Copilot Studio を使用した自律型 Copilot エージェントによる IT サポート業務の効率化

**所要時間：60分**

## 目的

このLabの目的は、参加者が自律型Copilotエージェントを作成し、Contoso
SolutionsにおけるITサポート業務を効率化できるようにすることです。参加者は、Microsoft
Copilot Studioのセットアップ、ITサポートエージェントの構成、Power
AppsとDataverseの統合、ナレッジベースによるボットの機能強化、Power
Automateを使用してチケット作成の自動化について学習します。この実践的なLabを通して、ITワークフローの改善、手動業の削減とサポート効率性の向上に必要なスキルを習得できます

## 解決

参加者は、Microsoft Copilot Studio を使用してカスタマイズされた Contoso
IT サポートエージェントを作成し、一般的な IT
問題に対応できるように構成し、サポートデータを保存するために Dataverse
と統合します。開発環境を構築し、ナレッジソースを追加し、ボットの会話フローを調整してユーザーインタラクションを改善します。Power
Apps を活用して、IT サポート記録を管理するための Dataverse
テーブルを作成します。Power Automate
を使用して、未解決の問題に関するチケット作成とメール通知を自動化します。最後に、参加者はエージェントのトラブルシューティング精度とワークフローの自動化を確認用、エージェントをテストし、シームレスな
IT サポートオペレーションを実現します。

## 演習 1: Power Appsを使い始める

この演習では、Power AppsとDataverseの概要を紹介します。Power
Appsにログインし、作業環境を構築し、ExcelファイルからデータをインポートしてDataverseテーブルを作成することを目標とします。参加者は、データ駆動型アプリケーションを操作するための基本的なスキルを習得します。

### タスク 1: Power Apps へのログイン

1.  Lab VM からブラウザを開きます。

2.  Power Appsのウェブサイト
    +++<https://www.microsoft.com/en-us/power-platform/products/power-apps+++>
    に移動し、**Try for Free**ボタンをクリックします。

![](./media/image1.png)

3.  **Resources** タブの**Office 365
    Tenant** **セクション**から**Administrative Username** を電子メール
    フィールドに入力し、**checkbox** を**select** し**、 Start
    free** ボタンをクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

4.  **Administrative Password** を入力すると、Power Apps
    のホームページに移動します。

5.  \[サインイン状態を維持する\] ダイアログで**Yes** を選択し、
    パスワードの保存プロンプトで **Got it** を選択し**、** Microsoft
    Edge にサインイン ポップアップで**No, Thanks**を選択します。

**注:**
ユーザー名、パスワード、またはログインするための情報を再度要求された場合は、同じものを入力してログインしてください。

### タスク2: Dataverseテーブルの設定

1.  **Dev
    One**環境が選択されていることを確認してください。選択されていない場合は選択してください。

> ![](./media/image3.png)

2.  左側のナビゲーションバーから**Tables**を選択します**。**テーブルセクションの上部バーで
    **+ New table** をクリックし、 **Create new tables**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

3.  新しいテーブルを作成するには、 **Import an Excel file or
    CSV** **オプション**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image5.png)

4.  **Select from device **オプションをクリックし、
    **C:\LabFiles** フォルダーから**Support Ticket**
    Excelファイルを選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

5.  テーブルを選択し、 **View data**をクリックしてテーブルを表示します。

**注:**この場合、テーブル名は*Employee Technical Support
Recordです*。テーブル名は実行ごとに異なる場合があります。今後の参考のために、テーブル名を保存しておいてください。列名も実行ごとに異なる場合があります。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

6.  テーブルデータに移動し**、Technical Issue
    Description **フィールドの横にあるドロップダウンを選択し、**Edit
    column**をせんたくし**、**data typeフィールドに**Text **🡪** Multiple
    line **🡪** Plain
    Text を選択し、Update**をクリックします。列名はそれぞれ異なる場合があります。

**注:**列名は少し異なる場合がありますが**、** Copilot
によって生成されるため、問題の説明に似たようなものになります。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

7.  **Current Status **フィールドの横にあるドロップダウンを選択し、
    **Edit column**を選択して、選択肢を+++ **Unresolved** +++、+++
    **Resolvedみ**+++、+++ **Processing**
    +++とセットします。デフォルトの選択肢を**「Unresolved 」**とセットし、**Update**をクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

8.  右上の**Save and exit **をクリックしてテーブルを保存します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

**結論**

この演習を完了した上、参加者は習得すること：

- Office 365 アドミンテナント証明書を使用して Power Apps
  にアクセスし、操作する方法。

- データをインポートして Dataverse テーブルを作成および構成する手順。

- アプリ開発ワークフローをサポートする環境を設定するための実践的な知識。

## 演習 2: Contoso IT サポート エージェントの作成

この演習では、Microsoft Copilot
Studioにログインし、Contoso社のITサポート業務用、カスタマイズされたCopilotエージェントを作成することに焦点を当てます。参加者は、Copilot
Studio の操作、環境の設定、そして IT ワークフローを効率化する AI
駆動エージェントの構築について、実践的な経験を習得します。

### タスク 1: Microsoft Copilot Studio へのログイン

1.  ブラウザから、 URL
    +++[https://copilotstudio.microsoft.com+++](https://copilotstudio.microsoft.com+++/)へ移動します。

2.  下のスクリーンショットのように**Setting up your
    copilot**と表示されている場合は、右上のメニューから**Environments**を選択し**、
    Dev
    One**を選択してください。表示されない場合は、この手順を無視して手順3に進んでください。

![image](./media/image12.png)

3.  Copilot Studio の試用版を起動するには、 **Start free
    trial **をクリックします。

![](./media/image13.png)

### タスク 2: Contoso IT サポート エージェントの作成と構成

1.  前のタスクのステップ2が完了している場合は、このステップを無視してください。完了していない場合は、このステップを実行します。Copilot
    Studioのホームセクションで、右上にある**environment **を選択し、
    **DevOne**環境を選択します。

![](./media/image14.png)

2.  Welcome to Copilot Studioタブで、
    **Skip**をクリックして先に進みます。

![](./media/image15.png)

3.  左側のナビゲーション バーから**Create **を選択し、 **New
    agent**を選択して新しいエージェントの作成を開始します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

4.  右上にある**Skip to configure **ボタンをクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

5.  以下のようにエージェントの**Name、Description、Instruction**を入力し、
    **Create**ボタンをクリックします。

> **Name:** +++Contoso IT Support Agent+++
>
> **Description:** +++Create a Contoso IT Support Agent which transforms
> IT support at Contoso Solutions by providing instant troubleshooting
> for common issues, automating ticket creation for unresolved problems,
> and storing all interactions in Dataverse. This solution enhances
> response times, reduces manual workloads, and boosts employee
> productivity.+++
>
> **Instruction:** +++Create the Copilot Agent and configure it to
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

6.  Contoso IT Support
    Agentの概要ページで、エージェントのオーケストレーターを**Enable にします。**

![](./media/image19.png)

7.  エージェントの概要ページで、 「 **Allow the AI to use its own
    general knowledge」**オプション**をDisable **にします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

8.  エージェントの右上にある**Setting**ボタンをクリックします。

![](./media/image21.png)

9.  **Generative AI**セクションに移動し、
    **Generative**を選択して、コンテンツ
    モデレーションを**Mediumに設定し**、
    **Save **をクリックして設定を保存します。

![](./media/image22.png)

**結論**

この演習を完了した上、参加者は習得すること：

- Microsoft Copilot Studio にアクセスして設定する方法。

- カスタム Copilot エージェントを作成して構成する手順。

- エージェントの生成 AI
  とオーケストレーター設定を有効にするための実践的なスキル。

- チケット作成を自動化し、トラブルシューティングに AI を活用することで
  IT 運用を強化する方法。

## 演習3：ボットの機能強化

この演習では、ナレッジベースを追加し、改良されたインタラクションのために、ボットトピックをカスタマイズすることを通じて、Contoso
ITサポートエージェントの機能を強化することに焦点を当てます。参加者は、ボットの応答を改良し、トラブルシューティングやエスカレーションでユーザーを効果的に支援できるようにする。

### タスク1: ナレッジベースの追加

1.  Contoso エージェントの概要ページで、下にスクロールして**+ Add
    Knowledge**ボタンをクリックします。

![](./media/image23.png)

2.  **Upload file**を選択して、 **C:\LabFiles**フォルダーからLab
    ファイル**Contoso Common IT Issue.docx**を追加し**、
    Add**をクリックしてファイルを保存します。

![image](./media/image24.png) ![image](./media/image25.png)

3.  もう一度、エージェント概要ページに移動し、下にスクロールして**+ Add
    knowledge**をクリックします**。**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

4.  データ ソースとして**Dataverse (preview)**オプションを選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

5.  右上隅の検索バーに+++**Employee**+++と入力して検索し、 **Employee
    Technical Support Record **テーブルを選択します。
    **Next**ボタン**、**それから**Add**ボタンをクリックして、ナレッジソースを追加します。

**注:**テーブル名はCopilot
によって生成されたものなので、**異なる場合があります。**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image29.png)

**重要:**
ナレッジページで、追加したナレッジソースが正常にアップロードされていることを確認してください。アップロードには通常10～15分かかります。

### タスク2: 会話開始トピックをカスタマイズする

1.  上部バーのオプションから、 **Topics -\> System **をクリックし、
    **Conversation Start **トピックをクリックして開きます。

![image](./media/image30.png)

2.  下にスクロールしてメッセージノードに移動し、ボット名の後のメッセージを以下のように更新します。

Hello. I’m Bot Name, a virtual assistant. +++How can I help you? +++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

3.  上から**Save**をクリックしてトピックを保存します。

![](./media/image32.png)

### タスク3: フォールバックトピックを更新する

1.  上部バーのオプションから、
    **Topics -\> System**をクリックし、**Fallback**トピックを開きま。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

2.  下にスクロールしてメッセージノードに移動し、以下のようにメッセージを更新します。

+++I’m sorry. This information is not available in my system. You can
raise the support ticket via mail for this issue. +++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

3.  トピックを保存するには、右上の**Save**ボタンをクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

**結論**

この演習を完了した上、参加者は習得すること：

- ボットの機能を強化するためにナレッジ
  ベースをアップロードして統合する方法。

- 魅力的なユーザー体験にとって会話開始メッセージをカスタマイズ手順。

- サポートされていないクエリを適切に対応するためにフォールバック応答を更新する手法。

## 演習4: エージェントのテスト

この演習では、Contoso IT
サポートエージェントの機能を検証するために、テストを行うことに指導します。参加者は、ボットがシームレスな対話とエスカレーションのため、どのようにナレッジベースとフォールバックトピックを使用してプロンプトを処理することを検証します。

1.  右上の**Test**ボタンをクリックします。次に、テストセクションで**Map**をクリックしてOnにし、
    **Refresh**をクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

2.  +++**My printer is not working how to fix
    it**+++プロンプトを入力してください。ナレッジソースに基づいて解決策が表示されます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

3.  再度、+++**Two factor Authentication (2FA) issue**+++ .
    プロンプトを入力します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

1.  2FA の問題と解決策はナレッジ ソースにないので、フォールバック
    トピックに移動し、チケット作成に関連するプロンプトを返します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

**結論**

この演習を完了した上、参加者は習得すること：

- トラブルシューティングのために AI
  エージェントをテストとアクティブ化する方法。

- ナレッジ ベースを使用してボットが応答する能力の検証。

- フォールバック
  トピックがどのようにサポートされていないクエリを処理し、ユーザーを効果的にリダイレクトすること。

## 演習5: Power Automateを使用したサポートチケット作成の自動化

この演習では、Power Automate
を使用してサポートチケット作成の自動化およびContoso IT
サポートエージェントと統合する方法を説明します。参加者は、問題報告の効率化、Dataverse
にデータ記録とサポートエンジニアにメールで通知するフローを作成します。

1.  エージェントの概要ページに移動し、下にスクロールして**+ Add
    action**をクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  アクションの選択ウィンドウで、左上から**+ New
    Action **をクリックし、**New Power Automate Flow **を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  Power Automate フローで、**When an agent calls the
    flow **をクリックし、**Add an Input**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

4.  データタイプのインプットとして**Text**を選択し、入力の名前を +++
    **Name** +++ に変更します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image44.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image45.png)

5.  同じ手順を従って、以下のようにさらにインプットを作成します。

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image46.png)

6.  **When an agent calls the flow**の下、
    **(+)** 記号をクリックし、**Add an action**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

7.  Add an action検索バーに+++**Add a new row**+++を入力します。次に、
    Microsoft Dataverseセクションから**Add a new row**を選択します。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image48.png)

注: Dataverse
接続が自動的に作成されない場合があります。その場合は、資格情報**OAuth認証**を使用して再度**sign
in する**必要があります。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image49.png)

8.  **Table Name **セクションで、 +++**Employee Technical Support
    Record**+++ （または作成したテーブル名)を検索して選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

9.  テーブル名の下で**Show
    all**を選択し、特定のフィールドをクリックして、下の表に従って動的コンテンツボタン（サンダーボルト）を使用してインプットを追加します**Current
    Status** フィールドのドロップダウンで**Unresolved**を選択します。

[TABLE]

10. ![A blue line on a white background AI-generated content may be
    incorrect.](./media/image51.png)

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image52.png)

11. Add a new rowアクションの下で (+)をクリックし、**Add an
    actionを選択します**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image53.png)

12. アクションの追加セクションで、検索バーに+++**Send an
    email**+++を入力し**、** Office 365 Outlook セクションから**send an
    email (V2)** を選択します**。**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

13. 電子メールの送信セクションで、該当するセクションに以下の詳細を入力します。

> **Name, ID,
> Details**のプレースホルダーを動的コンテンツを使用した変数に置き換えます。
>
> **To**
>
> サポート エンジニアのメール アドレスを入力します (**任意のメール ID
> を使用します**- サポート チケットが発行されると、エージェントからこの
> IDにメールが送信されます)
>
> **Subject**
>
> New Technical Support Ticket Raised
>
> **Body**

A new technical support ticket has been raised and requires your
attention. Please find details below:

Employee Name: \< Name \>

Employee ID: \< ID \>

Technical Issue: \< Details \>

Thank you for your prompt attention to this matter.'

Best Regards

![A screenshot of a email AI-generated content may be
incorrect.](./media/image56.png)

14. 左上隅から、フロー名を +++ **Create an Employee Support Ticket** +++
    に変更します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

15. 上部のバーから**Save draft **をクリックし、
    **Publish**をクリックします。Power Automateタブを閉じます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

16. Copilot ウィンドウに戻り、 **Refresh**ボタンをクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

17. アクションの選択ウィンドウで、**Create an Employee Support
    Ticket **フローの作成を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

18. フローを追加するには、 **Add action** ボタンをクリックします。

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image61.png)

19. エージェントの**Overview** ページの**Action**セクションで**Edit**を選択し、アクションのパラメータを編集します。
    **Inputs**セクションを選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

![A screenshot of a support ticket AI-generated content may be
incorrect.](./media/image63.png)

20. 該当するインプットフィールドに指定された説明を入力し、説明を入力した後に**Save**ボタンをクリックします。

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image64.png)
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image65.png)

**結論**

この演習を完了した上、参加者は習得すること：

- チケット作成のために Power Automate フローを Copilot
  エージェントと統合する方法。

- ユーザーの操作から入力データを動的に収集してマッピングする手順。

- 技術的な問題のエスカレーションのための電子メール通知を自動化する手法。

- 効率的なサポート チケット管理のためにワークフローを構成する機能。

## 演習6: 自動アクションのためのメールベースのトリガーの設定

サポートチケット作成の自動化の続きとなるこのセッションでは、Contoso IT
サポートエージェントにトリガーを設定し、メール入力を自動化された Power
Automate
フローにリンクさせることに焦点を当てます。参加者はトリガーを設定し、エージェントの展開を完了させます。

1.  エージェントの概要ページに移動し、下にスクロールして**+ Add
    trigger**をクリックします。

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image66.png)

2.  次に、トリガーの追加ウィンドウから、**When a new email arrives
    (V3) **トリガーを選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

3.  Copilot と Outlook
    の接続が成功し、緑色のチェックマークが表示されたら、
    **Next **ボタンをクリックします。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image68.png)

4.  フォルダー フィールドでフォルダー
    アイコンを選択し、**Inbox** フォルダーを選択して、**Create
    trigger**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image69.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image70.png)

5.  **Time to test your
    trigger **というプロンプトを閉じます。サポートエージェントの概要ページで下にスクロールし、トリガーセクションで3つの点**（…）**をクリックして、
    **Edit in Power Automate**選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image71.png)

6.  When a new email arriveトリガーを右クリックし、
    **Delete**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image72.png)

7.  次に、Add a triggerをクリックし、+++**When new email
    arrives**+++を検索して、 **Office 365 Outlook**セクションから**When
    a new email arrives **トリガーを選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image73.png)

8.  **Send a prompt to the specified copilot for
    processingる**をクリックし、本文/メッセージ セクションに+++**Run
    Create an Employee Support Ticket flow and use content from Body
    From.**+++プロンプトを入力します**。** +++ **Body**と**From
    を**動的コンテンツ変数として置き換えます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image74.png)

9.  フローを**Save**して**Publish**して下さい。それから、power Automate
    ウィンドウを閉じて、Copilot ウィンドウに戻ります。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image75.png)

10. 概要セクションに移動し、右上隅の**Publish **をクリックし、もう一度**Publish **をクリックしてcopilotを公開します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image76.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image77.png)

**結論**

この演習を完了した上、参加者は習得すること：

- メール入力に基づいてワークフローを自動化するために、Copilot
  でトリガーを設定する方法。

- 電子メールの内容を Power Automate フローに動的にマップする手順。

- AI エージェントを運用用に公開し、完成させるプロセス。

- Outlookなどコミュニケーションツールをと自動化されたワークフローとリンクする実践的なスキル。

## 演習7: エージェントのテスト

この演習では、Contoso IT Support Agent と Power Automate および Outlook
の統合をテストすること焦点を当てます。参加者は、エージェントの電子メールの処理、サポートチケットの作成及び自動化されたワークフローを効果的にトリガーする機能を検証します。

1.  エージェントの概要ページに移動し、下にスクロールしてトリガーの**(…)**をクリックし、
    **Edit in power automate**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image78.png)

2.  Power Automate Flow
    に移動し、上部のバーから**Test**ボタンをクリックし、
    **Manually**を選択して、もう一度**Testをクリックします。**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image79.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image80.png)

3.  アクションをトリガーするために、他のメールボックスから365
    管理者テナントのメール
    IDにメールを送信します。メールには問題の説明と、従業員IDなどの詳細情報が記載されている必要があります。下のスクリーンショットをご覧ください。内容の例は以下の通りです。

> Hi Support Team,
>
> I hope this message finds you well.
>
> I　am Mark Brown, working as a Software Engineer at Contoso. My
> employee ID is CONTOSO099
>
> Issue: Monitor is completely blank and not functioning.
>
> Kindly raise a support ticket and assist in resolving this issue at
> the earliest.
>
> Thank you for your support.
>
> Best Regards,  
> Mark Brown

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image81.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image82.png)

4.  Copilot エージェントの概要ページに移動し、下にスクロールして**Test
    trigger**を選択します。

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

5.  **Start testing**をクリックすると、テストが開始されます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image84.png)

6.  テスト
    セクションで**Connect**をクリックすると、接続ウィンドウが開きます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image85.png)

7.  もう一度**Connect**をクリックし、 **Submit**を選択します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image86.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image87.png)

8.  Copilot Studio ウィンドウに移動して、**Test**を再実行します。

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

9.  サポート リクエストは自動的に生成されます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image88.png)

10. Power Apps に移動し、Employee support ticket
    レコードテーブルに移動して、詳細を確認します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image89.png)

11. Power Automate Flow
    でメールを送信するように設定したサポートメールをご確認ください。メールはサポートチームに自動的に送信されます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image90.png)

12. テストウィンドウに移動し、ユーザー として+++**Mark Brown Ticket
    Current
    Status**+++クエリを記述します。問題のステータスは未解決と表示されます。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image91.png)

13. サポート エンジニアとして、テスト セクションに+++**I want to know
    about all Unresolved ticket**+++プロンプトを記述します。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image92.png)

**結論**

この演習を完了した上、参加者は習得すること：

- 現実的なシナリオをシミュレートしてエージェントの機能をテストする方法。

- Power Automate
  でチケットの生成及び電子メールを通じてトリガーされたワークフローを検証する手順。

- Dataverse で生成されたレコードを確認する方法、または、サポート
  チームに通知が送信されていることの確認。

- 自動化ワークフローのデバッグと最終決定に関する実践的な洞察。

## Labガイドの最終結論

このLabガイドでは、Contoso
SolutionsのITサポートサービスデスクにAutonomous
Copilotエージェントを導入する実践的な演習を行いました。すべての演習を一歩に従って、参加者は以下のことを実現しました。

1.  **Copilot Studio のセットアップ**: 参加者は、Copilot Studio
    にログインし、IT サポート
    エージェントを作成して構成し、必要なトラブルシューティングとチケット自動化のために生成
    AI
    やオーケストレーターなどの重要な設定を有効にする方法を学びました。

2.  **Power Apps の操作**: 参加者は、Power Apps へのログイン、Dataverse
    テーブルの設定、Excel からのデータのインポートによるサポート
    チケットの効率的な追跡と管理に関する実践的な知識を習得しました。

3.  **ボットの機能強化**: 演習では、ボットにナレッジ
    ベースを追加し、会話の開始トピックとフォールバック
    トピックをカスタマイズしてユーザー
    インタラクションを改善し、ボットが幅広い IT サポート
    シナリオを処理できることに焦点を当てました。

4.  **IT サポート タスクの自動化**: 参加者は、Power Automate
    を使用してサポート
    チケットの作成を自動化し、ボットの能力を強化して未解決の問題を管理し、IT
    チームのワークフローを改善する方法も学びました。

これらの演習を完了することで、参加者は応答時間の短縮、手動の負荷軽減、そしてITサポート業務全体の生産性向上を実現する、堅牢な自律型サポートシステムを導入することができました。Copilot
Studio、Power
Apps、Dataverseの統合により、シームレスな情報フローが確保され、定型業務が自動化され、サポートワークフローが最適化されます。これにより、従業員は即座にトラブルシューティングの解決策を得られるようになり、未解決の問題についてはチケット管理が自動化されます。
