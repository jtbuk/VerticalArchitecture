using Jtbuk.VerticalArchitecture.Features.Weather;

namespace Jtbuk.VerticalArchitecture.Common.Db;

public static class MigrationRunnerExtensions
{
    public static void RunMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WeatherContext>();
        context.Database.Migrate();
    }
}
