namespace WebApiVersioningDemo.Api.Extensions;

public static class ServicesExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddVersioning();
        builder.Services.AddSwaggerDoc();
        return builder;
    }
}
