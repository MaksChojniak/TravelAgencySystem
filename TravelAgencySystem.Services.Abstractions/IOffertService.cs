using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IOffertService
{
    Guid Create(Guid hostId, DateTime date, TimeSpan duration, Guid carrierId, Guid accomodationId);
    Offert? Get(Guid id);
    IReadOnlyList<Offert> GetAll();
}