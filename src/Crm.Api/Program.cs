using Crm.Api.EndpointExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(s => s.FullName?.Replace('+', '.')));

builder.Services.AddEndpoints();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("/health");

app.MapEndpoints(); 

app.Run();