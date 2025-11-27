using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface ICarrierService
{
    Guid Create(string name, TypeOfTransport type, int spaceCount, string startPlace, string returnPlace);
    Carrier? Get(Guid id);
    IReadOnlyList<Carrier> GetAll();
    void Update(Guid id, string? name, TypeOfTransport? type, int? spaceCount, string? startPlace, string? returnPlace);
}