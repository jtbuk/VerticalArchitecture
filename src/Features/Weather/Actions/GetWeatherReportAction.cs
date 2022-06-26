using Jtbuk.VerticalArchitecture.Features.Weather.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Jtbuk.VerticalArchitecture.Features.Weather.Actions;

public record GetWeatherReportDto(
    Location Location,
    double TemperatureInCelcius,
    int Precipitation,
    int WindMph);

public static class GetWeatherReportAction
{    
    public static async Task<GetWeatherReportDto> Invoke([FromRoute] int id, WeatherContext context)
    {
        var dto = await context.WeatherReports
            .Select(wr => new GetWeatherReportDto(
                new Location(
                    wr.Latitude,
                    wr.Longitude
                ),
                wr.TemperatureInCelcius,
                wr.Precipitation,
                wr.WindMph))
            .SingleOrDefaultAsync();

        if(dto is null)
        {
            throw new NotFoundException<WeatherReport>(id);
        }

        return dto;
    }
}
