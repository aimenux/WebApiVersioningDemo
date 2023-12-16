using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioningDemo.Api.Controllers.V1;

[ApiController]
[ApiVersion("1.0", Deprecated = true)]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeathersController : ControllerBase
{
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
                CelsiusTemperature = Random.Shared.Next(-20, 60)
            })
            .ToList();
        return weathers;
    }
}
