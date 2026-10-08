using WeatherStation.Models;

namespace WeatherStation.Tests.Models.Bots;

public class InternalWeatherData
{
    public static IEnumerable<object[]> Data
    {
        get
        {
            yield return CreateCase("City Name", 32, 40);

            yield return CreateCase("London", 18, 82);

            yield return CreateCase("Jericho", 45, 15);

            yield return CreateCase("SPB", -8, 91);

            yield return CreateCase("Liverpool", 26, 65);
        }
    }

    private static object[] CreateCase(string location, double temperature, int humidity)
    {
        var expected = new WeatherData
        {
            Location = location,
            Temperature = temperature,
            Humidity = humidity
        };

        return new object[]
        {
            new Dictionary<string, string>
            {
                ["JSON"] = $$"""
                             {
                                 "Location": "{{location}}",
                                 "Temperature": {{temperature}},
                                 "Humidity": {{humidity}}
                             }
                             """,
                ["XML"] = $$"""
                            <WeatherData>
                                <Location>{{location}}</Location>
                                <Temperature>{{temperature}}</Temperature>
                                <Humidity>{{humidity}}</Humidity>
                            </WeatherData>
                            """
            },
            expected
        };
    }
}