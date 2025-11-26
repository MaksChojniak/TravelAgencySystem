using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface ICatalogService
{
    IReadOnlyList<Offert> Search((DateTime start, DateTime end)? dateRange, (double min, double max)? priceRange);
    IReadOnlyList<Offert> Search<TKey>((DateTime, DateTime)? dateRange, (double, double)? priceRange, Func<Offert, TKey> keySelector);
    IReadOnlyList<Offert> GetAllOfferts();
}