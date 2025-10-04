using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taskadika.Repository.Context;

namespace Taskadika.Repository.Infrastructure;

public static class MigrateDb
{
    public static void UpdateDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<TaskadikaDbContext>();
        context?.Database.Migrate();
    }
}
