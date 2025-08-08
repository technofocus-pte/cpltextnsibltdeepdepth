# ラボ 4 - Azure AI Foundry SDK を使用して RAG-basedエージェントを構築、評価、展開する

**所要時間：120分**

## 目的

このラボの目的は、Azure AI Foundry
SDKを使用して、検索拡張生成（RAG）ベースのエージェントを構築、評価、展開することです。このラボでは、プロジェクトと開発環境の設定、AIモデル（GPT-4、text-embedding-ada-002など）の展開、ドキュメント検索のためのAzure
AI
Searchの統合、カスタム知識検索（RAG）チャットアプリケーションの作成について解説します。特に、AIモデルの応答を関連する製品データと関連付け、カスタムチャットインターフェースを開発し、生成された応答のパフォーマンスを評価することに重点を置きます。

## 解決

このソリューションでは、Azure AI Foundry
でのプロジェクトのセットアップ、AI モデル（GPT-4 および
text-embedding-ada-002）のデプロイ、そして Azure AI Search
の統合によるカスタム製品データの保存と取得が行われます。これには、ベクター埋め込みの生成、検索インデックスの構築、そして関連する製品情報のクエリを実行する
Python
スクリプトの作成も含まれます。検索結果を活用して根拠のある応答を提供する
RAG ベースのチャット
インターフェイスが開発され、定義済みのデータセットとメトリックを用いてチャット
アプリのパフォーマンスが評価され、その有効性が向上します。

## 演習0: VMと資格情報を理解する

この演習では、ラボ全体で使用する資格情報を特定し、理解します。

**重要:**
この演習の各ステップを通して、一般的な用語とラボの実行に使用される資格情報を分かるように知なります。

1.  **Instructions **タブには、ラボ全体にわたって従うべき手順が記載されたラボ
    ガイドが含まれています。

2.  **Resources** タブには、ラボの実行に必要な資格情報が表示されます。

    - **URL** – Azure ポータルへの URL

    - **Subscription ** –
      これはあなたに割り当てられた**サブスクリプション**の**IDです**

    - **User name**– **Azure
      サービス**に**ログイン**するために必要な**ユーザー ID** 。

    - Password– **Azure ログイン**の**パスワード**。

**Azureログイン資格情報**と呼びます。Azure**ログイン資格情報**について言及する際には、必ずこの資格情報を使用します。

- **リソース グループ**–割り当てられた**リソース グループ。**

**重要**: すべてのリソースをこのリソース
グループの下に作成してください。

![A screenshot of a computer Description automatically
generated](./media/image1.png)

3.  **Help**タブにはサポート情報が表示されます。ここで表示される**ID**値は、ラボ実行時に使用される**Lab
    instance ID**です。

![A screenshot of a computer Description automatically
generated](./media/image2.png)

## 演習 1: Azure AI Hub リソースとプロジェクトを作成する

この演習では、Azure ポータルでハブを作成し、Azure AI Foundry
でプロジェクトを作成し、モデルをデプロイして、実行に必要なエージェントを作成します。

### タスク1: プロジェクトを作成する

1.  ブラウザから、+++\*\*<https://portal.azure.com/**+++>を開き、**ログイン情報**を使用してログインします**。** **ホーム**ページから**Azure
    AI Foundry**を選択します。

    - ユーザー名 – <+++@lab.CloudPortalCredential> (User1).Username+++

    - パスワード – <+++@lab.CloudPortalCredential> (User1).Password+++

![image](./media/image3.png)

2.  **Use AI Foundry** -\> **AI ハブ**を選択します。 **+ Create **
    -\>**Hub**を選択します。

![image](./media/image4.png)

3.  以下の詳細を入力し、他のデフォルトを受け入れて、 **Review +
    create**を選択します。

    - Subscription -**割り当てられたサブスクリプション**を選択します

    - Resource group- 割り当てられたリソース グループ (
      **ResourceGroup1** )を選択します。

    - Region- @lab.CloudResourceGroup(ResourceGroup1).Location
      を選択します。

    - Name - <+++hub@lab.LabInstance.Id> +++

![image](./media/image5.png)

![image](./media/image6.png)

4.  検証に合格したら**Create** を選択します。

![image](./media/image7.png)

5.  デプロイが完了したら、 **Go to resource**をクリックします。

![image](./media/image8.png)

6.  ハブ リソース ページから**Launch Azure AI Foundry **を選択します。

![image](./media/image9.png)

7.  起動したハブ リソースから下にスクロールして、 **+ New
    project**を選択します。

![image](./media/image10.png)

![image](./media/image11.png)

8.  名前を<+++RAGproj@lab.LabInstance.Id> +++ と入力し、
    **Create**を選択します。

![image](./media/image12.png)

9.  Explore and experimentポップアップをClose**します。**

![image](./media/image13.png)

10. 作成されたプロジェクト ページに移動します。

![image](./media/image14.png)

11. ページを下にスクロールし、**Project connection
    string **の値をメモ帳にコピーします。

![image](./media/image15.png)

12. 左側のペインで下にスクロールし、**Management center**を選択します。

![image](./media/image16.png)

13. ハブ リソースの下にある **Connected resources** を選択し、 **+ New
    connection **をクリックして、Azure AI Foundry
    リソースとの接続を作成します。

![image](./media/image17.png)

14. 利用可能な外部アセットから**Azure AI Foundry** を選択します。

![image](./media/image18.png)

15. **Add connection **を選択します。

![image](./media/image19.png)

![image](./media/image20.png)

16. 接続したら、 **Close**をクリックします。
    **Close**ボタンが表示されない場合は、ブラウザの**ズームサイズ**を縮小してから**Close**を選択してください。

![image](./media/image21.png)

17. 左側のペインから**Go to project **を選択します。

![image](./media/image22.png)

18. **API Key **と**Azure OpenAI
    endpoint**の値をコピーし、メモ帳に保存します。

![image](./media/image23.png)

19. これで、Azure リソースの準備が整いました。

### タスク2: モデルのデプロイ

RAGベースのチャットアプリを構築するには、Azure
OpenAIチャットモデル（gpt-4o-mini）とAzure
OpenAI埋め込みモデル（text-embedding-ada-002）の2つのモデルが必要です。これらのモデルをAzure
AI
Foundryプロジェクトにデプロイし、各モデルごとに以下の手順に従ってください。

カタログからリアルタイムエンドポイントにモデルをデプロイします。

1.  左側のナビゲーション ペインから、**Model catalog**を選択します。

![](./media/image24.png)

2.  モデルリストから+++ **gpt-4o-mini
    +++**モデルを選択してください**。**検索バーを使って検索することもできます。

![A screenshot of a computer Description automatically
generated](./media/image25.png)

3.  モデルの詳細ページで、 **Deploy**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image26.png)

4.  デフォルトの**Deployment name**のままにし**、
    Deploy**を選択します。または、現リージョンでモデルが利用不可能の場合、別のリージョンが自動的に選択され、プロジェクトに接続されます。その場合は、**Create
    resource and deploy**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image27.png)

![](./media/image28.png)

5.  **gpt-4o-mini**をデプロイしたら、 +++ **text-embedding-ada-002** +++
    モデルをデプロイします。**Deployment
    Type **は**Standard**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image29.png)

### タスク 3: Azure AI Search サービスを作成する

このアプリケーションの目標は、モデルの応答をカスタムデータに基づいて構築することです。検索インデックスは、ユーザーの質問に基づいて関連するドキュメントを取得するために使用されます。

検索インデックスを作成するには、Azure AI Search
サービスと接続が必要です。

