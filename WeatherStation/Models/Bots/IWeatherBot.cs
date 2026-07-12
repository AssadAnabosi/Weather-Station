namespace WeatherStation.Models.Bots;

public interface IWeatherBot : IObserver<WeatherData>
{
    public bool Enabled { get; }
    public string Name { get; }
    public string Message { get; }
    new string Update(WeatherData data);
}