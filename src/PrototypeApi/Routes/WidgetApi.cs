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
        
        group.MapPost("/widgets", () =>
        {
            return Results.Ok("/widgets POST is working!");
        });

        return group;
    }
    
}