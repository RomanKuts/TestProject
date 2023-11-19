using Microsoft.Extensions.DependencyInjection;
using TestProject.DataAccess.Abstraction;
using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.DataAccess.Repositories;
using TestProject.Infrastructure.DataBaseConfiguration;

namespace TestProject.DataAccess.Configurations;

public static class RepositoriesDependencyConfiguration
{
    public static void RegisterDataAccess(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
        services.AddScoped<IDatabaseConnectionProvider, DatabaseConnectionProvider>();

        services.AddTransient<IPartRepository, PartRepository>();
        services.AddTransient<IVisitRepository, VisitRepository>();
        services.AddTransient<IWorkOrderRepository, WorkOrderRepository>();
    }
}