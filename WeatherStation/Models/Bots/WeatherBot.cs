namespace WeatherStation.Models.Bots;

public abstract class WeatherBot : IObserver<WeatherData>
{
    public bool Enabled { get; set; }
    public abstract string Name { get; }
    public string Message { get; set; } = string.Empty;

    protected abstract bool IsThresholdMet(WeatherData data);

    public string? Update(WeatherData data)
    {
        if (!Enabled || !IsThresholdMet(data)) return null;

        return $"{Name} activated!\n" +
               $"{Name}: \"{Message}\"";
    }
}