var builder = DistributedApplication.CreateBuilder(args);

var serviceBus = builder.AddAzureServiceBus("messaging")
    .RunAsEmulator(c => c.WithLifetime(ContainerLifetime.Persistent));

serviceBus.AddServiceBusQueue("widget-queue");
var topic = serviceBus.AddServiceBusTopic("widget-topic");
topic.AddServiceBusSubscription("widget-subscription");

builder.AddProject<Projects.Console>("console");

var api = builder.AddProject<Projects.PrototypeApi>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints()
    .WithReference(serviceBus);

var apiEndpoint = api.GetEndpoint("http");

var webfrontend = builder.AddViteApp("webfrontend", "../../src/frontend-react")
    .WithPnpm()
    .WithEnvironment("API_URL", apiEndpoint)
    .WithExternalHttpEndpoints()
    .WaitFor(api);

var nuxtfrontend = builder.AddViteApp("nuxtfrontend", "../../src/frontend-nuxt")
    .WithPnpm()
    .WithEnvironment("API_URL", apiEndpoint)
    .WithEnvironment("NUXT_API_URL", apiEndpoint)
    .WithExternalHttpEndpoints()
    .WaitFor(api);

var nextfrontend = builder.AddViteApp("nextfrontend", "../../src/frontend-next")
    .WithPnpm()
    .WithEnvironment("API_URL", apiEndpoint)
    .WaitFor(api);

api.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();