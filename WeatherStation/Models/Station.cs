using WeatherStation.Models.Bots;

namespace WeatherStation.Models;

public class Station : IObservable<WeatherBot, WeatherData>
{
    private List<WeatherBot> _observers = new();

    public void RegisterObserver(WeatherBot observer)
    {
        _observers.Add(observer);
    }

    public void NotifyObservers(WeatherData data)
    {
        foreach (var observer in _observers)
        {
            var result = observer.Update(data);
            if (result != null)
                Console.WriteLine(result);
        }
            
    }
}