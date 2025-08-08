# 实验 5 - 使用 Azure AI Foundry 和搜索集成创建自定义 AI 代理

**预计时间：45 分钟**

## 目的

本实验室的目标是指导参与者使用 Azure AI 服务和搜索集成构建 AI
支持的代理。检索增强生成 （RAG）
是一种用于构建应用程序的技术，这些应用程序将自定义数据源中的数据集成到生成式
AI 模型的提示中。RAG 是开发生成式 AI
应用程序的一种常用模式，基于聊天的应用程序使用语言模型来解释输入并生成适当的响应。参与者将学习使用
Azure AI Foundry 门户将自定义数据集成到生成式 AI 提示流中。

## 解决

此实验室侧重于将 Azure AI
服务与高级搜索功能集成，以创建强大、智能的解决方案。它强调配置 AI
驱动的代理、实现无缝数据检索以及提供上下文响应。通过利用 AI
和搜索集成，该解决方案旨在通过直观高效的交互简化工作流程、改进决策并提高用户参与度。

## 任务 1：创建 Azure AI 搜索资源

1.  在 Web 浏览器中，打开 Azure 门户（网址为
    +++[https://portal.azure.com+++](https://portal.azure.com+++/)）并使用以下方式**Sign
    in** 

- 用户名 - <+++@lab.CloudPortalCredential>(User1).Username+++

- 密码 - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer Description automatically
generated](./media/image1.png)

2.  在主页上，选择 **+ Create a resource。**

![A screenshot of a computer Description automatically
generated](./media/image2.png)

3.   在搜索栏中，搜索并选择 +++ **Azure AI Search**+++。

![A screenshot of a computer Description automatically
generated](./media/image3.png)

4.  选择 **Create** 旁边的下拉列表， 然后选择 **Azure AI Search**。

![A screenshot of a computer Description automatically
generated](./media/image4.png)

5.  在 Create a search service 页面中，输入以下详细信息，然后单击
    **Review + create**。

    - **订阅**：从下拉列表中选择你的 Azure 订阅。

    - **资源组**：选择分配给订阅的资源组 （ResourceGroup1）

    - **服务名称**：<+++aisearch@lab.LabInstance.Id>+++

    - **位置**：选择 @lab.CloudResourceGroup(ResourceGroup1).Location

    &nbsp;

    - **定价层**： Standard

![A screenshot of a computer Description automatically
generated](./media/image5.png)

6.  查看设置，然后单击 **Create**。

![A screenshot of a search service Description automatically
generated](./media/image6.png)

7.  等待 Azure AI 搜索资源部署完成。

![A screenshot of a computer Description automatically
generated](./media/image7.png)

## 任务 2：创建 Azure AI Hub 资源和项目

1.  从 Azure 门户**Home**中选择 **Azure AI Foundry**。

![image](./media/image8.png)

2.  选择 **Use with AI Foundry** -\> **AI Hubs**。选择 **+ Create** -\>
    **Hub**

![image](./media/image9.png)

3.  输入以下详细信息，接受其他默认值，然后选择 **Review + create**。

    - 订阅 - 选择**已分配的订阅**

    - ResourceGroup - 选择已分配的资源组 （**ResourceGroup1**）

    - 区域 - 选择 @ @lab.CloudResourceGroup(ResourceGroup1).Location

    &nbsp;

    - 名字 -
      +++[**hub@lab.LabInstance.Id**](mailto:hub@lab.LabInstance.Id)+++

![image](./media/image10.png)

![image](./media/image11.png)

4.  评估通过后，选择 **Create**。

![image](./media/image12.png)

5.  部署完成后，单击 **Go to resource**。

![image](./media/image13.png)

6.  从中心资源页中选择“**Launch Azure AI Foundry** ”。

![image](./media/image14.png)

7.  从启动的中心资源中，向下滚动并选择 **+ New project**

![image](./media/image15.png)

![image](./media/image16.png)

8.  输入名称
    +++[**ragpfproject@lab.LabInstance.Id+**](mailto:ragpfproject@lab.LabInstance.Id)++，然后选择
    **Create**。

![image](./media/image17.png)

9.  **Close** Explore and experiment 弹出窗口。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image18.png)

10. 您将进入创建的项目页面。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

## 任务 3：部署模型

您需要两个模型来实现您的解决方案:

