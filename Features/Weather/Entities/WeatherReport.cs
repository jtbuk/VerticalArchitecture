namespace Jtbuk.VerticalArchitecture.Features.Weather.Entities;

public class WeatherReport : BaseEntity
{
    public WeatherReport(double latitude, double longitude, double temperatureInCelcius, int precipitation, int windMph)
    {                
        TemperatureInCelcius = temperatureInCelcius;
        Precipitation = precipitation;
        WindMph = windMph;
        Latitude = latitude;
        Longitude = longitude;
    }
    
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double TemperatureInCelcius { get; set; }
    public int Precipitation { get; set; }
    public int WindMph { get; set; }
}

public class Temperature
{
    public Temperature(double celcius)
    {
        Celsius = celcius;
    }

    public double Celsius { get; set; }

    [NotMapped]
    public double Kelvin
    {
        get => Temperatures.CelsiusToKelvin(Celsius);
        set => Celsius = Temperatures.KelvinToCelsius(value);
    }

    [NotMapped]
    public double Fahrenheit
    {
        get => Temperatures.CelsiusToFarenheit(Celsius);
        set => Celsius = Temperatures.FahrenheitToCelsius(value);
    }
}

public static class Temperatures
{
    public static double FahrenheitToCelsius(double value) => (value - 32) * 5 / 9;

    public static double CelsiusToFarenheit(double value) => (value * 9 / 5) + 32;

    public static double CelsiusToKelvin(double value) => value + 273.15;

    public static double KelvinToCelsius(double value) => value - 273.15;
}
