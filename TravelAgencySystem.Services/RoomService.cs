using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class RoomService : IRoomService
{
    readonly IRepository<Room> _rooms;

    readonly IDbContext _dbContext;

    public RoomService(IRepository<Room> rooms, IDbContext dbContext)
    {
        _rooms = rooms;
        _dbContext = dbContext;
    }


    public Guid Create(Guid accomodationId, Guid reservationId, int floor, int number, int spaceCount, double price)
    {
        throw new NotImplementedException();
    }

    public Room? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Room> GetAll()
    {
        throw new NotImplementedException();
    }
}