- 一种嵌入模型，用于矢量化文本数据以实现高效的索引和处理。

- 一种可以根据您的数据生成对问题的自然语言响应的模型。

1.  在左侧窗格中的 **My assets** 下选择 **Models + endpoints**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

2.  在 **Manage deployments of your models and services**
    页面上**，**单击 **+Deploy model** **，**然后选择 **Deploy base
    model。**

![A screenshot of a computer Description automatically
generated](./media/image21.png)

3.  在 **Select a model** 页面上，搜索并选择
    +++**text-embedding-ada-002**+++ model，然后单击 **Confirm。**

![A screenshot of a computer Description automatically
generated](./media/image22.png)

4.  在 **Deploy model text-embedding-ada-002** 窗格中，接受 **Deployment
    name** 选择 **Deployment type** 为 **standard**的预填充值。单击
    **Customize** 并在 Deploy model 向导中输入以下详细信息。

![A screenshot of a computer Description automatically
generated](./media/image23.png)

- **模型版本**：选择默认版本

- **AI 资源**：选择之前创建的资源（即下拉列表中列出的资源）

- **每分钟令牌数速率限制（千）：**5K

- **内容过滤器**：DefaultV2

- **启用动态配额**：已禁用

![A screenshot of a computer Description automatically
generated](./media/image24.png)

![A screenshot of a computer Description automatically
generated](./media/image25.png)

![A screenshot of a computer Description automatically
generated](./media/image26.png)

5.  重复上述步骤，部署部署名称为 gpt-4o 的 +++**gpt-4o**+++ 模型。

![A screenshot of a computer Description automatically
generated](./media/image27.png)

6.  现在，我们已经准备好了两个部署。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

\[!Note\] **注意**：减少每分钟令牌数 (TPM)
有助于避免过度使用所用订阅中的可用配额。对于本练习中使用的数据，5,000
TPM 已足够。

## 任务 4：向项目添加数据

您的 copilot 的数据由一组来自虚构旅行社 *Margie's Travel* 的 PDF
格式的旅行手册组成。让我们将它们添加到项目中。

1.  在左侧窗格中的 **My assets** 下选择 **Data + indexes** 。选择 **+
    New data**。

![A screenshot of a computer Description automatically
generated](./media/image29.png)

2.  在 **Add your data** 向导中，从下拉列表中选择 **Upload
    files/folders**。

![A screenshot of a computer Description automatically
generated](./media/image30.png)

3.  选择 **Upload folder** 并从 **C：\LabFiles** 中选择 brochures
    **文件夹** ，然后单击 **Upload**。

![A screenshot of a computer Description automatically
generated](./media/image31.png)

![A screenshot of a computer Description automatically
generated](./media/image32.png)

4.  等待文件夹上传，并注意它包含多个.pdf文件。选择 **Next **
    文件全部上传后。

![A screenshot of a computer Description automatically
generated](./media/image33.png)

5.  在下一页的 name and finish 中，输入数据名称
    +++[**data@lab.LabInstance.Id**](mailto:data@lab.LabInstance.Id)+++，然后单击
    **Create。**

