using JetBrains.Annotations;
using WeatherStation.Models;
using WeatherStation.Models.Bots;

namespace WeatherStation.Tests.Models.Bots;

[TestSubject(typeof(SnowBot))]
public class SnowBotShould
{
    [Fact]
    public void EmptyString_WhenDisabled()
    {
        SnowBot bot = new()
        {
            Enabled = false,
            TemperatureThreshold = 0,
            Message = "This Should not be displayed"
        };
        var expected = "";
        var actual = bot.Update(
            new WeatherData
            {
                Location = "SPB",
                Temperature = -15,
                Humidity = 80,
            });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EmptyString_WhenThresholdNotMet()
    {
        SnowBot bot = new()
        {
            Enabled = true,
            TemperatureThreshold = 0,
            Message = "This Should not be displayed"
        };
        var expected = "";
        var actual = bot.Update(
            new WeatherData
            {
                Location = "London",
                Temperature = 20,
                Humidity = 60,
            });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ResultWhenThresholdMet()
    {
        var msg = "Brrr, it's getting chilly!";
        SnowBot bot = new()
        {
            Enabled = true,
            TemperatureThreshold = 0,
            Message = msg
        };
        var expected = $"SnowBot activated!\n" +
                       $"SnowBot: \"{msg}\"";
        var actual = bot.Update(
            new WeatherData
            {
                Location = "SPB",
                Temperature = -15,
                Humidity = 80,
            });
        Assert.Equal(expected, actual);
    }
}