1.  Azure ログイン資格情報を使用して、 +++
    [https://portal.azure.com+++](https://portal.azure.com+++/)の Azure
    ポータルにログインします。

2.  ホームページの検索バーから+++ **AI search**
    +++を検索して選択します。

![A screenshot of a computer Description automatically
generated](./media/image30.png)

3.  **+ Create **アイコンをクリックし、次の詳細を入力します。

![](./media/image31.png)

4.  以下の詳細を入力し、 **Review + create**を選択します。

    - Subscription – 割り当てられたサブスクリプションを選択します

    - Resource Group – 割り当てられたリソースグループを選択します

    - Service name –
      [**+++aisearch@lab.LabInstance.Id**](mailto:+++aisearch@lab.LabInstance.Id)
      **+++と入力**

    - Region - @lab.CloudResourceGroup(ResourceGroup1).Location
      を選択します。

    - Pricing tier – **Standard**を選択

![A screenshot of a computer Description automatically
generated](./media/image32.png)

5.  詳細を確認し、 **Create**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image33.png)

6.  次の手順に進む前に、以下のスクリーンショットのように、デプロイメントが成功するまで待機します。

![A screenshot of a computer Description automatically
generated](./media/image34.png)

### タスク 4: Azure AI Search をプロジェクトに接続する

Azure AI Foundry ポータルで、Azure AI Search
に接続されたリソースを確認します。

1.  Azure AI Foundry のプロジェクトで、左側のペインから**Management
    center **を選択します。

![A screenshot of a computer Description automatically
generated](./media/image35.png)

2.  **Connected resources **セクションで、 **New connection **を選択し、
    **Azure AI Search**を選択します。

![](./media/image36.png)

![](./media/image37.png)

3.  **Authentication **の下の**API key **を選択し、 **Add
    connection**を選択します。

![A screenshot of a search engine Description automatically
generated](./media/image38.png)

![A screenshot of a search engine Description automatically
generated](./media/image39.png)

4.  **Connected
    resources **ページで、追加されたリソース接続を確認できるようになりました。

![](./media/image40.png)

### タスク 5: Azure CLI をインストールしてサインインする

Azure CLI
をインストールし、ローカル開発環境からサインインすると、ユーザー資格情報を使用して
Azure OpenAI サービスを呼び出すことができます。

1.  Windowsの検索バーで+++ **PowerShell
    +++**を検索し、**Administrator **モードで開きます。起動を続行するには、プロンプトが表示されたら承認してください。

![A screenshot of a computer Description automatically
generated](./media/image41.png)

2.  Windows Power Shell を開き、以下のコマンドを貼り付けて実行します。

> $progressPreference = 'silentlyContinue'
>
> Write-Host "Installing WinGet PowerShell module from PSGallery..."
>
> Install-PackageProvider -Name NuGet -Force | Out-Null
>
> Install-Module -Name Microsoft.WinGet.Client -Force -Repository
> PSGallery | Out-Null
>
> Write-Host "Using Repair-WinGetPackageManager cmdlet to bootstrap
> WinGet..."
>
> Repair-WinGetPackageManager
>
> Write-Host "Done."

3.  次のコマンドを使用して、ターミナルから Azure CLI
    をインストールします。

> +++ winget install -e --id Microsoft.AzureCLI +++

**Y**を選択して**Enter** キーを押します。

![A screenshot of a computer Description automatically
generated](./media/image42.png)

![](./media/image43.png)

![](./media/image44.png)

4.  Azure CLI をインストールしたら、 az login
    コマンドを使用してサインインし、ブラウザーを使用してサインインします。

> +++ azログイン+++

**Work or school account **を選択し、 **Continue**をクリックします。

![A screenshot of a computer screen Description automatically
generated](./media/image45.png)

5.  **Azure login credentials**を使用してログインします。

![A computer screen shot of a program Description automatically
generated](./media/image46.png)

6.  **Select a subscription **プロンプトに**1** と入力し、 **Enter**
    キーを押します。

![A screenshot of a computer Description automatically
generated](./media/image47.png)

### タスク6: 新しいPython環境を作成する

まず、このチュートリアルに必要なパッケージをインストールするための新しいPython環境を作成する必要があります。グローバルPythonインストールにパッケージをインストールしないでください。Pythonパッケージをインストールする際は、必ず仮想環境またはconda環境を使用してください。そうしないと、Pythonのグローバルインストールが壊れる可能性があります。

**重要:**以下のコマンドが貼り付けられない場合は、メモ帳に貼り付けてからコピーしてPowerShellに貼り付けてください。または、PowerShellに直接コピーして貼り付けてください。PowerShellでは、Tボタンが機能しない場合があります。

**仮想環境を作成する**

1.  Power Shell
    から以下のコマンドを実行して**C:\Users\Admin**に移動します。

> CD**\\**
>
> cd Users\Admin

2.  PowerShellで次のコマンドを入力して、プロジェクト名[**RAGproj@lab.LabInstance.Id**](mailto:RAGproj@lab.LabInstance.Id)のフォルダーを作成します。

> mkdir RAGproj@lab.LabInstance.Id

![A computer screen with white and green text Description automatically
generated](./media/image48.png)

3.  ターミナルで次のコマンドを入力して、新しいフォルダの場所に移動します。

> cd RAGproj@lab.LabInstance.Id

![A blue screen with white text Description automatically
generated](./media/image49.png)

4.  次のコマンドを使用して仮想環境を作成します

> py -3 -m venv . venv
>
> . venv\scripts\activate

![A computer screen shot of a code Description automatically
generated](./media/image50.png)

Python 環境をアクティブ化すると、コマンド ラインから python または pip
を実行するときに、アプリケーションの.venvフォルダーに含まれる Python
インタープリターが使用されるようになります。

5.  **VS Code**を開きます。 **File -\> Open
    Folder **を選択し、前の手順で作成した**RAGprojectフ**ォルダー**（ C:
    \Users\Admin** ）を選択します。

**注:** プロンプトが表示されたら \[Yes, I trust the folder and content\]
をクリックし、続行します。

![A screenshot of a computer Description automatically
generated](./media/image51.png)

![A screenshot of a computer Description automatically
generated](./media/image52.png)

![A screenshot of a computer Description automatically
generated](./media/image53.png)

6.  **Do you trust the authors of the files in this
    folder?**というメッセージが表示されたら、 **Yes, I trust the
    authors **を選択します。

### タスク7: パッケージをインストールする

azure-ai-projects(preview) と azure-ai-inference (preview)
を他の必要なパッケージとともにインストールします。

1.  **Project** フォルダーに+++ **requirements.txt
    +++**という名前のファイルを作成し、次のパッケージをファイルに追加します。

> azure-ai-projects==1.0.0b10  
> azure-ai-inference\[prompts\]
>
> azure-identity
>
> azure-search-documents
>
> pandas
>
> python-dotenv
>
> opentelemetry-api
>
> marshmallow==3.23.2

![](./media/image54.png)

![](./media/image55.png)

2.  上部のナビゲーション バーで、 **File **、 **Save
    All**をクリックします。

3.  requirements.txt を右クリックし、**Open in Integrated
    Terminal**を選択します。

![](./media/image56.png)

![A screenshot of a computer Description automatically
generated](./media/image57.png)

4.  仮想環境に入るには次のコマンドを実行します

> +++ py -3 -m venv . venv +++
>
> +++. venv \scripts\activate+++

![A screenshot of a computer Description automatically
generated](./media/image58.png)

5.  +++ az login+++ コマンドを実行し、Azure
    ログイン資格情報でログインします。サブスクリプションを選択するには、
    **1**を選択します。

**注:**ログイン プロンプトが自動的に表示されない場合は、VS Code
を最小化して表示してください。

![A screenshot of a computer Description automatically
generated](./media/image59.png)

![A screenshot of a computer Description automatically
generated](./media/image60.png)

6.  必要なパッケージをインストールするには、次のコードを実行します。

+++pip install -r requirements.txt+++

![A screenshot of a computer Description automatically
generated](./media/image61.png)

![A screenshot of a computer Description automatically
generated](./media/image62.png)

**注:** pip
の新しいリリースの通知を受け取った場合は、以下のコマンドを実行して pip
をアップグレードしてください。

+++pip install -r requirements.txt+++

