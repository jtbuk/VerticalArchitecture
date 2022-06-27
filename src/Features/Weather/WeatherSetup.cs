using Jtbuk.VerticalArchitecture.Common.Swagger;
using Jtbuk.VerticalArchitecture.Features.Weather.Actions;

namespace Jtbuk.VerticalArchitecture.Features.Weather;

public static class WeatherSetup
{
    public static void AddWeatherFeature(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("WeatherConnection");        
        builder.Services.AddDbContext<WeatherContext>(options => options.UseSqlServer(connectionString));              
    }

    public static void UseWeatherFeature(this WebApplication app)
    {
        var featureTag = "Weather";
        
        app.Get("/api/weather", GetWeatherReportsAction.Invoke, featureTag);
        app.Post("/api/weather", CreateWeatherReportAction.Invoke, featureTag);
        app.Get("/api/weather/{id}", GetWeatherReportAction.Invoke, featureTag);
        app.Put("/api/weather", UpdateWeatherReportAction.Invoke, featureTag);
    }
}
