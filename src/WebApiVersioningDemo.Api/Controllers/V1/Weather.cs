namespace WebApiVersioningDemo.Api.Controllers.V1;

public record Weather
{
    public DateOnly Date { get; init; }
    public int CelsiusTemperature { get; init; }
}
