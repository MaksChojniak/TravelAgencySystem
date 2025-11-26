using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IOffertService
{
    Guid Create();
    Offert? Get(Guid id);
    IReadOnlyList<Offert> GetAll();
}