var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Console>("console");

var api = builder.AddProject<Projects.PrototypeApi>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

var webfrontend = builder.AddViteApp("webfrontend", "../../src/frontend")
    .WithReference(api)
    .WaitFor(api);

api.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();