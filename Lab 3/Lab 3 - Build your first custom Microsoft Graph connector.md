# Lab 3 - Build your first custom Microsoft Graph connector

Estimated time: 90 mins

## Objective

The objective of this lab guide is to teach participants how to build a
**custom Microsoft Graph connector** using the Microsoft Graph
connectors API. The custom connector integrates external data into
Microsoft Graph to power Microsoft 365 experiences like Microsoft
Search. The lab uses a sample data set (appliance parts inventory for
the Contoso Appliance Repair organization) to demonstrate the process of
creating and deploying the connector.

## Solution focus area

The lab guide focuses on enabling participants to integrate external
data into Microsoft Graph by creating a custom connector. It emphasizes
the implementation of app-only authentication using Microsoft Entra ID,
allowing secure access to Microsoft Graph APIs. Participants build a
.NET console application that processes and manages external data,
leveraging Entity Framework to create and maintain a database for the
appliance parts inventory. The lab also covers schema definition and
registration for the custom connector, along with methods to upload,
update, and delete data items using the Microsoft Graph API.
Additionally, it guides participants in customizing Microsoft Search by
creating search verticals and result types to display the data in
Microsoft 365 experiences, including SharePoint, Office, and Bing.
Finally, the lab ensures a practical understanding by running the
application and validating the connector's functionality through
real-time data surfacing in Microsoft Search.

## Exercise 1: Register the app in the portal

