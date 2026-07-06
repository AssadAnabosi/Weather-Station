using WeatherStation.Models;
using WeatherStation.Models.Bots;
using WeatherStation.Models.Parsers;

var configPath = Path.Combine(AppContext.BaseDirectory, "config.json");
var bots = BotLoader.LoadFromConfigurationFile(configPath);

var weatherStation = new Station();
foreach (var bot in bots)
    weatherStation.RegisterObserver(bot);

var weatherParser = new CompositeWeatherDataParser();

while (true)
{
    Console.Write("Enter weather data (or 'exit' to quit): ");
    var input = Console.ReadLine()?.Trim();

    if (string.IsNullOrEmpty(input))
        continue;

    if (input == "exit" || input == "quit")
        break;

    try
    {
        var data = weatherParser.Parse(input);
        Console.WriteLine(data);
        weatherStation.NotifyObservers(data);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }

    Console.WriteLine();
}