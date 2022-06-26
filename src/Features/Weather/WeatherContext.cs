using Jtbuk.VerticalArchitecture.Features.Weather.Entities;

namespace Jtbuk.VerticalArchitecture.Features.Weather;

public class WeatherContext : BaseContext
{
    public WeatherContext(DbContextOptions options) : base(options) { }

    public DbSet<WeatherReport> WeatherReports { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        base.OnModelCreating(modelBuilder);
    }
}
