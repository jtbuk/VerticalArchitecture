using Jtbuk.VerticalArchitecture.Features.Weather.Entities;

namespace Jtbuk.VerticalArchitecture.Features.Weather.Actions;

public class UpdateWeatherReportActionUnitTests : BaseUnitTestWithContext<WeatherContext>
{
    [Fact]
    public async Task Update_Works()
    {
        var context = GetContext();

        var weatherReport = new WeatherReport(0, 0, 0, 0, 0);
        context.WeatherReports.Add(weatherReport);
        await context.SaveChangesAsync();

        var dto = new UpdateWeatherReportDto(new(10, 10), 10, 10, 10);
        await UpdateWeatherReportAction.Invoke(weatherReport.Id, dto, context);        
        
        weatherReport.Latitude.Should().Be(dto.Location.Latitude);
        weatherReport.Longitude.Should().Be(dto.Location.Longitude);
        weatherReport.TemperatureInCelcius.Should().Be(dto.TemperatureInCelcius);
        weatherReport.Precipitation.Should().Be(dto.Precipitation);
        weatherReport.WindMph.Should().Be(dto.WindMph);
    }
}
