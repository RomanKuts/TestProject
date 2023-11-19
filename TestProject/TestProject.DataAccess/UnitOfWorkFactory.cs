using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Abstraction;
using TestProject.DataAccess.DataContext;
using TestProject.Infrastructure.DataBaseConfiguration;

namespace TestProject.DataAccess;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IServiceProvider serviceProvider;
    private readonly IDatabaseConnectionProvider databaseConnectionProvider;

    public UnitOfWorkFactory(
        IServiceProvider serviceProvider,
        IDatabaseConnectionProvider databaseConnectionProvider)
    {
        this.serviceProvider = serviceProvider;
        this.databaseConnectionProvider = databaseConnectionProvider;
    }

    public IUnitOfWork CreateUnitOfWork()
    {
        var dbContext = this.CreateDbContext();
        var unitOfWork = new UnitOfWork(dbContext, this.serviceProvider);

        return unitOfWork;
    }

    private DbContext CreateDbContext()
    {
        var dbConnectionString = this.databaseConnectionProvider.GetDatabaseConnectionString();
        var dbContextOptions = new DbContextOptionsBuilder<Context>()
            .UseSqlServer(dbConnectionString)
            .Options;

        return new Context(dbContextOptions);
    }
}