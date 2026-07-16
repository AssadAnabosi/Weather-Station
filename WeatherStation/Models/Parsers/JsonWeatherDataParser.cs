using System.Text.Json;

namespace WeatherStation.Models.Parsers;

public class JsonWeatherDataParser : IWeatherDataParser
{
    public bool Parsable(string input)
    {
        return input.StartsWith('{') && input.EndsWith('}');
    }

    public WeatherData Parse(string input)
    {
        return JsonSerializer.Deserialize<WeatherData?>(input) ??
               throw new FormatException("Invalid JSON: Failed to parse JSON weather data.");
    }
}