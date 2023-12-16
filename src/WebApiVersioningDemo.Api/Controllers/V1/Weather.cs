namespace WebApiVersioningDemo.Api.Controllers.V1;

public class Weather
{
    public DateOnly Date { get; init; }
    public int CelsiusTemperature { get; init; }
}