![A screenshot of a computer Description automatically
generated](./media/image34.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

## 任务 5：为您的数据创建索引

现在，你已将数据源添加到项目中，可以使用它在 Azure AI
搜索资源中创建索引。

1.  从 **Data + indexes** 页面，选择 **Indexes** 选项卡。

![A screenshot of a computer Description automatically
generated](./media/image36.png)

2.  在 **Indexes** 选项卡中，选择 **+ New index** 以添加新索引。

![A screenshot of a computer Description automatically
generated](./media/image37.png)

3.  输入以下详细信息，然后单击Next。

    - **Data source** - 选择**Data in Azure AI Foundry**

选择列出的**data source**，然后单击 **Next**。

![A screenshot of a computer Description automatically
generated](./media/image38.png)

1.  在 Create a vector index – Index configuration
    页面中输入以下详细信息，然后单击 **Next。**

    - **Select Azure AI Search service**: 选择 **AzureAISearch**

    - Vector index - +++**brochures-index**+++

    - **Virtual machine**: 选择**Auto select**

![A screenshot of a computer Description automatically
generated](./media/image39.png)

2.  在 Create a vector index – Search settings （创建向量索引 –
    搜索设置） 页面中，

**Vector settings ** - 选择 **Add vector search to this search
resource**

接受其他默认值，然后选择 **Next。**

![A screenshot of a search box Description automatically
generated](./media/image40.png)

3.  在 **Review and finish** 页面中，查看详细信息并选择 **Create vector
    index** 。

![A screenshot of a computer Description automatically
generated](./media/image41.png)

4.  等待索引过程完成，这可能需要几分钟时间。索引创建作包括以下作业:

    - 将文本标记破解、分块并嵌入到您的宣传册数据中。

    - 创建 Azure AI Search index。

    - 注册索引资产。

![A screenshot of a computer error Description automatically
generated](./media/image42.png)

![A screenshot of a computer program Description automatically
generated](./media/image43.png)

## 任务 6：测试索引

在基于 RAG 的提示流中使用索引之前，让我们验证一下它是否可用于影响
generative AI 响应。

1.  从左侧窗格中选择 **Playgrounds**，然后选择 **Chat Playground。**

![A screenshot of a chat Description automatically
generated](./media/image44.png)

2.  如果默认情况下不可见，请点击“**Show setup**”。

![A screenshot of a computer Description automatically
generated](./media/image45.png)

3.  确保已选择 **gpt-4o** 模型部署。然后，在主聊天会话面板中，提交提示
    +++**Where can I stay in New York?**+++

![A screenshot of a computer program Description automatically
generated](./media/image46.png)

![A screenshot of a chat Description automatically
generated](./media/image47.png)

4.  查看响应，该响应应该是模型中的通用答案，不包含索引中的任何数据。

5.  在 设置 窗格中，展开 **Add your data** 字段，选择
    **brochures-index** 项目索引，然后选择 **hybrid (vector +
    keyword)** 搜索类型。

![A screenshot of a computer Description automatically
generated](./media/image48.png)

**\[!Note\]**
注意：有些用户会发现新创建的索引立即不可用。刷新浏览器通常可以解决问题，但如果您仍然遇到无法找到索引的问题，则可能需要等待索引被识别。

6.  添加数据源将启动一个新会话。完成后，重新提交提示+++**Where can I
    stay in New York?**+++

![A screenshot of a chat Description automatically
generated](./media/image49.png)

7.  查看响应并注意，现在响应基于索引中的数据。

![A screenshot of a chat Description automatically
generated](./media/image50.png)

## 任务 7：在提示流中使用索引

您的向量索引已保存在 Azure AI Foundry
项目中，使您能够在提示流中轻松使用它。

1.  从左侧导航窗格中的 **Build and customize** 下选择 **Prompt
    flow**，然后单击 **Create**。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

2.  选择“**Multi-Round Q&A on Your Data**”下的“**Clone** ”。 

![A screenshot of a computer Description automatically
generated](./media/image52.png)

3.  将文件夹命名为+++**brochure-flow**+++，然后单击“**Clone**”。

![A screenshot of a computer Description automatically
generated](./media/image53.png)

\[!Note\] **注意**：如果遇到权限错误，请在 2
分钟后使用新名称重试，流程将被克隆。

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

4.  当提示流设计器页面打开时，查看
    **brochure-flow**。其图形应类似于下图:

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

![A screenshot a a prompt flow graph](./media/image56.png)

您正在使用的示例提示流实现了聊天应用程序的提示逻辑，在该应用程序中，用户可以迭代地将文本输入提交到聊天界面。聊天历史记录将保留并包含在每个迭代的上下文中。提示流编排一系列* tools*，以:

1.  将历史记录附加到聊天输入，以问题的上下文化形式定义提示。

2.  使用您的索引和您根据问题选择的查询类型检索上下文。

3.  使用从索引中检索到的数据来增强问题，从而生成提示上下文。

4.  通过添加系统消息和构建聊天历史记录来创建提示变体。

5.  将提示提交到语言模型以生成自然语言响应。

&nbsp;

5.  使用 **Start compute session** 按钮启动流的运行时计算。

等待运行时启动。这为提示流提供了计算上下文。等待时，在 **Flow**
选项卡中，查看流中工具的部分。

![A screenshot of a computer screen Description automatically
generated](./media/image57.png)

6.  在 **Inputs** 部分中，确保输入包括:

    1.  **chat_history**

    2.  **chat_input**

此示例中的默认聊天历史记录包括一些有关 AI 的对话。

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image58.png)

