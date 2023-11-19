using TestProject.DataAccess.Abstraction.Repositories.Base;

namespace TestProject.DataAccess.Abstraction;

public interface IUnitOfWork : IDisposable
{
    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cansellationToken = default(CancellationToken));

    T GetRepository<T>()
        where T : class, IBaseRepository;
}