using Jtbuk.VerticalArchitecture.Features.Weather.Entities;

namespace Jtbuk.VerticalArchitecture.Features.Weather.Actions;

public class GetWeatherReportsActionUnitTests : BaseUnitTestWithContext<WeatherContext>
{
    [Fact]
    public async Task Get_Works()
    {
        var context = GetContext();

        var weatherReport = new WeatherReport(0, 0, 0, 0, 0);
        context.WeatherReports.Add(weatherReport);
        await context.SaveChangesAsync();

        var dto = await GetWeatherReportAction.Invoke(weatherReport.Id, context);
        
        dto.Location.Latitude.Should().Be(weatherReport.Latitude);
        dto.Location.Longitude.Should().Be(weatherReport.Longitude);
        dto.TemperatureInCelcius.Should().Be(weatherReport.TemperatureInCelcius);
        dto.Precipitation.Should().Be(weatherReport.Precipitation);
        dto.WindMph.Should().Be(weatherReport.WindMph);
    }
}
