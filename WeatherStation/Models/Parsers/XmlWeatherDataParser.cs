using System.Xml.Linq;

namespace WeatherStation.Models.Parsers;

public class XmlWeatherDataParser : IWeatherDataParser
{
    public bool Parsable(string input)
    {
        return input.StartsWith('<') && input.EndsWith('>');
    }

    public WeatherData Parse(string input)
    {
        var doc = XDocument.Parse(input);
        var root = doc.Element("WeatherData")
                   ?? throw new FormatException("Missing <WeatherData> root element.");

        return new WeatherData
        {
            Location = root.Element("Location")?.Value
                       ?? throw new FormatException("Missing <Location> element."),
            Temperature = double.Parse(root.Element("Temperature")?.Value
                                       ?? throw new FormatException("Missing <Temperature> element.")),
            Humidity = double.Parse(root.Element("Humidity")?.Value
                                    ?? throw new FormatException("Missing <Humidity> element."))
        };
    }
}