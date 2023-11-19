using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestProject.DataAccess.Abstraction;
using TestProject.DataAccess.DataContext;
using TestProject.Domain.Options;

namespace TestProject.DataAccess;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public UnitOfWorkFactory(
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    public IUnitOfWork CreateUnitOfWork()
    {
        var dbContext = CreateDbContext();
        var unitOfWork = new UnitOfWork(dbContext, _serviceProvider);

        return unitOfWork;
    }

    private DbContext CreateDbContext()
    {
        var sqlDbOptions = _configuration.GetSection(DatabaseOptions.SqlDbName).Get<DatabaseOptions>();
        var dbContextOptions = new DbContextOptionsBuilder<Context>()
            .UseSqlServer(sqlDbOptions.ConnectionString)
            .Options;

        return new Context(dbContextOptions);
    }
}