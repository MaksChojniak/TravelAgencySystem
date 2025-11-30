using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IClientService
{
    Client? Get(Guid id);
    // IReadOnlyList<Client> GetAll();
    void Update(Guid id, string? firstName = null, string? lastName = null, string? pesel = null, string? phoneNumber = null, string? email = null, string? address = null);
    IReadOnlyList<Reservation> GetAllReservations(Guid clientId);
}