namespace WeatherStation.Models;

public class WeatherData
{
    public required string Location { get; set; } = string.Empty;
    public required double Temperature { get; set; }
    public required double Humidity { get; set; }

    public override string ToString()
    {
        return $"{Location}: {Temperature}°, {Humidity}%";
    }
}