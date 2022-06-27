namespace Jtbuk.VerticalArchitecture.Features.Weather.Actions;

public class CreateWeatherReportActionUnitTests : BaseUnitTestWithContext<WeatherContext>
{
    [Fact]
    public async Task Create_Works()
    {
        var context = GetContext();

        var dto = new CreateWeatherReportDto(new(0, 0), 100, 10, 20);
        var weatherReportId = await CreateWeatherReportAction.Invoke(dto, context);

        var weatherReport = context.WeatherReports.Single();

        weatherReport.Id.Should().Be(weatherReportId);
        weatherReport.Latitude.Should().Be(dto.Location.Latitude);
        weatherReport.Longitude.Should().Be(dto.Location.Longitude);
        weatherReport.TemperatureInCelcius.Should().Be(dto.TemperatureInCelcius);
        weatherReport.Precipitation.Should().Be(dto.Precipitation);
        weatherReport.WindMph.Should().Be(dto.WindMph);
    }
}
