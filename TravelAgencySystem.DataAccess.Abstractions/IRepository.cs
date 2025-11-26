namespace TravelAgencySystem.DataAccess.Abstractions;

public interface IRepository<T, TKeyID>
{
    IQueryable<T> Query();
    T? Get(TKeyID id);
    void Add(T entity);
    void Remove(T entity);
}