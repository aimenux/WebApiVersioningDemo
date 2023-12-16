namespace WebApiVersioningDemo.Api.Controllers.V3;

public class Weather
{
    public DateOnly Date { get; init; }
    public int CelsiusTemperature { get; init; }
    public int FahrenheitTemperature => 32 + (int)(CelsiusTemperature / 0.5556);
    public string? Summary { get; init; }
}
