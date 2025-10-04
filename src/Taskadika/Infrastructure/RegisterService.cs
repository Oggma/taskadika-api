using System.Text.Json;
using System.Text.Json.Serialization;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;

namespace Taskadika.Infrastructure;

public static class RegisterService
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.RegisterDIServices();
        services.AddApiVersioning();
        services.AddScalarService();
        services.AddHttpServices();
        services.AddControllerServices();
        services.AddAuthorization();
        services.AddHttpClient();
    }

    private static void AddControllerServices(this IServiceCollection services)
    {
        services
            .AddControllers(options => { })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
    }

    private static void AddApiVersioning(this IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0); //same as ApiVersion.Default
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("X-Version")
                );
            })
            .AddMvc(options => { })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }

    private static void AddScalarService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer(); // Required for minimal APIs

        // Scalar setup
        var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            services.AddOpenApi(
                $"v{description.ApiVersion.MajorVersion}",
                options =>
                {
                    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
                }
            );
        }
    }

    private static void AddHttpServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddHttpClient();
    }
}
