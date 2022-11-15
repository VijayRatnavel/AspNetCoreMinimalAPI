using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController>? _logger;

    public WeatherForecastController()
    {

    }

    [ActivatorUtilitiesConstructor]
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        var userId = Guid.NewGuid();
        _logger = logger;
        _logger.LogInformation("Weather check by user ID {UserID}.", userId);
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get(ILogger<WeatherForecastController>? _logger)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
