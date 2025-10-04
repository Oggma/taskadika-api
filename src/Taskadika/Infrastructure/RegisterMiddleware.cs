using Scalar.AspNetCore;
using Taskadika.Repository.Infrastructure;

namespace Taskadika.Infrastructure;

public static class RegisterMiddleware
{
    public static void RegisterMiddlewares(this WebApplication app)
    {
        app.RegisterScalar();

        if (app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error-local-development");
        }
        else
        {
            app.UseExceptionHandler("/error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UpdateDatabase();
    }

    private static void RegisterScalar(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.Servers = [];

            // Bearer
            options.AddPreferredSecuritySchemes("Bearer").WithDynamicBaseServerUrl();
        });
    }
}
