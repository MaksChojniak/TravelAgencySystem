using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class ClientService : IClientService
{
    readonly IRepository<Client> _clients;
    readonly IRepository<Reservation> _reservations;

    readonly IDbContext _dbContext;

    public ClientService(IRepository<Client> clients, IRepository<Reservation> reservations, IDbContext dbContext)
    {
        _clients = clients;
        _reservations = reservations;
        _dbContext = dbContext;
    }

    public Client? Get(Guid id) => _clients.Get(id);

    public IReadOnlyList<Reservation> GetAllReservations(Guid clientId)
    {
        if(Get(clientId) is null)
            throw new ArgumentException("Client not exist", nameof(clientId));

        return _reservations.Query().Where(r => r.ClientId == clientId).ToList();
    }

    // public IReadOnlyList<Client> GetAll() => _clients.Query().ToList();

    public void Update(Guid id, string? firstName, string? lastName, string? pesel, string? phoneNumber, string? email, string? address)
    {
        if(Get(id) is not Client client)
            throw new ArgumentException("Client not exist", nameof(client));

        client.FirstName = firstName ?? client.FirstName;
        client.LastName = lastName ?? client.LastName;
        client.Pesel = pesel ?? client.Pesel;
        client.PhoneNumber = phoneNumber ?? client.PhoneNumber;
        client.Email = email ?? client.Email;
        client.Address = address ?? client.Address;

        _dbContext.SaveChanges();
    }
}