In this exercise you'll register a new application in Microsoft Entra ID to enable [app-only
authentication](https://learn.microsoft.com/en-us/graph/auth-v2-service).
Microsoft Graph connectors use app-only authentication to access the
connector APIs.

### Task 0: Sync Host environment time

1.  Login to the Lab Virtual Machine using the credentials provided on
    the Home tab of the Lab interface. 


2.  In your VM, navigate and click in the **Search bar**, type
    **Settings** and then click on **Settings** under **Best match**.
    
    ![](./media/image01.png)


2.  On Settings window, navigate and click on **Time & language**. 

    ![](./media/image02.png)

3.  On **Time & language** page, navigate and click on **Date & time**. 

    ![](./media/image03.png)


4.  Scroll down and navigate to **Additional settings** section, then
    click on **Syn now** button.  

    ![](./media/image04.png)


5.  Close the **Settings** window.  

    ![](./media/image05.png)


6.  In your lab VM, open Microsoft Edge and enter +++**http://www.microsoftazurepass.com**+++

    ![](./media/image06.png)

7.  On **Ready to get started?** page, click on the **Start** button. 

    ![](./media/image07.jpeg)


    > **Note**: Do not use your Company/Work Account to login to redeem the Azure Pass, another Azure Pass will not be issued. 

8.  In the **Sign in** window, enter the **Office 365 Tenant ID** -
    <admin@WWLxxxx.onmicrosoft.com> and click on the **Next** button. 

    ![](./media/image08.png)

9.  Enter Office **365 Tenant Password** and click on the **Sign in**
    button. 

    ![](./media/image09.png)

10.  On **Stayed signed in?** dialog box, click on **Yes** button. 

![](./media/image010.png)


11.  On **The following Microsoft Account will be used for Azure pass**
    page, click on **Confirm Microsoft Account** button. 

![](./media/image011.png)


12.  Enter the Promocode provided in the lab environment in the **Enter
    Promo code** field, then enter the characters under the **Enter the
    characters you see** field and click on the **Submit** button.  

![](./media/image012.png)


13.  **We are processing your request** page will appear, it may take few
    seconds to process the redemption. 

![](./media/image013.png)


14. Enter correct details in **Your Profile** page, tick all the check
    boxes, and then click on **Sign up** button. 

    ![](./media/image014.png)

    ![](./media/image015.png)

    ![](./media/image016.png)


15. On **Protect your account** dialog box, click on the **Next**
    button. 

    ![](./media/image017.png)


16. Then, on **More information required** dialog box, click on
    the **Next** button. 

    ![](./media/image018.png)

17. If prompted, then enter the password and click on the **Sign in**
    button. 

    ![](./media/image019.png)


18. In your mobile, install the **Microsoft Authenticator App**. Then,
    go back to Microsoft Azure port. In the Azure portal, **Microsoft
    Authenticator -** **Start by getting the app** window, navigate and
    click on the **Next** button. 

    ![](./media/image020.png)


19. In **Microsoft Authenticator –** **Set up your account** window,
    click on the **Next** button. 

    ![](./media/image021.png)


20. **Scan the QR code** using the **Authenticator app** installed in
    your mobile phone and click on the **Next** button. 

    ![](./media/image022.png)


21. Enter the number in your mobile authenticator app and select
    **Yes**. In **testvm1**, click on the **Next** button. 

    ![](./media/image023.png)


22. Click on the **Next** button. 

    ![](./media/image024.png)


23. Click on the **Done** button. 

    ![](./media/image025.png)


24. Enter the number again in your mobile authenticator app and select
    **Yes**.. 

     ![](./media/image026.png)


25. In the **Stay signed in?** window, click on the **Yes** button. 

    ![](./media/image010.png)

### Task 1: Register application for app-only authentication

In this section you'll register an application that supports app-only
authentication using [client credentials
flow](https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow).

1.  Sign in to the Microsoft Entra admin with admin tenant credentials. By navigating to +++https://entra.microsoft.com/+++

    ![](./media/image1.png)

2.  Expand the **Identity** menu --> select **Applications** --> **App registrations** --> **New registration**.

    ![](./media/image2.png)


3.  Enter a name for your application, for example, +++**Parts Inventory Connector**+++.

4.  Set **Supported account types** to **Accounts in this organizational directory only**.

5.  Leave **Redirect URI** empty.

6.  Select **Register**.

    ![](./media/image3.png)

    ![](./media/image4.png)


7.  On the application's **Overview** page, copy the value of
    the **Application (client) ID** and **Directory (tenant) ID** and
    save them on your notepad, you'll need these values in the next
    step.

    ![](./media/image5.png)


8.  Select **API permissions** under **Manage**.

    ![](./media/image6.png)


9.  Remove the default **User.Read** permission under **Configured
    permissions** by selecting the ellipses (**...**) in its row and
    selecting **Remove permission**.

    ![](./media/image7.png)

    ![](./media/image8.png)

10. Click on **Add a permission**.

    ![](./media/image9.png)

11. On the side pane, select **Microsoft Graph.**

    ![](./media/image10.png)


12. Select **Application permissions**.

    ![](./media/image11.png)


13. Search and Select +++**ExternalConnection.ReadWrite.OwnedBy**+++ and +++**ExternalItem.ReadWrite.OwnedBy**+++, then select **Add permissions**.

    ![](./media/image12.png)

    ![](./media/image13.png)


14. Select **Grant admin consent for...**, then select **Yes** to provide admin consent for the selected permission.

    ![](./media/image14.png)

    ![](./media/image15.png)

    ![](./media/image16.png)


15. Select **Certificates and secrets** under **Manage**, then select **New client secret**.

    ![](./media/image17.png)


16. Enter description as +++**MS Graph secret**+++, choose a duration of 90 days, and select **Add**.

    ![](./media/image18.png)

17. Copy the secret from the **Value** column and save it on your notepad, you'll need it in the next steps.

    ![](./media/image19.png)


    ![](./media/image20.png)

    > ** Important** - This client secret is never shown again, so make sure you copy it now.

### Task 2: create the application

Begin by creating a new .NET console project using the [.NET
CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

1.  Open your command-line interface (CLI) in a directory where you want to create the project. Run the following command.

```
dotnet new console -o PartsInventoryConnector
```

![](./media/image21.png)


2.  Once the project is created, verify that it works by changing the
    current directory to the **PartsInventoryConnector** directory and
    running the following commands in your CLI.

```
cd "C:\Users\Student\PartsInventoryConnector"
```

```
dotnet run
```

If it works, the app should output **Hello, World!**.

![](./media/image22.png)

### Task 3: Install dependencies

Before moving on, add some additional dependencies that you use later.

.NET configuration packages to read application configuration from appsettings.json.
Azure Identity client library for .NET to authenticate the user and acquire access tokens.
Microsoft Graph .NET client library to make calls to the Microsoft Graph.
Entity Framework packages for accessing a local database.
CsvHelper for reading CSV files.

1.  Run the following commands in your CLI to install the dependencies.

```
dotnet nuget list source
```

```
dotnet nuget add source https://api.nuget.org/v3/index.json --name nuget.org
```

```
dotnet tool install --global dotnet-ef
```

```
dotnet add package Microsoft.Extensions.Configuration.Binder
```

```
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
```

```
dotnet add package Azure.Identity
```

```
dotnet add package Microsoft.Graph
```

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

```
dotnet add package CsvHelper
```

3.  Check if all the 7 dependencies are installed.

    ![](./media/image23.png)

    ![](./media/image24.png)


    ![](./media/image25.png)


    ![](./media/image26.png)

    ![](./media/image27.png)


    ![](./media/image28.png)

    ![](./media/image29.png)


### Task 4: Load application settings

In this section, you add the details of your app registration to the
project.

1.  Add your client ID, tenant ID, and client secret to the [.NET Secret
    Manager](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets).
    In your command-line interface, change the directory to the location
    of **PartsInventoryConnector.csproj** and run the following
    commands, replacing *\<client-id\>* with your client ID from your
    app registration, *\<tenant-id\>* with your tenant ID,
    and *\<client-secret\>* with your client secret, details of which
    are saved on the notepad

```
dotnet user-secrets init
```

```
dotnet user-secrets set settings:clientId <client-id>
```

```
dotnet user-secrets set settings:tenantId <tenant-id>
```

```
dotnet user-secrets set settings:clientSecret <client-secret>
```

![](./media/image30.png)


2.  Open **PartsInventoryConnector** in VS code editor and create a directory
    named +++**settings.cs**+++ and add the following code.

```
using Microsoft.Extensions.Configuration;

namespace PartsInventoryConnector;

public class Settings
{
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? TenantId { get; set; }

    public static Settings LoadSettings()
    {
        // Load settings
        IConfiguration config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        return config.GetRequiredSection("Settings").Get<Settings>() ??
            throw new Exception("Could not load app settings. See README for configuration instructions.");
    }
}
```

![](./media/image31.png)


![](./media/image32.png)


### Task 5: Design the app

In this section you create a console-based menu.

1.  Open PartsInventoryConnector in the VS Code and, Navigate to
    extensions.

![](./media/imageZ1.png)

2.  Search for **C#** in the search bar and click on the **Install**.

![](./media/imageZ2.png)


3.  Search for **C# Dev Kit** in the search bar and click on the
    **Install**.

![](./media/imageZ3.png)


1.  Open **Program.cs** and replace its entire contents with the
    following code.

```
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.Graph.Models.ODataErrors;
using PartsInventoryConnector;
using PartsInventoryConnector.Data;
using PartsInventoryConnector.Graph;

Console.WriteLine("Parts Inventory Search Connector\n");

var settings = Settings.LoadSettings();

// Initialize Graph
InitializeGraph(settings);

ExternalConnection? currentConnection = null;
int choice = -1;

while (choice != 0)
{
    Console.WriteLine($"Current connection: {(currentConnection == null ? "NONE" : currentConnection.Name)}\n");
    Console.WriteLine("Please choose one of the following options:");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Create a connection");
    Console.WriteLine("2. Select an existing connection");
    Console.WriteLine("3. Delete current connection");
    Console.WriteLine("4. Register schema for current connection");
    Console.WriteLine("5. View schema for current connection");
    Console.WriteLine("6. Push updated items to current connection");
    Console.WriteLine("7. Push ALL items to current connection");
    Console.Write("Selection: ");

    try
    {
        choice = int.Parse(Console.ReadLine() ?? string.Empty);
    }
    catch (FormatException)
    {
        // Set to invalid value
        choice = -1;
    }

    switch(choice)
    {
        case 0:
            // Exit the program
            Console.WriteLine("Goodbye...");
            break;
        case 1:
            currentConnection = await CreateConnectionAsync();
            break;
        case 2:
            currentConnection = await SelectExistingConnectionAsync();
            break;
        case 3:
            await DeleteCurrentConnectionAsync(currentConnection);
            currentConnection = null;
            break;
        case 4:
            await RegisterSchemaAsync();
            break;
        case 5:
            await GetSchemaAsync();
            break;
        case 6:
            await UpdateItemsFromDatabaseAsync(true, settings.TenantId);
            break;
        case 7:
            await UpdateItemsFromDatabaseAsync(false, settings.TenantId);
            break;
        default:
            Console.WriteLine("Invalid choice! Please try again.");
            break;
    }
}

static string? PromptForInput(string prompt, bool valueRequired)
{
    string? response;

    do
    {
        Console.WriteLine($"{prompt}:");
        response = Console.ReadLine();
        if (valueRequired && string.IsNullOrEmpty(response))
        {
            Console.WriteLine("You must provide a value");
        }
    } while (valueRequired && string.IsNullOrEmpty(response));

    return response;
}

static DateTime GetLastUploadTime()
{
    if (File.Exists("lastuploadtime.bin"))
    {
        return DateTime.Parse(
            File.ReadAllText("lastuploadtime.bin")).ToUniversalTime();
    }

    return DateTime.MinValue;
}

static void SaveLastUploadTime(DateTime uploadTime)
{
    File.WriteAllText("lastuploadtime.bin", uploadTime.ToString("u"));
}
```


![](./media/image33.png)


2.  Add the following placeholder methods at the end of the Program.cs file. You
    implement them in later steps.

```
void InitializeGraph(Settings settings)
{
    // TODO
}

async Task<ExternalConnection?> CreateConnectionAsync()
{
    // TODO
    throw new NotImplementedException();
}

async Task<ExternalConnection?> SelectExistingConnectionAsync()
{
    // TODO
    throw new NotImplementedException();
}

async Task DeleteCurrentConnectionAsync(ExternalConnection? connection)
{
    // TODO
}

async Task RegisterSchemaAsync()
{
    // TODO
}

async Task GetSchemaAsync()
{
    // TODO
}

async Task UpdateItemsFromDatabaseAsync(bool uploadModifiedOnly, string? tenantId)
{
    // TODO
}
```

![](./media/image34.png)


This implements a basic menu and reads the user's choice from the command line.

## Exercise 2: Configure Microsoft Graph

In this section, you configure the Microsoft Graph SDK client to use
app-only authentication.

### Task 1: Create a helper class

1.  Right click on **PartsInventoryconnector** directory and open the integrated terminal. Create a new directory named **Graph** by running the following command.

```
mkdir Graph
```

![](./media/image35.png)


![](./media/image36.png)


2.  Create a file in the **Graph** directory
    named as +++**GraphHelper.cs**+++ and add the following using statements.

```
using Azure.Identity;

using Microsoft.Graph;

using Microsoft.Graph.Models.ExternalConnectors;

using Microsoft.Kiota.Authentication.Azure;
```


![](./media/image37.png)


![](./media/image38.png)

3.  Add a namespace and class definition code at the end of GraphHelper.cs.

```
namespace PartsInventoryConnector.Graph;
public static class GraphHelper
{
}
```

![](./media/image39.png)


4.  Add the following code to the GraphHelper class in GraphHelper.cs file, which configures a GraphServiceClient with app-only authentication.


```
private static GraphServiceClient? graphClient;
private static HttpClient? httpClient;
public static void Initialize(Settings settings)
{
    // Create a credential that uses the client credentials
    // authorization flow
    var credential = new ClientSecretCredential(
        settings.TenantId, settings.ClientId, settings.ClientSecret);

    // Create an HTTP client
    httpClient = GraphClientFactory.Create();

    // Create an auth provider
    var authProvider = new AzureIdentityAuthenticationProvider(
        credential, scopes: new[] { "https://graph.microsoft.com/.default" });

    // Create a Graph client using the credential
    graphClient = new GraphServiceClient(httpClient, authProvider);
}
```

![](./media/image40.png)

5.  Replace the empty **InitializeGraph** function in **Program.cs** with
    the following.

```
void InitializeGraph(Settings settings)
{
    try
    {
        GraphHelper.Initialize(settings);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error initializing Graph: {ex.Message}");
    }
}
```

![](./media/image41.png)

![](./media/image42.png)

## Exercise 3: Create the database

In this section, you define the model for the appliance part inventory
records and Entity Framework context, and use the dotnet ef tool to
initialize the database.

### Task 1: Define the model

1.  Create a new directory in the **PartsInventoryConnector** directory
    named +++**Data**+++.

    ![](./media/image43.png)

2.  Create a file in the **Data** directory
    named +++**AppliancePart.cs**+++ and add the following code.

```
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.Graph.Models.ExternalConnectors;

namespace PartsInventoryConnector.Data;

public class AppliancePart
{
    [JsonPropertyName("appliances@odata.type")]
    private const string AppliancesODataType = "Collection(String)";

    [Key]
    public int PartNumber { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int Inventory { get; set; }
    public List<string>? Appliances { get; set; }

    public Properties AsExternalItemProperties()
    {
        _ = Name ?? throw new MemberAccessException("Name cannot be null");
        _ = Description ?? throw new MemberAccessException("Description cannot be null");
        _ = Appliances ?? throw new MemberAccessException("Appliances cannot be null");

        var properties = new Properties
        {
            AdditionalData = new Dictionary<string, object>
            {
                { "partNumber", PartNumber },
                { "name", Name },
                { "description", Description },
                { "price", Price },
                { "inventory", Inventory },
                { "appliances@odata.type", "Collection(String)" },
                { "appliances", Appliances }
            }
        };

        return properties;
    }
}
```

![](./media/image44.png)


![](./media/image45.png)

3.  Create a file in the **Data** directory named +++**ApplianceDbContext.cs**+++ and add the following code.

```
using System.Text.Json;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PartsInventoryConnector.Data;

public class ApplianceDbContext : DbContext
{
    public DbSet<AppliancePart> Parts => Set<AppliancePart>();

    public void EnsureDatabase()
    {
        if (Database.EnsureCreated() || !Parts.Any())
        {
            // File was just created (or is empty),
            // seed with data from CSV file
            var parts = CsvDataLoader.LoadPartsFromCsv("ApplianceParts.csv");
            Parts.AddRange(parts);
            SaveChanges();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=parts.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // EF Core can't store lists, so add a converter for the Appliances
        // property to serialize as a JSON string on save to DB
        modelBuilder.Entity<AppliancePart>()
            .Property(ap => ap.Appliances)
            .HasConversion(
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonSerializerOptions.Default)
            );

        // Add LastUpdated and IsDeleted shadow properties
        modelBuilder.Entity<AppliancePart>()
            .Property<DateTime>("LastUpdated")
            .HasDefaultValueSql("datetime()")
            .ValueGeneratedOnAddOrUpdate();
        modelBuilder.Entity<AppliancePart>()
            .Property<bool>("IsDeleted")
            .IsRequired()
            .HasDefaultValue(false);

        // Exclude any soft-deleted items (IsDeleted = 1) from
        // the default query sets
        modelBuilder.Entity<AppliancePart>()
            .HasQueryFilter(a => !EF.Property<bool>(a, "IsDeleted"));
    }

    public override int SaveChanges()
    {
        // Prevent deletes of data, instead mark the item as deleted
        // by setting IsDeleted = true.
        foreach(var entry in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Deleted))
        {
            if (entry.Entity.GetType() == typeof(AppliancePart))
            {
                SoftDelete(entry);
            }

        }

        return base.SaveChanges();
    }

    private void SoftDelete(EntityEntry entry)
    {
        var partNumber = new SqliteParameter("@partNumber",
            entry.OriginalValues["PartNumber"]);

        Database.ExecuteSqlRaw(
            "UPDATE Parts SET IsDeleted = 1 WHERE PartNumber = @partNumber",
            partNumber);

        entry.State = EntityState.Detached;
    }
}
```

![](./media/image46.png)

![](./media/image47.png)

4.  Create a file in the **Data** directory named +++**CsvDataLoader.cs**+++ and add the following code.

```
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace PartsInventoryConnector.Data;

public static class CsvDataLoader
{
    public static List<AppliancePart> LoadPartsFromCsv(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<AppliancePartMap>();

        return new List<AppliancePart>(csv.GetRecords<AppliancePart>());
    }
}

public class ApplianceListConverter : DefaultTypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        var appliances = text?.Split(';') ?? Array.Empty<string>();
        return new List<string>(appliances);
    }
}

public class AppliancePartMap : ClassMap<AppliancePart>
{
    public AppliancePartMap()
    {
        Map(m => m.PartNumber);
        Map(m => m.Name);
        Map(m => m.Description);
        Map(m => m.Price);
        Map(m => m.Inventory);
        Map(m => m.Appliances).TypeConverter<ApplianceListConverter>();
    }
}
```

![](./media/image48.png)

![](./media/image49.png)

### Task 2: Initialize the database

1.  Open your command line interface (CLI) in the directory where **PartsInventoryConnector.csproj** is located.

    ![](./media/image50.png)


2.  Run the following commands:

```
dotnet ef migrations add InitialCreate
```

```
dotnet ef database update
```

![](./media/image51.png)

## Exercise 4: Manage connections

In this section you add methods to [manage external
connections](https://learn.microsoft.com/en-us/graph/connecting-external-content-manage-connections).

### Task 1: Create a connection

1.  Add the following function to the GraphHelper class in **GraphHelper.cs**.

```
public static async Task<ExternalConnection?> CreateConnectionAsync(string id, string name, string? description)
{
    _ = graphClient ?? throw new MemberAccessException("graphClient is null");

    var newConnection = new ExternalConnection
    {
        Id = id,
        Name = name,
        Description = description,
    };

    return await graphClient.External.Connections.PostAsync(newConnection);
}
```

![](./media/image52.png)


2.  Replace the placeholder function **CreateConnectionAsync** in **Program.cs** with the following.

```
async Task<ExternalConnection?> CreateConnectionAsync()
{
    var connectionId = PromptForInput(
        "Enter a unique ID for the new connection (3-32 characters)", true) ?? "ConnectionId";
    var connectionName = PromptForInput(
        "Enter a name for the new connection", true) ?? "ConnectionName";
    var connectionDescription = PromptForInput(
        "Enter a description for the new connection", false);

    try
    {
        // Create the connection
        var connection = await GraphHelper.CreateConnectionAsync(
            connectionId, connectionName, connectionDescription);
        Console.WriteLine($"New connection created - Name: {connection?.Name}, Id: {connection?.Id}");
        return connection;
    }
    catch (ODataError odataError)
    {
        Console.WriteLine($"Error creating connection: {odataError.ResponseStatusCode}: {odataError.Error?.Code} {odataError.Error?.Message}");
        return null;
    }
}
```

![](./media/image53.png)


![](./media/image54.png)

### Task 2: Select an existing connection

1.  Add the following function to the GraphHelper class in **GraphHelper.cs**.

```
public static async Task<ExternalConnectionCollectionResponse?> GetExistingConnectionsAsync()
{
    _ = graphClient ?? throw new MemberAccessException("graphClient is null");

    return await graphClient.External.Connections.GetAsync();
}
```

![](./media/image55.png)

2.  Replace the placeholder
    function **SelectExistingConnectionAsync** in **Program.cs** with the
    following.

```
async Task<ExternalConnection?> SelectExistingConnectionAsync()
{
    // TODO
    Console.WriteLine("Getting existing connections...");
    try
    {
        var response = await GraphHelper.GetExistingConnectionsAsync();
        var connections = response?.Value ?? new List<ExternalConnection>();
        if (connections.Count <= 0)
        {
            Console.WriteLine("No connections exist. Please create a new connection");
            return null;
        }

        // Display connections
        Console.WriteLine("Choose one of the following connections:");
        var menuNumber = 1;
        foreach(var connection in connections)
        {
            Console.WriteLine($"{menuNumber++}. {connection.Name}");
        }

        ExternalConnection? selection = null;

        do
        {
            try
            {
                Console.Write("Selection: ");
                var choice = int.Parse(Console.ReadLine() ?? string.Empty);
                if (choice > 0 && choice <= connections.Count)
                {
                    selection = connections[choice - 1];
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice.");
            }
        } while (selection == null);

        return selection;
    }
    catch (ODataError odataError)
    {
        Console.WriteLine($"Error getting connections: {odataError.ResponseStatusCode}: {odataError.Error?.Code} {odataError.Error?.Message}");
        return null;
    }
}
```

![](./media/image56.png)

![](./media/image57.png)

### Task 3: Delete a connection

1.  Add the following function to the GraphHelper class
    in **GraphHelper.cs**.

```
public static async Task DeleteConnectionAsync(string? connectionId)
{
    _ = graphClient ?? throw new MemberAccessException("graphClient is null");
    _ = connectionId ?? throw new ArgumentException("connectionId is required");

    await graphClient.External.Connections[connectionId].DeleteAsync();
}
```

![](./media/image58.png)

2.  Replace the placeholder function **DeleteCurrentConnectionAsync** in **Program.cs** with the following.

```
async Task DeleteCurrentConnectionAsync(ExternalConnection? connection)
{
    if (connection == null)
    {
        Console.WriteLine(
            "No connection selected. Please create a new connection or select an existing connection.");
        return;
    }

    try
    {
        await GraphHelper.DeleteConnectionAsync(connection.Id);
        Console.WriteLine($"{connection.Name} deleted successfully.");
    }
    catch (ODataError odataError)
    {
        Console.WriteLine($"Error deleting connection: {odataError.ResponseStatusCode}: {odataError.Error?.Code} {odataError.Error?.Message}");
    }
}
```

![](./media/image59.png)

![](./media/image60.png)

## Exercise 5: Manage schema

In this section, you'll add methods to [register the schema](https://learn.microsoft.com/en-us/graph/connecting-external-content-manage-schema) for
the connector.

### Task 1: Register the schema

1.  Add the following functions to the GraphHelper class
    in **GraphHelper.cs**.

```
public static async Task RegisterSchemaAsync(string? connectionId, Schema schema)
{
    _ = graphClient ?? throw new MemberAccessException("graphClient is null");
    _ = httpClient ?? throw new MemberAccessException("httpClient is null");
    _ = connectionId ?? throw new ArgumentException("connectionId is required");
    // Use the Graph SDK's request builder to generate the request URL
    var requestInfo = graphClient.External
        .Connections[connectionId]
        .Schema
        .ToGetRequestInformation();

    requestInfo.SetContentFromParsable(graphClient.RequestAdapter, "application/json", schema);

    // Convert the SDK request to an HttpRequestMessage
    var requestMessage = await graphClient.RequestAdapter
        .ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);
    _ = requestMessage ?? throw new Exception("Could not create native HTTP request");
    requestMessage.Method = HttpMethod.Post;
    requestMessage.Headers.Add("Prefer", "respond-async");

    // Send the request
    var responseMessage = await httpClient.SendAsync(requestMessage) ??
        throw new Exception("No response returned from API");

    if (responseMessage.IsSuccessStatusCode)
    {
        // The operation ID is contained in the Location header returned
        // in the response
        var operationId = responseMessage.Headers.Location?.Segments.Last() ??
            throw new Exception("Could not get operation ID from Location header");
        await WaitForOperationToCompleteAsync(connectionId, operationId);
    }
    else
    {
        throw new ServiceException("Registering schema failed",
            responseMessage.Headers, (int)responseMessage.StatusCode);
    }
}

private static async Task WaitForOperationToCompleteAsync(string connectionId, string operationId)
{
    _ = graphClient ?? throw new MemberAccessException("graphClient is null");

    do
    {
        var operation = await graphClient.External
            .Connections[connectionId]
            .Operations[operationId]
            .GetAsync();

        if (operation?.Status == ConnectionOperationStatus.Completed)
        {
            return;
        }
        else if (operation?.Status == ConnectionOperationStatus.Failed)
        {
            throw new ServiceException($"Schema operation failed: {operation?.Error?.Code} {operation?.Error?.Message}");
        }

        // Wait 5 seconds and check again
        await Task.Delay(5000);
    } while (true);
}
```

![](./media/image61.png)

2.  Replace the placeholder function **RegisterSchemaAsync** in **Program.cs** with the following.

```
async Task RegisterSchemaAsync()
{
    if (currentConnection == null)
    {
        Console.WriteLine("No connection selected. Please create a new connection or select an existing connection.");
        return;
    }

    Console.WriteLine("Registering schema, this may take a moment...");

    try
    {
        // Create the schema
        var schema = new Schema
        {
            BaseType = "microsoft.graph.externalItem",
            Properties = new List<Property>
            {
                new Property { Name = "partNumber", Type = PropertyType.Int64, IsQueryable = true, IsSearchable = false, IsRetrievable = true, IsRefinable = true },
                new Property { Name = "name", Type = PropertyType.String, IsQueryable = true, IsSearchable = true, IsRetrievable = true, IsRefinable = false, Labels = new List<Label?>() { Label.Title }},
                new Property { Name = "description", Type = PropertyType.String, IsQueryable = false, IsSearchable = true, IsRetrievable = true, IsRefinable = false },
                new Property { Name = "price", Type = PropertyType.Double, IsQueryable = true, IsSearchable = false, IsRetrievable = true, IsRefinable = true },
                new Property { Name = "inventory", Type = PropertyType.Int64, IsQueryable = true, IsSearchable = false, IsRetrievable = true, IsRefinable = true },
                new Property { Name = "appliances", Type = PropertyType.StringCollection, IsQueryable = true, IsSearchable = true, IsRetrievable = true, IsRefinable = false }
            },
        };

        await GraphHelper.RegisterSchemaAsync(currentConnection.Id, schema);
        Console.WriteLine("Schema registered successfully");
    }
    catch (ServiceException serviceException)
    {
        Console.WriteLine($"Error registering schema: {serviceException.ResponseStatusCode} {serviceException.Message}");
    }
    catch (ODataError odataError)
    {
        Console.WriteLine($"Error registering schema: {odataError.ResponseStatusCode}: {odataError.Error?.Code} {odataError.Error?.Message}");
    }
}
```

![](./media/image62.png)

![](./media/image63.png)

### Task 2: Get the schema for a connection

1.  Add the following function to the GraphHelper class
    in **GraphHelper.cs**.

```
public static async Task<Schema?> GetSchemaAsync(string? connectionId)
{
    _ = graphClient ?? throw new MemberAccessException("graphClient is null");
    _ = connectionId ?? throw new ArgumentException("connectionId is null");

    return await graphClient.External
        .Connections[connectionId]
        .Schema
        .GetAsync();
}
```

![](./media/image64.png)

2.  Replace the placeholder
    function **GetSchemaAsync** in **Program.cs** with the following.

```
async Task GetSchemaAsync()
{
    if (currentConnection == null)
    {
        Console.WriteLine("No connection selected. Please create a new connection or select an existing connection.");
        return;
    }

    try
    {
        var schema = await GraphHelper.GetSchemaAsync(currentConnection.Id);
        Console.WriteLine(JsonSerializer.Serialize(schema));

    }
    catch (ODataError odataError)
    {
        Console.WriteLine($"Error getting schema: {odataError.ResponseStatusCode}: {odataError.Error?.Code} {odataError.Error?.Message}");
    }
}
```

![](./media/image65.png)

![](./media/image66.png)

## Exercise 6: Manage items

In this section, you'll add methods to [add or delete
items](https://learn.microsoft.com/en-us/graph/connecting-external-content-manage-items) to
the connector.

### Task 1: Upload or delete items

1.  Add the following function to the GraphHelper class
    in **GraphHelper.cs**.

```
public static async Task AddOrUpdateItemAsync(string? connectionId, ExternalItem item)
{
    _ = graphClient ?? throw new MemberAccessException("graphClient is null");
    _ = connectionId ?? throw new ArgumentException("connectionId is null");

    await graphClient.External
        .Connections[connectionId]
        .Items[item.Id]
        .PutAsync(item);
}
```

![](./media/image67.png)

2.  Add the following function to the GraphHelper class
    in **GraphHelper.cs**.

```
public static async Task DeleteItemAsync(string? connectionId, string? itemId)
{
    _ = graphClient ?? throw new MemberAccessException("graphClient is null");
    _ = connectionId ?? throw new ArgumentException("connectionId is null");
    _ = itemId ?? throw new ArgumentException("itemId is null");

    await graphClient.External
        .Connections[connectionId]
        .Items[itemId]
        .DeleteAsync();
}
```

![](./media/image68.png)

3.  Replace the placeholder
    function **UpdateItemsFromDatabaseAsync** in **Program.cs** with the
    following. navigate to files and click on **Save all**
```
async Task UpdateItemsFromDatabaseAsync(bool uploadModifiedOnly, string? tenantId)
{
    if (currentConnection == null)
    {
        Console.WriteLine("No connection selected. Please create a new connection or select an existing connection.");
        return;
    }

    _ = tenantId ?? throw new ArgumentException("tenantId is null");

    List<AppliancePart>? partsToUpload = null;
    List<AppliancePart>? partsToDelete = null;

    var newUploadTime = DateTime.UtcNow;

    var partsDb = new ApplianceDbContext();
    partsDb.EnsureDatabase();

    if (uploadModifiedOnly)
    {
        var lastUploadTime = GetLastUploadTime();
        Console.WriteLine($"Uploading changes since last upload at {lastUploadTime.ToLocalTime()}");

        partsToUpload = partsDb.Parts
            .Where(p => EF.Property<DateTime>(p, "LastUpdated") > lastUploadTime)
            .ToList();

        partsToDelete = partsDb.Parts
            .IgnoreQueryFilters()
            .Where(p => EF.Property<bool>(p, "IsDeleted")
                && EF.Property<DateTime>(p, "LastUpdated") > lastUploadTime)
            .ToList();
    }
    else
    {
        partsToUpload = partsDb.Parts.ToList();

        partsToDelete = partsDb.Parts
            .IgnoreQueryFilters()
            .Where(p => EF.Property<bool>(p, "IsDeleted"))
            .ToList();
    }

    Console.WriteLine($"Processing {partsToUpload.Count} add/updates, {partsToDelete.Count} deletes.");
    var success = true;

    foreach (var part in partsToUpload)
    {
        var newItem = new ExternalItem
        {
            Id = part.PartNumber.ToString(),
            Content = new ExternalItemContent
            {
                Type = ExternalItemContentType.Text,
                Value = part.Description
            },
            Acl = new List<Acl>
            {
                new Acl
                {
                    AccessType = AccessType.Grant,
                    Type = AclType.Everyone,
                    Value = tenantId,
                }
            },
            Properties = part.AsExternalItemProperties(),
        };

        try
        {
            Console.Write($"Uploading part number {part.PartNumber}...");
            await GraphHelper.AddOrUpdateItemAsync(currentConnection.Id, newItem);
            Console.WriteLine("DONE");
        }
        catch (ODataError odataError)
        {
            success = false;
            Console.WriteLine("FAILED");
            Console.WriteLine($"Error: {odataError.ResponseStatusCode}: {odataError.Error?.Code} {odataError.Error?.Message}");
        }
    }

    foreach (var part in partsToDelete)
    {
        try
        {
            Console.Write($"Deleting part number {part.PartNumber}...");
            await GraphHelper.DeleteItemAsync(currentConnection.Id, part.PartNumber.ToString());
            Console.WriteLine("DONE");
        }
        catch (ODataError odataError)
        {
            success = false;
            Console.WriteLine("FAILED");
            Console.WriteLine($"Error: {odataError.ResponseStatusCode}: {odataError.Error?.Code} {odataError.Error?.Message}");
        }
    }

    // If no errors, update our last upload time
    if (success)
    {
        SaveLastUploadTime(newUploadTime);
    }
}
```

![](./media/image69.png)


![](./media/image70.png)

## Exercise 8: Run the application

In this step, you'll build and run the sample. This code sample creates
a new connection, register the schema, and then push items from
the ApplianceParts.csv file into that connection.

1.  Copy and paste the **ApplianceParts.csv** to PartsInventoryConnector from your
    lab files

    ![](./media/image71.png)

2.  Open your command-line interface (CLI) in
    the **PartsInventoryConnector** directory by right clicking the
    mouse and selecting open integrated terminal.

    ![](./media/image72.png)

    ![](./media/image73.png)


3.  Use the command +++**dotnet build**+++ to build the sample.

    ![](./media/image74.png)


4.  Use the command +++**dotnet run**+++ to run the sample.

    ![](./media/image75.png)

5.  Select **1. Create a connection**. Enter a unique identifier, name,
    and description for that connection.

    ![](./media/image76.png)

    ![](./media/image77.png)


6.  Select **4. Register schema for current connection**, and then wait
    for the operation to complete.

    ![](./media/image78.png)

    ![](./media/image79.png)


7.  Select **7. Push ALL items to current connection**.

    ![](./media/image80.png)

## Exercise 9: Surface the data in search

In this step, you will create search verticals and result types to
customize the search results in Microsoft SharePoint, Microsoft Office,
and Microsoft Search in Bing.

### Task 1: Create a vertical

1.  Sign in to the [Microsoft 365 admin
    center +++https://admin.microsoft.com/+++ by using the global
    administrator role.

2.  Go to **Settings** --> **Search & intelligence** --> **Customizations**.

    ![](./media/image81.png)

3.  Go to **Verticals**, and then select **Add**.

    ![](./media/image82.png)


4.  Enter **Appliance Parts** in the **Name** field and select **Next**.

    ![](./media/image83.png)


5.  Select **Connectors**, then select the **Parts Inventory** connector. Select **Next**.

    ![](./media/image84.png)


6.  On the **Add a query** page, leave the query blank. Select **Next**.

    ![](./media/image85.png)


7.  On the **Filters** page, select **Next**.

    ![](./media/image86.png)


8.  Select **Add Vertical**.

    ![](./media/image87.png)


9.  Select **Enable vertical**, then select **Done**.

    ![](./media/image88.png)


    ![](./media/image89.png)


10. Once the vertical is created, you can see it under the list of items.

    ![](./media/image90.png)


### Task 2: Create a result type

To create a result type:

1.  Go to **Settings** --> **Search & intelligence** --> **Customizations**.

    ![](./media/image91.png)

2.  Go to the **Result type** tab, and then select **Add**.

    ![](./media/image92.png)

3.  Enter Appliance Part in the +++**Name**+++ field and select **Next**.

    ![](./media/image93.png)


4.  On the **Content source** page, select **connection0612**.
    Select **Next**.

    ![](./media/image94.png)


5.  On the **Rules** page, select **Next**.

    ![](./media/image95.png)


6.  On the **Design your layout** page, paste the following JSON, then
    select **Next**.

```
{
"type": "AdaptiveCard",
"version": "1.3",
"body": [
    {
    "type": "ColumnSet",
    "columns": [
        {
        "type": "Column",
        "width": 6,
        "items": [
            {
            "type": "TextBlock",
            "text": "__${name} (Part #${partNumber})__",
            "color": "accent",
            "size": "medium",
            "spacing": "none",
            "$when": "${name != \"\"}"
            },
            {
            "type": "TextBlock",
            "text": "${description}",
            "wrap": true,
            "maxLines": 3,
            "$when": "${description != \"\"}"
            }
        ],
        "horizontalAlignment": "Center",
        "spacing": "none"
        },
        {
        "type": "Column",
        "width": 2,
        "items": [
            {
            "type": "FactSet",
            "facts": [
                {
                "title": "Price",
                "value": "$${price}"
                },
                {
                "title": "Current Inventory",
                "value": "${inventory} units"
                }
            ]
            }
        ],
        "spacing": "none",
        "horizontalAlignment": "right"
        }
    ]
    }
],
"$schema": "http://adaptivecards.io/schemas/adaptive-card.json"
}
```

![](./media/image96.png)


7.  Select **Add result type**, then select **Done**.

    ![](./media/image97.png)

    ![](./media/image98.png)

    ![](./media/image99.png)


## Exercise 9: Search for results

In this step, you search for parts in SharePoint.

1.  Go to the root SharePoint site for your tenant.

    ![](./media/image100.png)


2.  On the welcome to SharePoint floater window click on the **x** icon to
    close.

    ![](./media/image101.png)


3.  Using the search box at the top of the page, search for +++**hinge**+++.

    ![](./media/image102.png)


4.  When the search completes with 0 results, select the **Appliance Parts** tab. Results from the connector are displayed.

    ![](./media/image103.png)


**Congratulations!**

You have successfully completed the .NET Microsoft Graph connectors
tutorial: you created a custom connector and used it to power Microsoft
Search.

## Conclusion

This lab guide successfully demonstrates the process of building a
custom Microsoft Graph connector to integrate external data into
Microsoft Graph and enhance Microsoft 365 experiences. Participants
learned how to implement app-only authentication, create and manage a
.NET console application, and define schemas for seamless data
integration. The lab also covered key aspects of managing database
records, customizing Microsoft Search with verticals and result types,
and verifying the functionality of the connector through practical
implementation. By the end of the lab, participants gained hands-on
experience in extending Microsoft Graph's capabilities to surface
external data in Microsoft Search, showcasing the potential for
improving organizational workflows and search functionalities across
Microsoft 365.
