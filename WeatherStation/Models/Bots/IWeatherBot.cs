namespace WeatherStation.Models.Bots;

public interface IWeatherBot : IObserver<WeatherData>
{
    public bool Enabled { get; }
    public string Name { get; }
    new void Update(WeatherData data);
}