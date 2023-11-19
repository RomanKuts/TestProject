using Microsoft.Extensions.DependencyInjection;
using TestProject.Services.Abstraction;

namespace TestProject.Services.Configurations;

public static class ServicesDependencyConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IPartService, PartService>();
        services.AddTransient<IVisitService, VisitService>();
        services.AddTransient<IWorkOrderService, WorkOrderService>();
    }
}