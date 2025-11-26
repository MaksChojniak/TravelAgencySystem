using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class OffertRepository : Repository<Offert>
{
    public OffertRepository(MemoryDbContext dbContext) : base(dbContext) { }

    public override  IQueryable<Offert> Query() => _dbContext.Offerts.AsQueryable();

    public override void Add(Offert entity) => _dbContext.Offerts.Add(entity);

    public override void Remove(Offert entity) => _dbContext.Offerts.Remove(entity);

    public override Offert? Get(Guid id) => _dbContext.Offerts.FirstOrDefault(e => e.Id == id);

}