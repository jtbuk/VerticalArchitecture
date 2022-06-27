using Jtbuk.VerticalArchitecture.Features.Weather.Entities;

namespace Jtbuk.VerticalArchitecture.Features.Weather.Actions;

public class GetWeatherReportActionUnitTests : BaseUnitTestWithContext<WeatherContext>
{
    [Fact]
    public async Task Get_Works()
    {
        var context = GetContext();

        var weatherReportOne = new WeatherReport(0, 0, 0, 0, 0);
        var weatherReportTwo = new WeatherReport(10, 10, 10, 10, 10);
        context.WeatherReports.AddRange(weatherReportOne, weatherReportTwo);
        await context.SaveChangesAsync();

        var dtos = await GetWeatherReportsAction.Invoke(context);

        dtos.Should().HaveCount(2);        
    }
}
