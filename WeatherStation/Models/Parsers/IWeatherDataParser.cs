namespace WeatherStation.Models.Parsers;

public interface IWeatherDataParser
{
    bool Parsable(string input);
    
    WeatherData Parse(string input);
}