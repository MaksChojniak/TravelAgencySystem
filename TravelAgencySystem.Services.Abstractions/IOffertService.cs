using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IOffertService
{
    Guid Create(Guid hostId, string title, DateTime date, TimeSpan duration, Guid carrierId, Guid accomodationId);
    Offert? Get(Guid id);
    IReadOnlyList<Offert> GetAll();
    IReadOnlyList<Offert> Search(DateTime? min = null, DateTime? max = null);
    int FreeSpaces(Guid id);
    void Remove(Guid id);
}