+++python.exe -m pip install --upgrade pip+++

![A screenshot of a computer program Description automatically
generated](./media/image63.png)

### タスク8: ヘルパースクリプトを作成する

1.  ターミナルで次のコマンドを実行して、
    **src**という名前の新しいフォルダを作成します。

+++mkdir src+++

![A screenshot of a computer Description automatically
generated](./media/image64.png)

2.  **src**フォルダに新しいファイルを作成し、+++ **config.py**
    +++という名前を付けます。

![A screenshot of a computer Description automatically
generated](./media/image65.png)

3.  次のコードを**config.py**に追加して保存します。

> \# ruff: noqa: ANN201, ANN001
>
> import os
>
> import sys
>
> import pathlib
>
> import logging
>
> from azure.identity import DefaultAzureCredential
>
> from azure.ai.projects import AIProjectClient
>
> from azure.ai.inference.tracing import AIInferenceInstrumentor
>
> \# load environment variables from the .env file
>
> from dotenv import load_dotenv
>
> load_dotenv()
>
> \# Set "./assets" as the path where assets are stored, resolving the
> absolute path:
>
> ASSET_PATH = pathlib.Path(\_\_file\_\_).parent.resolve() / "assets"
>
> \# Configure an root app logger that prints info level logs to stdout
>
> logger = logging.getLogger("app")
>
> logger.setLevel(logging.INFO)
>
> logger.addHandler(logging.StreamHandler(stream=sys.stdout))
>
> \# Returns a module-specific logger, inheriting from the root app
> logger
>
> def get_logger(module_name):
>
> return logging.getLogger(f"app.{module_name}")
>
> \# Enable instrumentation and logging of telemetry to the project
>
> def enable_telemetry(log_to_project: bool = False):
>
> AIInferenceInstrumentor().instrument()
>
> \# enable logging message contents
>
> os.environ\["AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED"\] =
> "true"
>
> if log_to_project:
>
> from azure.monitor.opentelemetry import configure_azure_monitor
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> tracing_link =
> f"https://ai.azure.com/tracing?wsid=/subscriptions/{project.scope\['subscription_id'\]}/resourceGroups/{project.scope\['resource_group_name'\]}/providers/Microsoft.MachineLearningServices/workspaces/{project.scope\['project_name'\]}"
>
> application_insights_connection_string =
> project.telemetry.get_connection_string()
>
> if not application_insights_connection_string:
>
> logger.warning(
>
> "No application insights configured, telemetry will not be logged to
> project. Add application insights at:"
>
> )
>
> logger.warning(tracing_link)
>
> return
>
> configure_azure_monitor(connection_string=application_insights_connection_string)
>
> logger.info("Enabled telemetry logging to project, view traces at:")
>
> logger.info(tracing_link)

![A screenshot of a computer Description automatically
generated](./media/image66.png)

**注**: この新しく作成された config.py ファイル
スクリプトは、次の演習で使用されます。

### タスク9: 環境変数を構成する

コードからAzure
OpenAIサービスを呼び出すには、プロジェクトの接続文字列が必要です。このクイックスタートでは、この値を.envファイルに保存します。.envファイルは、アプリケーションが読み取れる環境変数を含むファイルです。

1.  **src**ディレクトリに新しいファイル**+++. env
    +++**を作成し、次のコードを貼り付けます。

**\< your-connection-string \>**を、タスク 1
でメモ帳に保存したプロジェクト接続文字列の値に置き換えます。

> AIPROJECT_CONNECTION_STRING="\<your-connection-string\>"
>
> AISEARCH_INDEX_NAME="example-index"
>
> EMBEDDINGS_MODEL="text-embedding-ada-002"
>
> INTENT_MAPPING_MODEL="gpt-4o-mini"
>
> CHAT_MODEL="gpt-4o-mini"
>
> EVALUATION_MODEL="gpt-4o-mini"

![](./media/image67.png)

**注**: 接続文字列は、Azure AI Foundry
プロジェクトのホームページの**Overview**に記載されています。

## 演習 2: Azure AI Foundry SDK を使用してカスタム知識検索 (RAG) アプリを構築する

### タスク 1: チャット アプリのサンプル データを作成する

このRAG-basedアプリの目標は、カスタムデータにモデルの応答を組み込むことです。埋め込みモデルからのベクトル化されたデータを格納する
Azure AI Search
インデックスを使用します。この検索インデックスは、ユーザーの質問に基づいて関連ドキュメントを取得するために使用されます。

1.  開いている VS Code セットアップから、 **src**フォルダーの下に **+++
    assets** +++という名前のフォルダーを作成します。

![A screenshot of a computer Description automatically
generated](./media/image68.png)

2.  **C: \LabFiles**から**products.csv**ファイルをコピーし、 **C:
    \Users\Admin\< Your Project Name \>\\ src
    \assets**フォルダーに貼り付けます。

**注:**これはファイル エクスプローラーで実行する必要があり、その後 VS
Code に反映されます。

![A screenshot of a computer Description automatically
generated](./media/image69.png)

3.  上部のナビゲーション バーの**File **に移動し、**Save
    All**をクリックします。

![A screenshot of a computer Description automatically
generated](./media/image70.png)

### タスク2: 検索インデックスを作成する

検索インデックスは、埋め込みモデルからのベクトル化されたデータを保存するために使用されます。検索インデックスは、ユーザーの質問に基づいて関連するドキュメントを検索するために使用されます。

1.  **src**フォルダ**ー**に+++ **create_search_index.py
    +++**という名前のファイルを作成します。

![A screenshot of a computer Description automatically
generated](./media/image71.png)

2.  作成されたファイル**create_search_index.py**ファイルを開き、次のコードを追加して、必要なライブラリをインポートし、プロジェクト
    クライアントを作成し、いくつかの設定を構成します。

> import os
>
> from azure.ai.projects import AIProjectClient
>
> from azure.ai.projects.models import ConnectionType
>
> from azure.identity import DefaultAzureCredential
>
> from azure.core.credentials import AzureKeyCredential
>
> from azure.search.documents import SearchClient
>
> from azure.search.documents.indexes import SearchIndexClient
>
> from config import get_logger
>
> \# initialize logging object
>
> logger = get_logger(\_\_name\_\_)
>
> \# create a project client using environment variables loaded from the
> .env file
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> \# create a vector embeddings client that will be used to generate
> vector embeddings
>
> embeddings = project.inference.get_embeddings_client()
>
> \# use the project client to get the default search connection
>
> search_connection = project.connections.get_default(
>
> connection_type=ConnectionType.AZURE_AI_SEARCH,
> include_credentials=True
>
> )
>
> \# Create a search index client using the search connection
>
> \# This client will be used to create and delete search indexes
>
> index_client = SearchIndexClient(
>
> endpoint=search_connection.endpoint_url,
> credential=AzureKeyCredential(key=search_connection.key)
>
> )

![A screenshot of a computer Description automatically
generated](./media/image72.png)

3.  **create_search_index.py**の最後に関数を追加して、検索インデックスを定義します。

カーソルをファイルの末尾に置き、 **Enter** キーを2
回押して、以下のコードを貼り付けます。

import pandas as pd

