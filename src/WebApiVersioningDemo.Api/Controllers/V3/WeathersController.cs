using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioningDemo.Api.Controllers.V3;

[ApiController]
[ApiVersion("3.0")]
[ApiVersion("3.1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeathersController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeathersController> _logger;

    public WeathersController(ILogger<WeathersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Weather> GetWeathers()
    {
        var weathers = Enumerable.Range(1, 5)
            .Select(index => new Weather
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                CelsiusTemperature = Random.Shared.Next(-20, 60),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        return weathers;
    }

    [MapToApiVersion("3.1")]
    [HttpGet("search")]
    public IEnumerable<Weather> SearchWeathers()
    {
        var weathers = Enumerable.Range(1, 5)
            .Select(index => new Weather
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                CelsiusTemperature = Random.Shared.Next(-20, 60)
            })
            .ToList();
        return weathers;
    }
}
