using WeatherStation.Models;
using WeatherStation.Models.Bots;

var configPath = Path.Combine(AppContext.BaseDirectory, "config.json");
var bots = BotLoader.LoadFromConfigurationFile(configPath);

var weatherStation = new Station();
foreach (var bot in bots)
    weatherStation.RegisterObserver(bot);

var w1 = new WeatherData
{
    Location = "Jenin",
    Temperature = 33,
    Humidity = 50,
};
var w2 = new WeatherData
{
    Location = "Nablus",
    Temperature = 20,
    Humidity = 71,
};
var w3 = new WeatherData
{
    Location = "Ramallah",
    Temperature = -5,
    Humidity = 72,
};
Console.WriteLine();
Console.WriteLine(w1);
weatherStation.NotifyObservers(w1);
Console.WriteLine();
Console.WriteLine(w2);
weatherStation.NotifyObservers(w2);
Console.WriteLine();
Console.WriteLine(w3);
weatherStation.NotifyObservers(w3);