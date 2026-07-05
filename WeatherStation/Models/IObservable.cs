namespace WeatherStation.Models;

public interface IObservable<T1, T2>
{
    void RegisterObserver(T1 observer);
    void NotifyObservers(T2 data);
}