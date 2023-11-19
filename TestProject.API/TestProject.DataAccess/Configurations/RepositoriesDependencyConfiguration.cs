using Microsoft.Extensions.DependencyInjection;
using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.DataAccess.Abstraction;
using TestProject.DataAccess.Repositories;

namespace TestProject.DataAccess.Configurations;

public static class RepositoriesDependencyConfiguration
{
    public static void RegisterDataAccess(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();

        services.AddTransient<IPartRepository, PartRepository>();
        services.AddTransient<IVisitRepository, VisitRepository>();
        services.AddTransient<IWorkOrderRepository, WorkOrderRepository>();
    }
}