namespace WeatherStation.Models;

public interface IObservable<T>
{
    void RegisterObserver(IObserver<T> observer);
    void NotifyObservers();
}