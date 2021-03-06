using Jtbuk.VerticalArchitecture.Features.Weather.Entities;

namespace Jtbuk.VerticalArchitecture.Features.Weather.Actions;

public record UpdateWeatherReportDto(
    Location Location,
    double TemperatureInCelcius,
    int Precipitation,
    int WindMph);

public static class UpdateWeatherReportAction
{    
    public static async Task Invoke(int id, UpdateWeatherReportDto dto, WeatherContext context)
    {
        Debug.Assert(context != null, $"{nameof(context)} shouldn't be null");

        var weatherReport = context.WeatherReports.SingleOrDefault(wr => wr.Id == id);

        if(weatherReport == null)
        {
            throw new NotFoundException<WeatherReport>(id);
        }

        weatherReport.Latitude = dto.Location.Latitude;
        weatherReport.Longitude = dto.Location.Longitude;
        weatherReport.TemperatureInCelcius = dto.TemperatureInCelcius;
        weatherReport.Precipitation = dto.Precipitation;
        weatherReport.WindMph = dto.WindMph;        

        await context.SaveChangesAsync();
    }
}