7.  在 **Outputs** 部分中，确保输出包含:

    - 值为 ${chat_with_context.output 的 **chat_output**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

8.  在 **modify_query_with_history**
    部分中，选择以下设置（保持其他设置不变):

    - **Connection**：为 列出的 AI 中心选择 **Azure OpenAI 资源**

    - **Api**：选择 **chat**

    - **deployment_name**：选择 **gpt-4o**

    &nbsp;

    - **response_format**：选择 **{“type”:”text”}**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

9.  计算会话启动后，在 **lookup** 部分中，设置以下参数值:

    - **mlindex_content**: *选择空字段以打开 Generate 窗格*

      - **index_type**: 选择**Registered Index**

 

- **mlindex_asset_id**: 选择 **brochures-index:1**

![A screenshot of a computer Description automatically
generated](./media/image61.png)

![A screenshot of a computer Description automatically
generated](./media/image62.png)

返回 Lookup 部分，输入以下详细信息

- **queries**: ${modify_query_with_history.output}

- **query_type**: Hybrid (vector + keyword)

- **top_k**: 2

![A screenshot of a computer Description automatically
generated](./media/image63.png)

10. 在 **generate_prompt_context** 部分中，查看 Python 脚本并确保
    此工具的 **inputs **包含以下参数:

    - **search_result** *(object)*: ${lookup.output}

![A screenshot of a computer Description automatically
generated](./media/image64.png)

11. 在 **Prompt_variants** 部分中，查看 Python 脚本并确保
    此工具的** inputs** 包含以下参数:

    - **contexts** *(string)*: ${generate_prompt_context.output}

    - **chat_history** *(string)*: ${inputs.chat_history}

    - **chat_input** *(string)*: ${inputs.chat_input}

![A screenshot of a chat Description automatically
generated](./media/image65.png)

12. 在 **chat_with_context** 部分中，选择以下设置（保持其他设置不变）):

    - **Connection**: 选择**Azure OpenAI resource**

    - **Api**: Chat

    - **deployment_name**: gpt-4o

    - **response_format**: {“type”:”text”}

然后，确保 此工具的输入包括以下参数:

- **prompt_text** *(string)*: ${Prompt_variants.output}

![A screenshot of a computer Description automatically
generated](./media/image66.png)

13. 选择 工具栏中的 **Save** 按钮，以保存您对提示流中的工具所做的更改。

![A screenshot of a computer Description automatically
generated](./media/image67.png)

14. 从工具栏中，选择
    **Chat**。此时将打开一个聊天窗格，其中包含示例对话历史记录和已根据示例值填充的输入。您可以忽略这些。

![A screenshot of a computer Description automatically
generated](./media/image68.png)

15. 在聊天窗格中，将默认输入替换为问题 +++**Where can I stay in
    London？**+++ 并提交。

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image69.png)

16. 响应基于索引中的数据。

17. 查看流程中每个工具的输出。

![A screenshot of a computer Description automatically
generated](./media/image70.png)

18. 在Chat窗格中，输入问题 **+++ What can I do there?+++**

19. 查看响应，该响应应基于索引中的数据，并考虑**chat
    history**（因此“**there**”应理解为“**in London**”）。

![A screenshot of a chat Description automatically
generated](./media/image71.png)

20. 查看流程中每个工具的输出，注意流程中的每个工具如何对其输入进行作，以准备上下文化的提示并获得适当的响应。

## 任务 8：清理资源:

1.  在 Azure 门户
    （+++[https://portal.azure.com+++](https://portal.azure.com+++/)）
    中，选择 **ResourceGroup1**（分配给你的那个）。

2.  选择其下的所有资源，然后单击 **Delete** 。

![A screenshot of a computer Description automatically
generated](./media/image72.png)

3.  输入 +++**delete**+++ 并单击 **Delete** 按钮确认删除。单击
    **Delete** 确认对话框中的 Delete。

![A screenshot of a computer Description automatically
generated](./media/image73.png)

4.  确保通过删除确认消息删除资源。

![A screenshot of a computer screen Description automatically
generated](./media/image74.png)

## 总结

在本实验中，我们学习了如何创建自定义代理，该代理使用你自己的 **Azure AI
Foundry** 中的数据。
