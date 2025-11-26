using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class ClientRepository : Repository<Client>
{
    public ClientRepository(MemoryDbContext dbContext) : base(dbContext) { }

    public override  IQueryable<Client> Query() => _dbContext.Clients.AsQueryable();

    public override void Add(Client entity) => _dbContext.Clients.Add(entity);

    public override void Remove(Client entity) => _dbContext.Clients.Remove(entity);

    public override Client? Get(Guid id) => _dbContext.Clients.FirstOrDefault(e => e.Id == id);
}