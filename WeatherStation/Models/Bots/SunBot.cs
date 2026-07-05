namespace WeatherStation.Models.Bots;

public class SunBot : IWeatherBot
{
    public string Name => "SunBot";
    public bool Enabled { get; set; }
    public double TemperatureThreshold { get; set; }
    public string Message { get; set; } = string.Empty;

    public void Update(WeatherData data)
    {
        if (!Enabled || data.Temperature <= TemperatureThreshold) return;

        Console.WriteLine($"{Name} activated!");
        Console.WriteLine($"{Name}: \"{Message}\"");
    }
}