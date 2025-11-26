using TravelAgencySystem.Database.Memory;

namespace TravelAgencySystem.DataAccess.Abstractions;

public abstract class RepositoryMemory<T, TKeyID> : IRepository<T, TKeyID>
{
    protected MemoryDbContext _dbContext;

    public RepositoryMemory(MemoryDbContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public abstract void Add(T entity);
    public abstract T? Get(TKeyID id);
    public abstract IQueryable<T> Query();
    public abstract void Remove(T entity);
}