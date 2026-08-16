var builder = DistributedApplication.CreateBuilder(args);

var serviceBus = builder.AddAzureServiceBus("messaging")
    .RunAsEmulator();

serviceBus.AddServiceBusQueue("widget-queue");
var topic = serviceBus.AddServiceBusTopic("widget-topic");
topic.AddServiceBusSubscription("widget-subscription");

builder.AddProject<Projects.Console>("console");

var api = builder.AddProject<Projects.PrototypeApi>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints()
    .WithReference(serviceBus);

var webfrontend = builder.AddViteApp("webfrontend", "../../src/frontend")
    .WithReference(api)
    .WaitFor(api);

api.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();