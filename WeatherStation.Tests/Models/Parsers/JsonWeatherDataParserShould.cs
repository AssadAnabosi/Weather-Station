using JetBrains.Annotations;
using WeatherStation.Models;
using WeatherStation.Models.Parsers;
using WeatherStation.Tests.Models.Bots;
using Xunit.Abstractions;

namespace WeatherStation.Tests.Models.Parsers;

[TestSubject(typeof(JsonWeatherDataParser))]
public class JsonWeatherDataParserShould
{
    private readonly JsonWeatherDataParser _jsonWeatherDataParser;
    private readonly ITestOutputHelper _output;

    public JsonWeatherDataParserShould(ITestOutputHelper output)
    {
        _output = output;
        _jsonWeatherDataParser = new JsonWeatherDataParser();
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("{}", true)]
    [InlineData("{", false)]
    [InlineData("<>", false)]
    public void ParseJson(string input, bool result)
    {
        bool actual = _jsonWeatherDataParser.Parsable(input);

        Assert.Equal(result, actual);
    }


    [Theory]
    [MemberData(nameof(InternalWeatherData.Data), MemberType = typeof(InternalWeatherData))]
    public void CorrectlyParseWeatherData(
        Dictionary<string, string> input,
        WeatherData expected)
    {
        WeatherData actual = _jsonWeatherDataParser.Parse(input["JSON"]);

        Assert.Equal(expected.Location, actual.Location);
        Assert.Equal(expected.Temperature, actual.Temperature);
        Assert.Equal(expected.Humidity, actual.Humidity);
    }

    [Fact]
    public void ThrowsArgumentNullExceptionWhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => _jsonWeatherDataParser.Parse(null));
    }
}