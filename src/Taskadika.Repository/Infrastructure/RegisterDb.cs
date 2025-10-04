using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taskadika.Repository.Context;

namespace Taskadika.Repository.Infrastructure;

public static class RegisterDb
{
    public static void RegisterPostgresDataBase(
        this IServiceCollection services,
        string? connectionString
    )
    {
        if (!string.IsNullOrEmpty(connectionString))
        {
            services.AddDbContext<TaskadikaDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
