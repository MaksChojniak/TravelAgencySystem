using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class ReservationRepositoryMemory : RepositoryMemory<Reservation>
{
    public ReservationRepositoryMemory(MemoryDbContext dbContext) : base(dbContext) { }

    public override  IQueryable<Reservation> Query() => _dbContext.Reservations.AsQueryable();

    public override void Add(Reservation entity) => _dbContext.Reservations.Add(entity);

    public override void Remove(Reservation entity) => _dbContext.Reservations.Remove(entity);

    public override Reservation? Get(Guid id) => _dbContext.Reservations.FirstOrDefault(e => e.Id == id);

}