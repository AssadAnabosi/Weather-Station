namespace WeatherStation.Models.Bots;

public sealed class SunBot : WeatherBot
{
    public override string Name => "SunBot";
    public double TemperatureThreshold { get; set; }

    protected override bool IsThresholdMet(WeatherData data)
    {
        return data.Temperature >= TemperatureThreshold;
    }
}