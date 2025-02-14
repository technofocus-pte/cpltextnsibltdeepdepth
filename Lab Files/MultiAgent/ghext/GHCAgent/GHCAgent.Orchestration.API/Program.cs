using GHCAgent.Orchestration.API.Domain;
using GHCAgent.Orchestration.API.Orch;

using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapPost("/api/gencode", async (RequestPrompt prompt) =>
{
    var response = await AgentOrchestration.Orchestration(prompt.Request);
    return new AnswerResponse { answer = response };
}).WithDescription("Generate code based on the requirements");

// app.UseStaticFiles();    //Serve files from wwwroot
app.UseStaticFiles(new StaticFileOptions
 {
     FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "arch")),
     RequestPath = "/arch"
 });

app.MapOpenApi();

app.Run();
