namespace WeatherStation.Models;

public interface IObserver<T>
{
    public string? Update(T data);
}