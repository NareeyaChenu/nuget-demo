using Api.GrpcClientSv;
using cal_lib.Service;
using GrpcClientSv.Interface;
using GrpcClientSv.Services;
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
  private readonly IArticleClientSv articleClient;

  public WeatherForecastController(ILogger<WeatherForecastController> logger, IArticleClientSv articleClient)
  {
    _logger = logger;
    this.articleClient = articleClient;
  }

  // [HttpGet(Name = "GetWeatherForecast")]
  [Route("forecast")]
  public IEnumerable<WeatherForecast> Get()
  {
    GetReply reply = new GetReply();
    Console.WriteLine(ProductServices.GetProduct());
    Console.WriteLine(Calculate.CalulateMutiple(10));
    List<string> articles = new List<string>();
    foreach (var item in Summaries)
    {
      GetRequest request = new GetRequest();
      request.Name = item;
      reply = articleClient.Get(request);
      if(reply != null)
        articles.Add(reply.Message);
    }
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateTime.Now.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)],
      Name = ProductServices.GetProduct(),
      Number = Calculate.CalulateMutiple(index),
      ArticleName = articles[Random.Shared.Next(articles.Count)]
      
    })
    .ToArray();

  }
}
