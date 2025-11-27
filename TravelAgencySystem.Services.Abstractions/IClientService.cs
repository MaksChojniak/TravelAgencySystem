using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IClientService
{
    Guid Create(string firstName, string lastName, string pesel, string phoneNumber, string email, string address);
    Client? Get(Guid id);
    IReadOnlyList<Client> GetAll();
    bool Exist(Guid id);
    void Update(Guid id, string? firstName, string? lastName, string? pesel, string? phoneNumber, string? email, string? address);
}