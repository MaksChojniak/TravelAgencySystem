using TravelAgencySystem.Database.Memory;

namespace TravelAgencySystem.DataAccess.Abstractions;

public abstract class Repository<T> : IRepository<T>
{
    protected MemoryDbContext _dbContext;

    public Repository(MemoryDbContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public abstract void Add(T entity);
    public abstract T? Get(Guid id);
    public abstract IQueryable<T> Query();
    public abstract void Remove(T entity);
}