namespace WeatherStation.Models.Bots;

public class RainBot : IWeatherBot
{
    public string Name => "RainBot";
    public bool Enabled { get; set; }
    public double HumidityThreshold { get; set; }
    public string Message { get; set; } = string.Empty;

    public string? Update(WeatherData data)
    {
        if (!Enabled || data.Humidity <= HumidityThreshold) return null;

        return $"{Name} activated!\n" +
               $"{Name}: \"{Message}\"";
    }
}