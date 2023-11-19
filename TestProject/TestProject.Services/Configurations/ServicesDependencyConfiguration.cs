using Microsoft.Extensions.DependencyInjection;

namespace TestProject.Services.Configurations;

public static class ServicesDependencyConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<PartService>();
        services.AddTransient<VisitService>();
        services.AddTransient<WorkOrderService>();
    }
}