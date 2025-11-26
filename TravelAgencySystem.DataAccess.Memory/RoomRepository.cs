using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class RoomRepository : Repository<Room>
{
    public RoomRepository(MemoryDbContext dbContext) : base(dbContext) { }

    public override  IQueryable<Room> Query() => _dbContext.Rooms.AsQueryable();

    public override void Add(Room entity) => _dbContext.Rooms.Add(entity);

    public override void Remove(Room entity) => _dbContext.Rooms.Remove(entity);

    public override Room? Get(Guid id) => _dbContext.Rooms.FirstOrDefault(e => e.Id == id);

}