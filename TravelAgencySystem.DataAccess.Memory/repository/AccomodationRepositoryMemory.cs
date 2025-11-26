using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class AccomodationRepository : RepositoryMemory<Accomodation>
{
    public AccomodationRepository(MemoryDbContext dbContext) : base(dbContext) { }

    public override  IQueryable<Accomodation> Query() => _dbContext.Accomodations.AsQueryable();

    public override void Add(Accomodation entity) => _dbContext.Accomodations.Add(entity);

    public override void Remove(Accomodation entity) => _dbContext.Accomodations.Remove(entity);

    public override Accomodation? Get(Guid id) => _dbContext.Accomodations.FirstOrDefault(e => e.Id == id);

}