> from azure.search.documents.indexes.models import (
>
> SemanticSearch,
>
> SearchField,
>
> SimpleField,
>
> SearchableField,
>
> SearchFieldDataType,
>
> SemanticConfiguration,
>
> SemanticPrioritizedFields,
>
> SemanticField,
>
> VectorSearch,
>
> HnswAlgorithmConfiguration,
>
> VectorSearchAlgorithmKind,
>
> HnswParameters,
>
> VectorSearchAlgorithmMetric,
>
> ExhaustiveKnnAlgorithmConfiguration,
>
> ExhaustiveKnnParameters,
>
> VectorSearchProfile,
>
> SearchIndex,
>
> )
>
> def create_index_definition(index_name: str, model: str) -\>
> SearchIndex:
>
> dimensions = 1536 \# text-embedding-ada-002
>
> if model == "text-embedding-3-large":
>
> dimensions = 3072
>
> \# The fields we want to index. The "embedding" field is a vector
> field that will
>
> \# be used for vector search.
>
> fields = \[
>
> SimpleField(name="id", type=SearchFieldDataType.String, key=True),
>
> SearchableField(name="content", type=SearchFieldDataType.String),
>
> SimpleField(name="filepath", type=SearchFieldDataType.String),
>
> SearchableField(name="title", type=SearchFieldDataType.String),
>
> SimpleField(name="url", type=SearchFieldDataType.String),
>
> SearchField(
>
> name="contentVector",
>
> type=SearchFieldDataType.Collection(SearchFieldDataType.Single),
>
> searchable=True,
>
> \# Size of the vector created by the text-embedding-ada-002 model.
>
> vector_search_dimensions=dimensions,
>
> vector_search_profile_name="myHnswProfile",
>
> ),
>
> \]
>
> \# The "content" field should be prioritized for semantic ranking.
>
> semantic_config = SemanticConfiguration(
>
> name="default",
>
> prioritized_fields=SemanticPrioritizedFields(
>
> title_field=SemanticField(field_name="title"),
>
> keywords_fields=\[\],
>
> content_fields=\[SemanticField(field_name="content")\],
>
> ),
>
> )
>
> \# For vector search, we want to use the HNSW (Hierarchical Navigable
> Small World)
>
> \# algorithm (a type of approximate nearest neighbor search algorithm)
> with cosine
>
> \# distance.
>
> vector_search = VectorSearch(
>
> algorithms=\[
>
> HnswAlgorithmConfiguration(
>
> name="myHnsw",
>
> kind=VectorSearchAlgorithmKind.HNSW,
>
> parameters=HnswParameters(
>
> m=4,
>
> ef_construction=1000,
>
> ef_search=1000,
>
> metric=VectorSearchAlgorithmMetric.COSINE,
>
> ),
>
> ),
>
> ExhaustiveKnnAlgorithmConfiguration(
>
> name="myExhaustiveKnn",
>
> kind=VectorSearchAlgorithmKind.EXHAUSTIVE_KNN,
>
> parameters=ExhaustiveKnnParameters(metric=VectorSearchAlgorithmMetric.COSINE),
>
> ),
>
> \],
>
> profiles=\[
>
> VectorSearchProfile(
>
> name="myHnswProfile",
>
> algorithm_configuration_name="myHnsw",
>
> ),
>
> VectorSearchProfile(
>
> name="myExhaustiveKnnProfile",
>
> algorithm_configuration_name="myExhaustiveKnn",
>
> ),
>
> \],
>
> )
>
> \# Create the semantic settings with the configuration
>
> semantic_search = SemanticSearch(configurations=\[semantic_config\])
>
> \# Create the search index definition
>
> return SearchIndex(
>
> name=index_name,
>
> fields=fields,
>
> semantic_search=semantic_search,
>
> vector_search=vector_search,
>
> )

![A screenshot of a computer Description automatically
generated](./media/image73.png)

4.  次に、create_search_index.py に関数を追加して、インデックスに csv
    ファイルを追加する関数を作成します。

カーソルをファイルの末尾に置き、 **Enter** キーを2
回押して、以下のコードを貼り付けます。

