namespace TestProject.DataAccess.Abstraction.Repositories.Base;

public interface IRepository<TEntity, in TKey> : IBaseRepository
{
    Task<ICollection<TEntity>> GetAllAsync();

    void Add(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);
}