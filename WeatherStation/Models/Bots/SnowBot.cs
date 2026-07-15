namespace WeatherStation.Models.Bots;

public sealed class SnowBot : WeatherBot
{
    public override string Name => "SnowBot";
    public double TemperatureThreshold { get; set; }

    protected override bool IsThresholdMet(WeatherData data)
    {
        return data.Temperature <= TemperatureThreshold;
    }
}