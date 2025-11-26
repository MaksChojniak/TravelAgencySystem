using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

// public class AccomodationRepository : Repository<Accomodation, Guid>
// {
//     public AccomodationRepository(IDbContext dbContext) : base(dbContext) { }

//     public override void Add(Accomodation entity) => _dbContext.

//     public override  Accomodation? Get(Guid id)
//     {
//         throw new NotImplementedException();
//     }

//     public override  IQueryable<Accomodation> Query()
//     {
//         throw new NotImplementedException();
//     }

//     public override  void Remove(Accomodation entity)
//     {
//         throw new NotImplementedException();
//     }
// }