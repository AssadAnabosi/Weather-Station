namespace WeatherStation.Models.Bots;

public sealed class RainBot : WeatherBot
{
    public override string Name => "RainBot";
    public double HumidityThreshold { get; set; }

    protected override bool IsThresholdMet(WeatherData data)
    {
        return data.Humidity >= HumidityThreshold;
    }
}