namespace Taskadika.Infrastructure;

public static class RegisterDIService
{
    public static void RegisterDIServices(this IServiceCollection services)
    {
        services.RegisterDomainServices();
        services.RegisterRepositories();
    }

    private static void RegisterDomainServices(this IServiceCollection services) { }

    private static void RegisterRepositories(this IServiceCollection services) { }
}
