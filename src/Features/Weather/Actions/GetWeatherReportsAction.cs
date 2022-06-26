namespace Jtbuk.VerticalArchitecture.Features.Weather.Actions;

public static class GetWeatherReportsAction
{    
    public static async Task<List<GetWeatherReportDto>> Invoke(WeatherContext context)
    {
        var dtos = await context.WeatherReports
            .Select(wr => new GetWeatherReportDto(
                new Location(
                    wr.Latitude,
                    wr.Longitude
                ),
                wr.TemperatureInCelcius,
                wr.Precipitation,
                wr.WindMph))
            .ToListAsync();

        return dtos;
    }
}
