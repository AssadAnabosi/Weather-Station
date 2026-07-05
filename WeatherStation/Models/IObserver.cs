namespace WeatherStation.Models;

public interface IObserver<T>
{
    public void Update(T data);
}