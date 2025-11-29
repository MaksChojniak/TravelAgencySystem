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
        // throw new NotImplementedException();
        Room room = new()
        {
            Id = Guid.NewGuid(),
            
            ReservationId = reservationId,
            IsAvaiable = reservationId == Guid.Empty,
            AccomodationId = accomodationId,
            Number = number,
            Floor = floor,
            SpaceCount = spaceCount,
            Price = price
        };
        _rooms.Add(room);
        _dbContext.SaveChanges();

        return room.Id;
    }

    public Room? Get(Guid id) => _rooms.Get(id);

    public IReadOnlyList<Room> GetAll() => _rooms.Query().ToList();

    public void Update(Guid id, Guid? accomodationId, Guid? reservationId, int? floor, int? number, int? spaceCount, double? price)
    {
        if(Get(id) is not Room room)
            throw new ArgumentException("Room is not exist", nameof(room));

        room.AccomodationId = accomodationId ?? room.AccomodationId;
        room.ReservationId = reservationId ?? room.ReservationId;
        room.Floor = floor ?? room.Floor;
        room.Number = number ?? room.Number;
        room.SpaceCount = spaceCount ?? room.SpaceCount;
        room.Price = price ?? room.Price;

        _dbContext.SaveChanges();
    }

}