var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Crm_Api>("Crm-Api");

builder.Build().Run();