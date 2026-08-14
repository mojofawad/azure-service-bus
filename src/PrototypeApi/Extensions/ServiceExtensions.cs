using PrototypeApi.Routes;

namespace PrototypeApi.Extensions;

public static class ServiceExtensions
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapWidgets();
        app.MapWeather();
    }
}