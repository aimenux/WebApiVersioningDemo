using Asp.Versioning;

namespace WebApiVersioningDemo.Api.Extensions;

public static class VersioningExtensions
{
    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        const string name = "x-api-version";
        var defaultVersion = new ApiVersion(1, 0);
        services
            .AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = defaultVersion;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader(name),
                    new HeaderApiVersionReader(name),
                    new MediaTypeApiVersionReader(name));
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.DefaultApiVersion = defaultVersion;
            });
        return services;
    }
}
