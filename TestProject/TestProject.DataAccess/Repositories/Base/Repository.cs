using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Abstraction.Repositories.Base;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
                 where TEntity : class
{
    protected Repository() { }

    protected Repository(DbContext dbContext)
    {
        SetContext(dbContext);
    }

    protected DbContext DbContext { get; private set; }

    protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

    protected IQueryable<TEntity> Queryable => DbSet.AsQueryable();

    public void SetContext(DbContext context)
    {
        DbContext = context;
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Attach(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(TEntity entity)
    {
        DbSet.Remove(entity);
    }
}