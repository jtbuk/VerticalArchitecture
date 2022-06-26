using Jtbuk.VerticalArchitecture.Features.Weather.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Jtbuk.VerticalArchitecture.Features.Weather.Actions;

/// <example>
/// {
///   "location": {
///     "latitude": 51.5072,
///     "longitude": 0.1276
///   },
///   "temperatureInCelcius": 26,
///   "precipitation": 60,
///   "windMph": 18
/// }
/// </example>
public record CreateWeatherReportDto(
    Location Location,
    double TemperatureInCelcius,
    int Precipitation,
    int WindMph);

public class CreateWeatherReportAction
{    
    public static async Task<int> Invoke(CreateWeatherReportDto dto, WeatherContext context)
    {
        Debug.Assert(context != null, $"{nameof(context)} shouldn't be null");

        var weatherReport = new WeatherReport(            
            dto.Location.Latitude,
            dto.Location.Longitude,
            dto.TemperatureInCelcius,
            dto.Precipitation,
            dto.WindMph);

        context.WeatherReports.Add(weatherReport);

        await context.SaveChangesAsync();

        return weatherReport.Id;
    }
}
