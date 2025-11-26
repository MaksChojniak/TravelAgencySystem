using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class CatalogService : ICatalogService
{
    readonly IDbContext _dbContext;

    public CatalogService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IReadOnlyList<Offert> GetAllOfferts()
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Offert> Search((DateTime start, DateTime end)? dateRange, (double min, double max)? priceRange)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Offert> Search<TKey>((DateTime, DateTime)? dateRange, (double, double)? priceRange, Func<Offert, TKey> keySelector)
    {
        throw new NotImplementedException();
    }
}