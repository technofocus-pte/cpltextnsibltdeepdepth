var builder = DistributedApplication.CreateBuilder(args);


var chatwithslmservices = builder.AddProject<Projects.GHCAgent_Orchestration_API>("ghcagent-orchestration-api");

builder.Build().Run();
