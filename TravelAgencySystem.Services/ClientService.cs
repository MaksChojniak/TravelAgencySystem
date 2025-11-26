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

    public Client? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Client> GetAll()
    {
        throw new NotImplementedException();
    }
}