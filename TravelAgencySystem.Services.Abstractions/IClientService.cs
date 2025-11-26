using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IClientService
{
    Guid Create();
    Client? Get(Guid id);
    IReadOnlyList<Client> GetAll();
}