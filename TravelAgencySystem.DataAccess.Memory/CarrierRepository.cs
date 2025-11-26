using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class CarrierRepository : Repository<Carrier>
{
    public CarrierRepository(MemoryDbContext dbContext) : base(dbContext) { }

    public override  IQueryable<Carrier> Query() => _dbContext.Carriers.AsQueryable();

    public override void Add(Carrier entity) => _dbContext.Carriers.Add(entity);

    public override void Remove(Carrier entity) => _dbContext.Carriers.Remove(entity);

    public override Carrier? Get(Guid id) => _dbContext.Carriers.FirstOrDefault(e => e.Id == id);
}
