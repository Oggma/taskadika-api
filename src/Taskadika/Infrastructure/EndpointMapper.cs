namespace Taskadika.Infrastructure;

public static class EndpointMapper
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapControllers();
        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}
