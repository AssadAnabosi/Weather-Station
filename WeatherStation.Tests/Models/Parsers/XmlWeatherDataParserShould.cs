using JetBrains.Annotations;
using WeatherStation.Models;
using WeatherStation.Models.Parsers;
using WeatherStation.Tests.Models.Bots;
using Xunit.Abstractions;

namespace WeatherStation.Tests.Models.Parsers;

[TestSubject(typeof(XmlWeatherDataParser))]
public class XmlWeatherDataParserShould
{
    private readonly XmlWeatherDataParser _xmlWeatherDataParser;
    private readonly ITestOutputHelper _output;

    public XmlWeatherDataParserShould(ITestOutputHelper output)
    {
        _output = output;
        _xmlWeatherDataParser = new XmlWeatherDataParser();
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("{}", false)]
    [InlineData("<", false)]
    [InlineData("<>", true)]
    public void ParseXml(string input, bool result)
    {
        bool actual = _xmlWeatherDataParser.Parsable(input);

        Assert.Equal(result, actual);
    }
    
    
    [Theory]
    [MemberData(nameof(InternalWeatherData.Data), MemberType = typeof(InternalWeatherData))]
    public void CorrectlyParseWeatherData(
        Dictionary<string, string> input,
        WeatherData expected)
    {
        WeatherData actual = _xmlWeatherDataParser.Parse(input["XML"]);

        Assert.Equal(expected.Location, actual.Location);
        Assert.Equal(expected.Temperature, actual.Temperature);
        Assert.Equal(expected.Humidity, actual.Humidity);
    }

    [Fact]
    public void ThrowsArgumentNullExceptionWhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => _xmlWeatherDataParser.Parse(null));
    }
    
}