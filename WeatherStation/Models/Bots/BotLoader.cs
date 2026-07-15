using System.Text.Json;

namespace WeatherStation.Models.Bots;

public static class BotLoader
{
    public static List<WeatherBot> LoadFromConfigurationFile(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var config = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json)
                     ?? throw new InvalidOperationException("Failed To Load From Configuration File");

        var bots = new List<WeatherBot>();

        foreach (var (name, element) in config)
        {
            var bot = CreateBot(name, element);
            if (bot != null)
            {
                bots.Add(bot);
            }
        }

        return bots;
    }

    private static WeatherBot? CreateBot(string name, JsonElement element)
    {
        var enabled = element.GetProperty("enabled").GetBoolean();
        var message = element.GetProperty("message").GetString();

        return name switch
        {
            "RainBot" => new RainBot
            {
                Enabled = enabled,
                Message = message,
                HumidityThreshold = element.GetProperty("humidityThreshold").GetDouble(),
            },
            "SunBot" => new SunBot
            {
                Enabled = enabled,
                Message = message,
                TemperatureThreshold = element.GetProperty("temperatureThreshold").GetDouble(),
            },
            "SnowBot" => new SnowBot
            {
                Enabled = enabled,
                Message = message,
                TemperatureThreshold = element.GetProperty("temperatureThreshold").GetDouble(),
            },
            _ => null
        };
    }
}