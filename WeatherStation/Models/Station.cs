using WeatherStation.Models.Bots;

namespace WeatherStation.Models;

public class Station : IObservable<IWeatherBot, WeatherData>
{
    private List<IWeatherBot> _observers = new();

    public void RegisterObserver(IWeatherBot observer)
    {
        _observers.Add(observer);
    }

    public void NotifyObservers(WeatherData data)
    {
        foreach (var observer in _observers)
        {
            var result = observer.Update(data);
            if (result.Length !=0)
                Console.WriteLine(result);
        }
            
    }
}