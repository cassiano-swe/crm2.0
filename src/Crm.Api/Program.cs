using Crm.Api.Database;
using Crm.Api.EndpointExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(s => s.FullName?.Replace('+', '.')));

builder.Services.AddDbContext<Context>(o => o.UseInMemoryDatabase("contactDB"));

builder.Services.AddEndpoints();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("/health");

app.MapEndpoints(); 

app.Run();