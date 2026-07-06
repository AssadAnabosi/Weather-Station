namespace WeatherStation.Models.Parsers;

public class CompositeWeatherDataParser
{
    private List<IWeatherDataParser> _parsers = new();

    public void RegisterParser(IWeatherDataParser parser)
    {
        _parsers.Add(parser);
    }

    public WeatherData Parse(string input)
    {
        var parser = _parsers.FirstOrDefault(p => p.Parsable(input)) 
            ?? throw new InvalidOperationException("No parsers found for this input format");
        
        return parser.Parse(input);
    }
}