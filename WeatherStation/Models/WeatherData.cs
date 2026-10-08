namespace WeatherStation.Models;

public struct WeatherData
{
    public WeatherData()
    {
        Location = string.Empty;
        Temperature = 0;
        Humidity = 0;
    }

    public required string Location { get; set; } = string.Empty;
    public required double Temperature { get; set; }
    public required double Humidity { get; set; }

    public override string ToString()
    {
        return $"{Location}: {Temperature}°, {Humidity}%";
    }
}