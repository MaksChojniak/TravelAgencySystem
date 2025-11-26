using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface ICarrierService
{
    Guid Create();
    Carrier? Get(Guid id);
    IReadOnlyList<Carrier> GetAll();
}