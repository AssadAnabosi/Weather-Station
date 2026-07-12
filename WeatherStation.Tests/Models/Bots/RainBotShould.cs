using JetBrains.Annotations;
using WeatherStation.Models;
using WeatherStation.Models.Bots;

namespace WeatherStation.Tests.Models.Bots;

[TestSubject(typeof(RainBot))]
public class RainBotShould
{
    [Fact]
    public void EmptyString_WhenDisabled()
    {
        RainBot bot = new()
        {
            Enabled = false,
            HumidityThreshold = 70,
            Message = "This Should not be displayed"
        };
        var expected = "";
        var actual = bot.Update(
            new WeatherData
            {
                Location = "London",
                Temperature = 20,
                Humidity = 71,
            });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EmptyString_WhenThresholdNotMet()
    {
        RainBot bot = new()
        {
            Enabled = true,
            HumidityThreshold = 70,
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
        var msg = "It looks like it's about to pour down!";
        RainBot bot = new()
        {
            Enabled = true,
            HumidityThreshold = 70,
            Message = msg
        };
        var expected = $"RainBot activated!\n" +
                       $"RainBot: \"{msg}\"";
        var actual = bot.Update(
            new WeatherData
            {
                Location = "London",
                Temperature = 20,
                Humidity = 71,
            });
        Assert.Equal(expected, actual);
    }
}