using JetBrains.Annotations;
using WeatherStation.Models.Bots;
using Xunit.Abstractions;

namespace WeatherStation.Tests.Models.Bots;

[TestSubject(typeof(BotLoader))]
public class BotLoaderShould : IDisposable
{
    private string? _path;
    private readonly ITestOutputHelper _output;

    public BotLoaderShould(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void LoadBotsFromFile()
    {
        _path = CreateTempConfig("""
                                 {
                                   "RainBot": { "enabled": true, "humidityThreshold": 70, "message": "Rain!" },
                                   "SunBot": { "enabled": true, "temperatureThreshold": 30, "message": "Sun!" },
                                   "SnowBot": { "enabled": false, "temperatureThreshold": 0, "message": "Snow!" }
                                 }
                                 """);
        List<WeatherBot> bots = BotLoader.LoadFromConfigurationFile(_path);
        bots.ForEach(b => _output.WriteLine(b.ToString()));
        Assert.Equal(3, bots.Count);
        Assert.Contains(bots, b => b.Name == "RainBot");
        Assert.Contains(bots, b => b.Name == "SunBot");
        Assert.Contains(bots, b => b.Name == "SnowBot");
        Assert.Contains(bots, b => b.Enabled);
        Assert.Contains(bots, b => !b.Enabled);
        Assert.All(bots, b => Assert.True(b.Message.Length > 0));
    }

    [Fact]
    public void LoadBotsFromFile_SkipUnknownBots()
    {
        var path = CreateTempConfig("""
                                    {
                                      "FogBot": { "enabled": true, "humidityThreshold": 90, "message": "Fog!" }
                                    }
                                    """);
        var bots = BotLoader.LoadFromConfigurationFile(path);

        Assert.Empty(bots);
    }

    [Fact]
    public void LoadFromFile_MissingFile_ThrowsException()
    {
        Assert.ThrowsAny<Exception>(() => BotLoader.LoadFromConfigurationFile("nonexistent.json"));
    }

    [Theory]
    [InlineData("""
                {
                  "RainBot": { "humidityThreshold": 70, "message": "Rain!" }
                }
                """)]
    [InlineData("""
                {
                  "RainBot": { "enabled": true, "message": "Rain!" }
                }
                """)]
    [InlineData("""
                {
                  "RainBot": { "enabled": true, "humidityThreshold": 70, }
                }
                """)]
    public void LoadFromFile_InvalidConfiguration_ThrowsException(string jsonConfig)
    {
        var path = CreateTempConfig(jsonConfig);
        Assert.ThrowsAny<Exception>(() => BotLoader.LoadFromConfigurationFile(path));
    }


    public void Dispose()
    {
        if (_path != null)
            File.Delete(_path);
    }

    // Helpers
    private static string CreateTempConfig(string json)
    {
        var path = Path.GetTempFileName();
        File.WriteAllText(path, json);
        return path;
    }
}