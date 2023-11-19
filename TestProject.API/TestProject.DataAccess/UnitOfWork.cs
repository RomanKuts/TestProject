using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestProject.DataAccess.Abstraction;

namespace TestProject.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;

    private readonly IServiceProvider _serviceProvider;

    private readonly Dictionary<string, object> _repositories;

    public UnitOfWork(
        DbContext dbContext,
        IServiceProvider serviceProvider)
    {
        _dbContext = dbContext;
        _serviceProvider = serviceProvider;
        _repositories = new Dictionary<string, object>();
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    T IUnitOfWork.GetRepository<T>()
    {
        var typeName = typeof(T).Name;

        if (!_repositories.ContainsKey(typeName))
        {
            T instance = _serviceProvider.GetService<T>();
            instance.SetContext(_dbContext);
            _repositories.Add(typeName, instance);
        }

        return (T)_repositories[typeName];
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        _repositories.Clear();
    }
}