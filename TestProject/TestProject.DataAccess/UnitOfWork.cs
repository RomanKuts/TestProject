﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestProject.DataAccess.Abstraction;

namespace TestProject.DataAccess;

class UnitOfWork : IUnitOfWork
{
    private readonly DbContext dbContext;

    private readonly IServiceProvider serviceProvider;

    private readonly Dictionary<string, object> repositories;

    public UnitOfWork(
        DbContext dbContext,
        IServiceProvider serviceProvider)
    {
        this.dbContext = dbContext;
        this.serviceProvider = serviceProvider;
        repositories = new Dictionary<string, object>();
    }

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    T IUnitOfWork.GetRepository<T>()
    {
        var typeName = typeof(T).Name;

        if (!this.repositories.ContainsKey(typeName))
        {
            T instance = serviceProvider.GetService<T>();
            instance.SetContext(this.dbContext);
            this.repositories.Add(typeName, instance);
        }

        return (T)this.repositories[typeName];
    }

    public void Dispose()
    {
        this.dbContext.Dispose();
        this.repositories.Clear();
    }
}
