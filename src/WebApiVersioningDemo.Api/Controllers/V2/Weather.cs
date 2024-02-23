namespace WebApiVersioningDemo.Api.Controllers.V2;

public record Weather
{
    public DateOnly Date { get; init; }
    public int CelsiusTemperature { get; init; }
    public int FahrenheitTemperature => 32 + (int)(CelsiusTemperature / 0.5556);
}