> \# define a function for indexing a csv file, that adds each row as a
> document
>
> \# and generates vector embeddings for the specified content_column
>
> def create_docs_from_csv(path: str, content_column: str, model: str)
> -\> list\[dict\[str, any\]\]:
>
> products = pd.read_csv(path)
>
> items = \[\]
>
> for product in products.to_dict("records"):
>
> content = product\[content_column\]
>
> id = str(product\["id"\])
>
> title = product\["name"\]
>
> url = f"/products/{title.lower().replace(' ', '-')}"
>
> emb = embeddings.embed(input=content, model=model)
>
> rec = {
>
> "id": id,
>
> "content": content,
>
> "filepath": f"{title.lower().replace(' ', '-')}",
>
> "title": title,
>
> "url": url,
>
> "contentVector": emb.data\[0\].embedding,
>
> }
>
> items.append(rec)
>
> return items
>
> def create_index_from_csv(index_name, csv_file):
>
> \# If a search index already exists, delete it:
>
> try:
>
> index_definition = index_client.get_index(index_name)
>
> index_client.delete_index(index_name)
>
> logger.info(f"🗑️ Found existing index named '{index_name}', and
> deleted it")
>
> except Exception:
>
> pass
>
> \# create an empty search index
>
> index_definition = create_index_definition(index_name,
> model=os.environ\["EMBEDDINGS_MODEL"\])
>
> index_client.create_index(index_definition)
>
> \# create documents from the products.csv file, generating vector
> embeddings for the "description" column
>
> docs = create_docs_from_csv(path=csv_file,
> content_column="description", model=os.environ\["EMBEDDINGS_MODEL"\])
>
> \# Add the documents to the index using the Azure AI Search client
>
> search_client = SearchClient(
>
> endpoint=search_connection.endpoint_url,
>
> index_name=index_name,
>
> credential=AzureKeyCredential(key=search_connection.key),
>
> )
>
> search_client.upload_documents(docs)
>
> logger.info(f"➕ Uploaded {len(docs)} documents to '{index_name}'
> index")

![A screenshot of a computer Description automatically
generated](./media/image74.png)

5.  最後に、create_search_index.py
    に以下の関数を追加してインデックスを作成し、クラウドプロジェクトに登録します。コードを追加したら、上部のバーからFilesに移動し**Save
    all**をクリックします。

カーソルをファイルの末尾に置き、
**Enter**キーを2回押します。新しい行の左端にカーソルを移動し、コードを貼り付けます。（タブスペースは不要です）

**重要:**下記のコードの2行目にあるimport
argparseが、マージンからタブスペースで揃えられていることを確認してください。そうでない場合は、**import **前にカーソルを移動したまま**Tab**キーを押してください。

> if \_\_name\_\_ == "\_\_main\_\_":
>
> import argparse
>
> parser = argparse.ArgumentParser()
>
> parser.add_argument(
>
> "--index-name",
>
> type=str,
>
> help="index name to use when creating the AI Search index",
>
> default=os.environ\["AISEARCH_INDEX_NAME"\],
>
> )
>
> parser.add_argument(
>
> "--csv-file", type=str, help="path to data for creating search index",
> default="assets/products.csv"
>
> )
>
> args = parser.parse_args()
>
> index_name = args.index_name
>
> csv_file = args.csv_file
>
> create_index_from_csv(index_name, csv_file)

![](./media/image75.png)

6.  ファイルの内容は以下のようになるはずです。

> import os
>
> from azure.ai.projects import AIProjectClient
>
> from azure.ai.projects.models import ConnectionType
>
> from azure.identity import DefaultAzureCredential
>
> from azure.core.credentials import AzureKeyCredential
>
> from azure.search.documents import SearchClient
>
> from azure.search.documents.indexes import SearchIndexClient
>
> from config import get_logger
>
> \# initialize logging object
>
> logger = get_logger(\_\_name\_\_)
>
> \# create a project client using environment variables loaded from the
> .env file
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> \# create a vector embeddings client that will be used to generate
> vector embeddings
>
> embeddings = project.inference.get_embeddings_client()
>
> \# use the project client to get the default search connection
>
> search_connection = project.connections.get_default(
>
> connection_type=ConnectionType.AZURE_AI_SEARCH,
> include_credentials=True
>
> )
>
> \# Create a search index client using the search connection
>
> \# This client will be used to create and delete search indexes
>
> index_client = SearchIndexClient(
>
> endpoint=search_connection.endpoint_url,
> credential=AzureKeyCredential(key=search_connection.key)
>
> )
>
> import pandas as pd
>
> from azure.search.documents.indexes.models import (
>
> SemanticSearch,
>
> SearchField,
>
> SimpleField,
>
> SearchableField,
>
> SearchFieldDataType,
>
> SemanticConfiguration,
>
> SemanticPrioritizedFields,
>
> SemanticField,
>
> VectorSearch,
>
> HnswAlgorithmConfiguration,
>
> VectorSearchAlgorithmKind,
>
> HnswParameters,
>
> VectorSearchAlgorithmMetric,
>
> ExhaustiveKnnAlgorithmConfiguration,
>
> ExhaustiveKnnParameters,
>
> VectorSearchProfile,
>
> SearchIndex,
>
> )
>
> def create_index_definition(index_name: str, model: str) -\>
> SearchIndex:
>
> dimensions = 1536 \# text-embedding-ada-002
>
> if model == "text-embedding-3-large":
>
> dimensions = 3072
>
> \# The fields we want to index. The "embedding" field is a vector
> field that will
>
> \# be used for vector search.
>
> fields = \[
>
> SimpleField(name="id", type=SearchFieldDataType.String, key=True),
>
> SearchableField(name="content", type=SearchFieldDataType.String),
>
> SimpleField(name="filepath", type=SearchFieldDataType.String),
>
> SearchableField(name="title", type=SearchFieldDataType.String),
>
> SimpleField(name="url", type=SearchFieldDataType.String),
>
> SearchField(
>
> name="contentVector",
>
> type=SearchFieldDataType.Collection(SearchFieldDataType.Single),
>
> searchable=True,
>
> \# Size of the vector created by the text-embedding-ada-002 model.
>
> vector_search_dimensions=dimensions,
>
> vector_search_profile_name="myHnswProfile",
>
> ),
>
> \]
>
> \# The "content" field should be prioritized for semantic ranking.
>
> semantic_config = SemanticConfiguration(
>
> name="default",
>
> prioritized_fields=SemanticPrioritizedFields(
>
> title_field=SemanticField(field_name="title"),
>
> keywords_fields=\[\],
>
> content_fields=\[SemanticField(field_name="content")\],
>
> ),
>
> )
>
> \# For vector search, we want to use the HNSW (Hierarchical Navigable
> Small World)
>
> \# algorithm (a type of approximate nearest neighbor search algorithm)
> with cosine
>
> \# distance.
>
> vector_search = VectorSearch(
>
> algorithms=\[
>
> HnswAlgorithmConfiguration(
>
> name="myHnsw",
>
> kind=VectorSearchAlgorithmKind.HNSW,
>
> parameters=HnswParameters(
>
> m=4,
>
> ef_construction=1000,
>
> ef_search=1000,
>
> metric=VectorSearchAlgorithmMetric.COSINE,
>
> ),
>
> ),
>
> ExhaustiveKnnAlgorithmConfiguration(
>
> name="myExhaustiveKnn",
>
> kind=VectorSearchAlgorithmKind.EXHAUSTIVE_KNN,
>
> parameters=ExhaustiveKnnParameters(metric=VectorSearchAlgorithmMetric.COSINE),
>
> ),
>
> \],
>
> profiles=\[
>
> VectorSearchProfile(
>
> name="myHnswProfile",
>
> algorithm_configuration_name="myHnsw",
>
> ),
>
> VectorSearchProfile(
>
> name="myExhaustiveKnnProfile",
>
> algorithm_configuration_name="myExhaustiveKnn",
>
> ),
>
> \],
>
> )
>
> \# Create the semantic settings with the configuration
>
> semantic_search = SemanticSearch(configurations=\[semantic_config\])
>
> \# Create the search index definition
>
> return SearchIndex(
>
> name=index_name,
>
> fields=fields,
>
> semantic_search=semantic_search,
>
> vector_search=vector_search,
>
> )
>
> \# define a function for indexing a csv file, that adds each row as a
> document
>
> \# and generates vector embeddings for the specified content_column
>
> def create_docs_from_csv(path: str, content_column: str, model: str)
> -\> list\[dict\[str, any\]\]:
>
> products = pd.read_csv(path)
>
> items = \[\]
>
> for product in products.to_dict("records"):
>
> content = product\[content_column\]
>
> id = str(product\["id"\])
>
> title = product\["name"\]
>
> url = f"/products/{title.lower().replace(' ', '-')}"
>
> emb = embeddings.embed(input=content, model=model)
>
> rec = {
>
> "id": id,
>
> "content": content,
>
> "filepath": f"{title.lower().replace(' ', '-')}",
>
> "title": title,
>
> "url": url,
>
> "contentVector": emb.data\[0\].embedding,
>
> }
>
> items.append(rec)
>
> return items
>
> def create_index_from_csv(index_name, csv_file):
>
> \# If a search index already exists, delete it:
>
> try:
>
> index_definition = index_client.get_index(index_name)
>
> index_client.delete_index(index_name)
>
> logger.info(f"🗑️ Found existing index named '{index_name}', and
> deleted it")
>
> except Exception:
>
> pass
>
> \# create an empty search index
>
> index_definition = create_index_definition(index_name,
> model=os.environ\["EMBEDDINGS_MODEL"\])
>
> index_client.create_index(index_definition)
>
> \# create documents from the products.csv file, generating vector
> embeddings for the "description" column
>
> docs = create_docs_from_csv(path=csv_file,
> content_column="description", model=os.environ\["EMBEDDINGS_MODEL"\])
>
> \# Add the documents to the index using the Azure AI Search client
>
> search_client = SearchClient(
>
> endpoint=search_connection.endpoint_url,
>
> index_name=index_name,
>
> credential=AzureKeyCredential(key=search_connection.key),
>
> )
>
> search_client.upload_documents(docs)
>
> logger.info(f"➕ Uploaded {len(docs)} documents to '{index_name}'
> index")
>
> if \_\_name\_\_ == "\_\_main\_\_":
>
> import argparse
>
> parser = argparse.ArgumentParser()
>
> parser.add_argument(
>
> "--index-name",
>
> type=str,
>
> help="index name to use when creating the AI Search index",
>
> default=os.environ\["AISEARCH_INDEX_NAME"\],
>
> )
>
> parser.add_argument(
>
> "--csv-file", type=str, help="path to data for creating search index",
> default="assets/products.csv"
>
> )
>
> args = parser.parse_args()
>
> index_name = args.index_name
>
> csv_file = args.csv_file
>
> create_index_from_csv(index_name, csv_file)

6.  **create_search_index.py**を右クリックし、**Open in integrated
    terminal**を選択します。

![](./media/image76.png)

7.  ターミナルから Azure
    ログイン資格情報にログインし、アカウントを認証するための手順に従います。

+++az login+++

![](./media/image77.png)

![](./media/image78.png)

8.  コードを実行してローカルでインデックスを構築し、クラウド
    プロジェクトに登録します。

+++python create_search_index.py+++

![](./media/image79.png)

9.  スクリプトを実行すると、Azure Portal
    から新しく作成されたインデックスを表示できます。

10. 割り当てられた**Resource Group -\> Your search service
    created(aisearchLabinstanceID) -\> Search management -\>
    Indexes**に移動します。

![A screenshot of a computer Description automatically
generated](./media/image80.png)

11. 同じインデックス名でスクリプトを再度実行すると、同じインデックスの新しいバージョンが作成されます。

### タスク3: プロダクトドキュメントを取得する

次に、検索インデックスから製品ドキュメントを取得するスクリプトを作成します。このスクリプトは、検索インデックスに対して、ユーザーの質問に一致するドキュメントをクエリします。

**プロダクトドキュメントを取得するためのスクリプトを作成する**

チャットはリクエストを受け取ると、データを検索して関連情報を探します。このスクリプトはAzure
AI
SDKを使用して検索インデックスを照会し、ユーザーの質問に一致するドキュメントを検索します。そして、そのドキュメントをチャットアプリに返します。

1.  **src**フォルダーに+++ **get_product_documents.py
    +++**という名前のファイルを作成します。

![A screenshot of a computer Description automatically
generated](./media/image81.png)

2.  以下のコードをコピーしてファイルに貼り付けます。必要なライブラリをインポートし、プロジェクトクライアントを作成し、設定を構成するコードから始めます。

import os

from pathlib import Path

from opentelemetry import trace

from azure.ai.projects import AIProjectClient

from azure.ai.projects.models import ConnectionType

from azure.identity import DefaultAzureCredential

from azure.core.credentials import AzureKeyCredential

from azure.search.documents import SearchClient

from config import ASSET_PATH, get_logger

\# initialize logging and tracing objects

logger = get_logger(\_\_name\_\_)

tracer = trace.get_tracer(\_\_name\_\_)

\# create a project client using environment variables loaded from the
.env file

project = AIProjectClient.from_connection_string(

conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
credential=DefaultAzureCredential()

)

\# create a vector embeddings client that will be used to generate
vector embeddings

chat = project.inference.get_chat_completions_client()

embeddings = project.inference.get_embeddings_client()

\# use the project client to get the default search connection

search_connection = project.connections.get_default(

connection_type=ConnectionType.AZURE_AI_SEARCH, include_credentials=True

)

\# Create a search index client using the search connection

\# This client will be used to create and delete search indexes

search_client = SearchClient(

index_name=os.environ\["AISEARCH_INDEX_NAME"\],

endpoint=search_connection.endpoint_url,

credential=AzureKeyCredential(key=search_connection.key),

)

3.  Add the function in get_product-documents.py to **get product
    documents**.

from azure.ai.inference.prompts import PromptTemplate

from azure.search.documents.models import VectorizedQuery

@tracer.start_as_current_span(name="get_product_documents")

def get_product_documents(messages: list, context: dict = None) -\>
dict:

if context is None:

context = {}

overrides = context.get("overrides", {})

top = overrides.get("top", 5)

\# generate a search query from the chat messages

intent_prompty = PromptTemplate.from_prompty(Path(ASSET_PATH) /
"intent_mapping.prompty")

intent_mapping_response = chat.complete(

model=os.environ\["INTENT_MAPPING_MODEL"\],

messages=intent_prompty.create_messages(conversation=messages),

\*\*intent_prompty.parameters,

)

search_query = intent_mapping_response.choices\[0\].message.content

logger.debug(f"🧠 Intent mapping: {search_query}")

\# generate a vector representation of the search query

embedding = embeddings.embed(model=os.environ\["EMBEDDINGS_MODEL"\],
input=search_query)

search_vector = embedding.data\[0\].embedding

\# search the index for products matching the search query

vector_query = VectorizedQuery(vector=search_vector,
k_nearest_neighbors=top, fields="contentVector")

search_results = search_client.search(

search_text=search_query, vector_queries=\[vector_query\],
select=\["id", "content", "filepath", "title", "url"\]

)

documents = \[

{

"id": result\["id"\],

"content": result\["content"\],

"filepath": result\["filepath"\],

"title": result\["title"\],

"url": result\["url"\],

}

for result in search_results

\]

\# add results to the provided context

if "thoughts" not in context:

context\["thoughts"\] = \[\]

\# add thoughts and documents to the context object so it can be
returned to the caller

context\["thoughts"\].append(

{

"title": "Generated search query",

"description": search_query,

}

)

if "grounding_data" not in context:

context\["grounding_data"\] = \[\]

context\["grounding_data"\].append(documents)

logger.debug(f"📄 {len(documents)} documents retrieved: {documents}")

return documents

4.  Finally, add code to **test the function** when you run the script
    directly:

if \_\_name\_\_ == "\_\_main\_\_":

import logging

import argparse

\# set logging level to debug when running this module directly

logger.setLevel(logging.DEBUG)

\# load command line arguments

parser = argparse.ArgumentParser()

parser.add_argument(

"--query",

type=str,

help="Query to use to search product",

default="I need a new tent for 4 people, what would you recommend?",

)

args = parser.parse_args()

query = args.query

result = get_product_documents(messages=\[{"role": "user", "content":
query}\])

![A screenshot of a computer Description automatically
generated](./media/image82.png)

5.  **File\> Save all**をクリックします。

![](./media/image83.png)

### タスク4: インテントマッピング用プロンプトテンプレートを作成する

get_product_documents.pyスクリプトは、プロンプトテンプレートを使用して会話を検索クエリに変換します。このテンプレートは**、**会話からユーザーのインテントを抽出する方法を指示します。

1.  スクリプトを実行する前に、プロンプトテンプレートを作成します。**assets**フォルダ内に**+++intent_mapping.prompty+++**というファイルを作成します。

![](./media/image84.png)

2.  次のコードをintent_mapping_promptyファイルにコピーし、上部のバーからFileに移動して**Save
    all**をクリックします。

> ---

name: Chat Prompt

description: A prompty that extract users query intent based on the
current_query and chat_history of the conversation

model:

api: chat

configuration:

azure_deployment: gpt-4o

inputs:

conversation:

type: array

---

system:

\# Instructions

\- You are an AI assistant reading a current user query and
chat_history.

\- Given the chat_history, and current user's query, infer the user's
intent expressed in the current user query.

\- Once you infer the intent, respond with a search query that can be
used to retrieve relevant documents for the current user's query based
on the intent

\- Be specific in what the user is asking about, but disregard parts of
the chat history that are not relevant to the user's intent.

\- Provide responses in json format

\# Examples

Example 1:

With a conversation like below:

\- user: are the trailwalker shoes waterproof?

\- assistant: Yes, the TrailWalker Hiking Shoes are waterproof. They are
designed with a durable and waterproof construction to withstand various
terrains and weather conditions.

\- user: how much do they cost?

Respond with:

{

"intent": "The user wants to know how much the Trailwalker Hiking Shoes
cost.",

"search_query": "price of Trailwalker Hiking Shoes"

}

Example 2:

With a conversation like below:

\- user: are the trailwalker shoes waterproof?

\- assistant: Yes, the TrailWalker Hiking Shoes are waterproof. They are
designed with a durable and waterproof construction to withstand various
terrains and weather conditions.

\- user: how much do they cost?

\- assistant: The TrailWalker Hiking Shoes are priced at $110.

\- user: do you have waterproof tents?

\- assistant: Yes, we have waterproof tents available. Can you please
provide more information about the type or size of tent you are looking
for?

\- user: which is your most waterproof tent?

\- assistant: Our most waterproof tent is the Alpine Explorer Tent. It
is designed with a waterproof material and has a rainfly with a
waterproof rating of 3000mm. This tent provides reliable protection
against rain and moisture.

\- user: how much does it cost?

Respond with:

{

"intent": "The user would like to know how much the Alpine Explorer Tent
costs.",

"search_query": "price of Alpine Explorer Tent"

}

user:

Return the search query for the messages in the following conversation:

{{#conversation}}

\- {{role}}: {{content}}

{{/conversation}}

![A screenshot of a computer Description automatically
generated](./media/image85.png)

### タスク5: プロダクトドキュメント取得スクリプトをテストする

1.  スクリプトとテンプレートが完成されたので、スクリプトを実行して、検索インデックスがクエリに対してどのようなドキュメントを返すかをテストします。ターミナルウィンドウから以下を実行します。

+++python get_product_documents.py --query "I need a new tent for 4
people, what would you recommend?"+++![A screenshot of a computer
Description automatically generated](./media/image86.png)

### タスク6: カスタム知識検索(RAG)コードを開発する

次に、基本的なチャット アプリケーションにretrieval augmented generation
(RAG) 機能を追加するカスタム コードを作成します。

**RAG機能を備えたチャットスクリプトを作成する**

1.  **src**フォルダに、+++ **chat_with_products.py
    +++**という新しいファイルを作成します。このスクリプトは製品ドキュメントを取得し、ユーザーの質問への回答を生成します。

![A screenshot of a computer Description automatically
generated](./media/image87.png)

2.  必要なライブラリをインポートし、プロジェクト
    クライアントを作成し、設定を構成するコードを追加します。

> import os
>
> from pathlib import Path
>
> from opentelemetry import trace
>
> from azure.ai.projects import AIProjectClient
>
> from azure.identity import DefaultAzureCredential
>
> from config import ASSET_PATH, get_logger, enable_telemetry
>
> from get_product_documents import get_product_documents
>
> \# initialize logging and tracing objects
>
> logger = get_logger(\_\_name\_\_)
>
> tracer = trace.get_tracer(\_\_name\_\_)
>
> \# create a project client using environment variables loaded from the
> .env file
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> \# create a chat client we can use for testing
>
> chat = project.inference.get_chat_completions_client()

![A screenshot of a computer Description automatically
generated](./media/image88.png)

3.  RAG 機能を使用するチャット機能を作成するには、chat_with_products.py
    の最後にコードを追加します。

> from azure.ai.inference.prompts import PromptTemplate
>
> @tracer.start_as_current_span(name="chat_with_products")
>
> def chat_with_products(messages: list, context: dict = None) -\> dict:
>
> if context is None:
>
> context = {}
>
> documents = get_product_documents(messages, context)
>
> \# do a grounded chat call using the search results
>
> grounded_chat_prompt = PromptTemplate.from_prompty(Path(ASSET_PATH) /
> "grounded_chat.prompty")
>
> system_message =
> grounded_chat_prompt.create_messages(documents=documents,
> context=context)
>
> response = chat.complete(
>
> model=os.environ\["CHAT_MODEL"\],
>
> messages=system_message + messages,
>
> \*\*grounded_chat_prompt.parameters,
>
> )
>
> logger.info(f"💬 Response: {response.choices\[0\].message}")
>
> \# Return a chat protocol compliant response
>
> return {"message": response.choices\[0\].message, "context": context}

![A screenshot of a computer Description automatically
generated](./media/image89.png)

4.  **チャット機能**を実行するコードを追加し、 使用してファイルに移動し、**Save
    all**をクリックします。

if \_\_name\_\_ == "\_\_main\_\_":

import argparse

\# load command line arguments

parser = argparse.ArgumentParser()

parser.add_argument(

"--query",

type=str,

help="Query to use to search product",

default="I need a new tent for 4 people, what would you recommend?",

)

parser.add_argument(

"--enable-telemetry",

action="store_true",

help="Enable sending telemetry back to the project",

)

args = parser.parse_args()

if args.enable_telemetry:

enable_telemetry(True)

\# run chat with products

response = chat_with_products(messages=\[{"role": "user", "content":
args.query}\])![A screenshot of a computer Description automatically
generated](./media/image90.png)

### タスク7: グラウンディングされたチャットプロンプトテンプレートを作成する

**chat_with_products.py**スクリプトは、プロンプトテンプレートを呼び出して、ユーザーの質問への応答を生成します。このテンプレートは、ユーザーの質問と取得したドキュメントに基づいて応答を生成する方法を指示します。テンプレートを作成してください。

1.  **assets **フォルダに、ファイル +++ **grounded\_ chat.prompty**
    +++を追加します。

![A screenshot of a computer Description automatically
generated](./media/image91.png)

2.  次のコードgrounded\_ chat.promptyを追加します。

> ---

name: Chat with documents

description: Uses a chat completions model to respond to queries
grounded in relevant documents

model:

api: chat

configuration:

azure_deployment: gpt-4o

inputs:

conversation:

type: array

---

system:

You are an AI assistant helping users with queries related to outdoor
outdooor/camping gear and clothing.

If the question is not related to outdoor/camping gear and clothing,
just say 'Sorry, I only can answer queries related to outdoor/camping
gear and clothing. So, how can I help?'

Don't try to make up any answers.

If the question is related to outdoor/camping gear and clothing but
vague, ask for clarifying questions instead of referencing documents. If
the question is general, for example it uses "it" or "they", ask the
user to specify what product they are asking about.

Use the following pieces of context to answer the questions about
outdoor/camping gear and clothing as completely, correctly, and
concisely as possible.

Do not add documentation reference in the response.

\# Documents

{{#documents}}

\## Document {{id}}: {{title}}

{{content}}

{{/documents}}

![A screenshot of a computer Description automatically
generated](./media/image92.png)

3.  **File\> Save all**をクリックします。

![A screenshot of a computer Description automatically
generated](./media/image93.png)

### タスク8: RAG機能を使用してチャットスクリプトを実行する

1.  スクリプトとテンプレートの両方ができたので、スクリプトを実行して、RAG
    機能を備えたチャット アプリをテストします。

+++python chat_with_products.py --query " I need a new tent for 4
people, what would you recommend?"+++

![A screenshot of a computer Description automatically
generated](./media/image94.png)

### タスク9: テレメトリログを追加する

1.  Azure
    ポータルから**Subscriptions**を選択し**、**サブスクリプションを選択して、左側のナビゲーション
    ウィンドウの**Settings**の下にある**Resource
    providers **を選択します。

2.  **Microsoft.OperationalInsights +++**を検索して選択し、このリソース
    プロバイダーの 3 つのドットをクリックして、
    **Register**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image95.png)

3.  同じ手順に従って+++ microsoft.insights +++を登録してください

4.  次のステップに進む前に、登録の成功メッセージをお待ちください。

![A screenshot of a computer Description automatically
generated](./media/image96.png)

5.  Azure AI Foundryのプロジェクトで、左側のペインから**Access and
    improve **の**Tracing **を選択し**、 Create New**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image97.png)

6.  名前を[**+++appinsight@lab.LabInstance.Id**](mailto:+++appinsight@lab.LabInstance.Id)
    **+++**として指定します。

![A screenshot of a computer screen Description automatically
generated](./media/image98.png)

7.  リソースが作成されたことを確認します。

![A screenshot of a computer Description automatically
generated](./media/image99.png)

8.  プロジェクトへのテレメトリのログ記録を有効にするには、 VS Code
    にazure-monitor- opentelemetry をインストールします。

+++pip install azure-monitor-opentelemetry+++![A screenshot of a
computer program Description automatically
generated](./media/image100.png)

9.  chat_with_products.py スクリプトを使用するときは、
    --enable-telemetry フラグを追加します。

+++python chat_with_products.py --query "I need a new tent for 4 people,
what would you recommend?" --enable-telemetry+++![A screenshot of a
computer Description automatically generated](./media/image101.png)

## 演習 3: Azure AI Foundry SDK を使用してカスタム チャット アプリを評価する

### タスク1: チャットアプリの応答質を評価する

チャット履歴を含め、チャット
アプリがクエリに適切に応答することがわかったので、次はいくつかの異なる指標とより多くのデータに基づいてチャット
アプリのパフォーマンスを評価します。

評価データセットとget_chat\_ response ( )
ターゲット関数を備えたエバリュエータを使用し、評価結果を確認します。

評価を実行すると、システムプロンプトの改善など、ロジックを改善したり、チャットアプリの応答がどのように変化して改善されるかを確認したりできます。

**評価データセットを作成する**

質問例と期待される回答 (真実) を含む次の評価データセットを使用します。

1.  **assets **フォルダーに+++ **chat_eval\_ data.jsonl
    +++**というファイルを作成します。

![](./media/image102.png)

2.  このデータセットをファイルに貼り付けて、ファイルを**保存します。**

{"query": "Which tent is the most waterproof?", "truth": "The Alpine
Explorer Tent has the highest rainfly waterproof rating at 3000m"}

{"query": "Which camping table holds the most weight?", "truth": "The
Adventure Dining Table has a higher weight capacity than all of the
other camping tables mentioned"}

{"query": "How much do the TrailWalker Hiking Shoes cost? ", "truth":
"The Trailewalker Hiking Shoes are priced at $110"}

{"query": "What is the proper care for trailwalker hiking shoes? ",
"truth": "After each use, remove any dirt or debris by brushing or
wiping the shoes with a damp cloth."}

{"query": "What brand is TrailMaster tent? ", "truth": "OutdoorLiving"}

{"query": "How do I carry the TrailMaster tent around? ", "truth": "
Carry bag included for convenient storage and transportation"}

{"query": "What is the floor area for Floor Area? ", "truth": "80 square
feet"}

{"query": "What is the material for TrailBlaze Hiking Pants?", "truth":
"Made of high-quality nylon fabric"}

{"query": "What color does TrailBlaze Hiking Pants come in?", "truth":
"Khaki"}

{"query": "Can the warrenty for TrailBlaze pants be transfered? ",
"truth": "The warranty is non-transferable and applies only to the
original purchaser of the TrailBlaze Hiking Pants. It is valid only when
the product is purchased from an authorized retailer."}

{"query": "How long are the TrailBlaze pants under warranty for? ",
"truth": " The TrailBlaze Hiking Pants are backed by a 1-year limited
warranty from the date of purchase."}

{"query": "What is the material for PowerBurner Camping Stove? ",
"truth": "Stainless Steel"}  
{"query": "Is France in Europe?", "truth": "Sorry, I can only queries
related to outdoor/camping gear and equipment"}![A screenshot of a
computer Description automatically generated](./media/image103.png)

### タスク 2: Azure AI エバリュエータによる評価

次の評価スクリプトを定義します。

- チャット アプリのロジックを囲むターゲット関数ラッパーを生成します。

- sample.jsonlデータセットを読み込みます。

- 評価を実行します。評価では、ターゲット関数が取得され、評価データセットがチャット
  アプリからの応答とマージされます。

- チャット アプリの応答の品質を評価するために、 GPT -assistedメトリック
  (relevance, groundedness, coherence) のセットを生成します。

- 結果をローカルに出力し、クラウド プロジェクトに結果を記録します。

このスクリプトを使用すると、結果をコマンドラインおよびjsonファイルに出力して、ローカルで結果を確認できます。

このスクリプトは、評価結果をクラウド プロジェクトに記録し、UI
で評価実行を比較できるようにします。

1.  **src**フォルダーの下に **+++ evaluate.py**
    +++というファイルを作成します。

![A screenshot of a computer Description automatically
generated](./media/image104.png)

2.  必要なライブラリをインポートし、プロジェクト
    クライアントを作成し、いくつかの設定を構成するには、次のコードを追加します。

import os

import pandas as pd

from azure.ai.projects import AIProjectClient

from azure.ai.projects.models import ConnectionType

from azure.ai.evaluation import evaluate, GroundednessEvaluator

from azure.identity import DefaultAzureCredential

from chat_with_products import chat_with_products

\# load environment variables from the .env file at the root of this
repo

from dotenv import load_dotenv

load_dotenv()

\# create a project client using environment variables loaded from the
.env file

project = AIProjectClient.from_connection_string(

conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
credential=DefaultAzureCredential()

)

connection =
project.connections.get_default(connection_type=ConnectionType.AZURE_OPEN_AI,
include_credentials=True)

evaluator_model = {

"azure_endpoint": connection.endpoint_url,

"azure_deployment": os.environ\["EVALUATION_MODEL"\],

"api_version": "2024-06-01",

"api_key": connection.key,

}

groundedness = GroundednessEvaluator(evaluator_model)![A screenshot of a
computer Description automatically generated](./media/image105.png)

3.  クエリと応答の評価用の評価インターフェースを実装するラッパー関数を作成するコードを追加します。

def evaluate_chat_with_products(query):

response = chat_with_products(messages=\[{"role": "user", "content":
query}\])

return {"response": response\["message"\].content, "context":
response\["context"\]\["grounding_data"\]}![A screenshot of a computer
Description automatically generated](./media/image106.png)

4.  最後に、評価を実行し、結果をローカルで表示し、AI Foundry
    ポータルの評価結果へのリンクを提供するコードを追加します。

> \# Evaluate must be called inside of \_\_main\_\_, not on import
>
> if \_\_name\_\_ == "\_\_main\_\_":
>
> from config import ASSET_PATH
>
> \# workaround for multiprocessing issue on linux
>
> from pprint import pprint
>
> from pathlib import Path
>
> import multiprocessing
>
> import contextlib
>
> with contextlib.suppress(RuntimeError):
>
> multiprocessing.set_start_method("spawn", force=True)
>
> \# run evaluation with a dataset and target function, log to the
> project
>
> result = evaluate(
>
> data=Path(ASSET_PATH) / "chat_eval_data.jsonl",
>
> target=evaluate_chat_with_products,
>
> evaluation_name="evaluate_chat_with_products",
>
> evaluators={
>
> "groundedness": groundedness,
>
> },
>
> evaluator_config={
>
> "default": {
>
> "query": {"${data.query}"},
>
> "response": {"${target.response}"},
>
> "context": {"${target.context}"},
>
> }
>
> },
>
> azure_ai_project=project.scope,
>
> output_path="./myevalresults.json",
>
> )
>
> tabular_result = pd.DataFrame(result.get("rows"))
>
> pprint("-----Summarized Metrics-----")
>
> pprint(result\["metrics"\])
>
> pprint("-----Tabular Result-----")
>
> pprint(tabular_result)
>
> pprint(f"View evaluation results in AI Studio:
> {result\['studio_url'\]}")

![A screenshot of a computer Description automatically
generated](./media/image107.png)

5.  上部のナビゲーション バーの**File **の下にある**Save
    all **をクリックします。

### タスク3: 評価モデルを構成する

評価スクリプトはモデルを何度も呼び出すため、評価モデルの 1
分あたりのトークン数を増やすことが勧められています。

最初に、評価モデル名 gpt-4o-mini
を指定した**.env**ファイルを作成しました。使用可能なクォータがある場合は、このモデルの
1
分あたりのトークン制限を増やしてみてください。クォータが足りず値を増やすことができない場合でも、スクリプトは制限エラーを処理するように設計されています。

1.  Azure AI Foundry ポータルのプロジェクトから、 **Models +
    endpoints **を選択し、 **gpt-4o-mini**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image108.png)

2.  **gpt-4o-mini**を選択し、 **Edit**をクリックします。

![A screenshot of a computer Description automatically
generated](./media/image109.png)

3.  **「Tokens per Minute Rate Limit **の値を最大許容制限に設定し、
    **Save and close**を選択します。

![A screenshot of a computer Description automatically
generated](./media/image110.png)

### タスク4: 評価を実行する

1.  VS Code
    ターミナルに、以下のコマンドを実行して必要なパッケージをインストールします。

+++pip install azure- ai -evaluation\[remote\]+++

2.  評価スクリプトを実行するには、以下のコードを実行します。

+++python evaluate.py+++

評価が完了するまでに約 5 ～ 10 分かかります。

![](./media/image111.png)

### タスク 5: Azure AI Foundry ポータルで評価結果を確認する

1.  評価実行が完了したら、リンクからAzure AI Foundry
    ポータルのEvaluationページで評価結果を表示します。

![](./media/image112.png)

![](./media/image113.png)

2.  **評価結果**と**Metrics dashboard**を確認します。

![](./media/image114.png)

![](./media/image115.png)

## 演習4: リソースを削除する

1.  Azureポータルのホームページから、割り当てられたResource
    groupを選択します。Resource
    groupの下にあるすべてのリソースを選択し、Deleteを選択します。

![A screenshot of a computer Description automatically
generated](./media/image116.png)

2.  +++ **delete** +++ と入力し、
    **Delete**ボタンをクリックして削除を確定します。削除確認ダイアログボックスで**Delete**をクリックします。

![A screenshot of a computer Description automatically
generated](./media/image117.png)

3.  成功メッセージですべてのリソースの削除を確認します。

![A screenshot of a computer screen Description automatically
generated](./media/image118.png)

## 要旨

このlabでは、RAG
を備えたアプリケーションを構築、評価、展開する方法を学びました。
