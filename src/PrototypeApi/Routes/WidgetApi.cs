using System.Text.Json;
using Azure.Messaging.ServiceBus;

namespace PrototypeApi.Routes;

public static class WidgetApi
{
    public static RouteGroupBuilder MapWidgets(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api");

        group.MapGet("/widgets", () =>
        {
            return Results.Ok("/widgets GET is working!");
        });
        
        group.MapPost("/widgets", async (ServiceBusClient client, CancellationToken cancellationToken) =>
        {
            var sender = client.CreateSender("widget-queue");
            
            var message = new ServiceBusMessage(
                JsonSerializer.Serialize(new { Id = Guid.NewGuid(), Name = $"widget-{Guid.NewGuid()}" })
            );

            await sender.SendMessageAsync(message, cancellationToken);

            return Results.Accepted();
        });

        return group;
    }
    
}