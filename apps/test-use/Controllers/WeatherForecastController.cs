using cal_lib.Service;
using Microsoft.AspNetCore.Mvc;
using product_sv.Service;

namespace Api.TestUse.Controllers;

[ApiController]
[Route("api")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // [HttpGet(Name = "GetWeatherForecast")]
    [Route("forecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        Console.WriteLine(ProductServices.GetProduct()) ;
        Console.WriteLine(Calculate.CalulateMutiple(10));
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            Name = ProductServices.GetProduct(),
            Number = Calculate.CalulateMutiple(index)
        })
        .ToArray();
        
    }
}
