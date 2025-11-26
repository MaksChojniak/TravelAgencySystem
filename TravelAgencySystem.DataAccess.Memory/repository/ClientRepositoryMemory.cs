using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class ClientRepository : IRepository<Client, Guid>
{
    public void Add(Client entity)
    {
        throw new NotImplementedException();
    }

    public Client? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Client> Query()
    {
        throw new NotImplementedException();
    }

    public void Remove(Client entity)
    {
        throw new NotImplementedException();
    }
}