namespace TravelAgencySystem.DataAccess.Abstractions;

public interface IRepository<T>
{
    IQueryable<T> Query();
    T? Get(Guid id);
    void Add(T entity);
    void Remove(T entity);
}