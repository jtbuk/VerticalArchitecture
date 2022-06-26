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
        var route = "/api/weather";

        app.MapPost(route, CreateWeatherReportAction.Invoke)
           .WithTags(featureTag);

        app.MapGet(route, GetWeatherReportsAction.Invoke)
           .WithTags(featureTag);

        app.MapGet($"{route}/{{id}}", GetWeatherReportAction.Invoke)
           .WithTags(featureTag);

        app.MapPut(route, UpdateWeatherReportAction.Invoke)
           .WithTags(featureTag);
    }
}
