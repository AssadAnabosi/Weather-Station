namespace WeatherStation.Models.Bots;

public class SnowBot : IWeatherBot
{
    public string Name => "SnowBot";
    public bool Enabled { get; set; }
    public double TemperatureThreshold { get; set; }
    public string Message { get; set; } = string.Empty;

    public string Update(WeatherData data)
    {
        if (!Enabled || data.Temperature >= TemperatureThreshold) return "";

        return $"{Name} activated!\n" +
               $"{Name}: \"{Message}\"";
    }
}