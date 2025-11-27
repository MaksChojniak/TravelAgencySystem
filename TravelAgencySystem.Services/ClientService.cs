using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class ClientService : IClientService
{
    readonly IRepository<Client> _clients;

    readonly IDbContext _dbContext;

    public ClientService(IRepository<Client> clients, IDbContext dbContext)
    {
        _clients = clients;
        _dbContext = dbContext;
    }

    public Guid Create(string firstName, string lastName, string pesel, string phoneNumber, string email, string address)
    {
        throw new NotImplementedException();
    }

    public Client? Get(Guid id) => _clients.Get(id);

    public IReadOnlyList<Client> GetAll() => _clients.Query().ToList();

    public bool Exist(Guid id) => _clients.Query().Any(e => e.Id == id);

    public void Update(Guid id, string? firstName, string? lastName, string? pesel, string? phoneNumber, string? email, string? address)
    {
        if(Get(id) is not Client client)
            throw new ArgumentException("Client is not exist", nameof(client));

        client.FirstName = firstName ?? client.FirstName;
        client.LastName = lastName ?? client.LastName;
        client.Pesel = pesel ?? client.Pesel;
        client.PhoneNumber = phoneNumber ?? client.PhoneNumber;
        client.Email = email ?? client.Email;
        client.Address = address ?? client.Address;

        _dbContext.SaveChanges();
    }

}