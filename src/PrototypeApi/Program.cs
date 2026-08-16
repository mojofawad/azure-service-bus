using PrototypeApi.Extensions;
using MojoPrototype.ServiceDefaults;
using PrototypeApi;

var builder = WebApplication.CreateBuilder(args);

builder.AddAzureServiceBusClient("messaging");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHostedService<Receiver>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.RegisterEndpoints();

app.MapDefaultEndpoints();

app.UseFileServer();

app.Run();