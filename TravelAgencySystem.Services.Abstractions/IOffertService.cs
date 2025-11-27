using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IOffertService
{
    Guid Create(Guid hostId, DateTime date, TimeSpan duration, Guid carrierId, Guid accomodationId);
    Offert? Get(Guid id);
    IReadOnlyList<Offert> GetAll();
    IReadOnlyList<Offert> Search<TKey>((DateTime min, DateTime max)? dateRange = null, Func<Offert, TKey>? keySelector = null);
    void Update(Guid id, Guid? hostId, DateTime? date, TimeSpan? duration, Guid? carrierId, Guid? accomodationId);
}