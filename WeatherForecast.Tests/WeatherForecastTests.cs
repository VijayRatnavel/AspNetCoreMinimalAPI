using System.Text.Json;
using WeatherForecast.API.Controllers;
using Xunit.Abstractions;

namespace WeatherForecast.Tests;

public class WeatherForecastTests

{
    private readonly Xunit.Abstractions.ITestOutputHelper _output;
    private readonly WeatherForecastController _weatherForecast;

    public WeatherForecastTests(ITestOutputHelper output)
    {
        _output = output;
        _weatherForecast = new WeatherForecastController();
    }

    [Fact]
    public void GetWeatherForecasts_ReturnObject()
    {
        var result = _weatherForecast.Get(null);
        var expected = typeof(List<WeatherForecast.API.WeatherForecast>);
        var actual = result.ToList();

        //By default, JSON is serialized without any white spaces. 
        //Indented JSON
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(actual, options);
        _output.WriteLine("WeatherForecast JSON\n" + json);

        //Assert.IsType<List<WeatherForecast.API.WeatherForecast>>(actual);
        Assert.IsType(expected, actual);

    }

}