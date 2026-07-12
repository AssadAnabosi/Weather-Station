using JetBrains.Annotations;
using WeatherStation.Models;
using WeatherStation.Models.Bots;

namespace WeatherStation.Tests.Models.Bots;

[TestSubject(typeof(SunBot))]
public class SunBotShould
{
    [Fact]
    public void EmptyString_WhenDisabled()
    {
        SunBot bot = new()
        {
            Enabled = false,
            TemperatureThreshold = 30,
            Message = "This Should not be displayed"
        };
        var expected = "";
        var actual = bot.Update(
            new WeatherData
            {
                Location = "Jenin",
                Temperature = 35,
                Humidity = 40,
            });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EmptyString_WhenThresholdNotMet()
    {
        SunBot bot = new()
        {
            Enabled = true,
            TemperatureThreshold = 30,
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
        var msg = "Wow, it's a scorcher out there!";
        SunBot bot = new()
        {
            Enabled = true,
            TemperatureThreshold = 30,
            Message = msg
        };
        var expected = $"SunBot activated!\n" +
                       $"SunBot: \"{msg}\"";
        var actual = bot.Update(
            new WeatherData
            {
                Location = "Jenin",
                Temperature = 35,
                Humidity = 40,
            });
        Assert.Equal(expected, actual);
    }
}