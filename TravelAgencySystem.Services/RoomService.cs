using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class RoomService : IRoomService
{
    readonly IRepository<Room> _rooms;
    readonly IRepository<Accomodation> _accomodations;
    readonly IRepository<Reservation> _reservations;

    readonly IDbContext _dbContext;

    public RoomService(IRepository<Room> rooms, IRepository<Accomodation> accomodations, IRepository<Reservation> reservations, IDbContext dbContext)
    {
        _rooms = rooms;
        _accomodations = accomodations;
        _reservations = reservations;
        _dbContext = dbContext;
    }


    public Guid Create(Guid accomodationId, Guid? reservationId, int floor, int number, int spaceCount, double price)
    {
        if(_accomodations.Get(accomodationId) is null)
            throw new ArgumentException("Accomodation not exist", nameof(accomodationId));

        if(reservationId.HasValue && _reservations.Get(reservationId.Value) is null)
            throw new ArgumentException("Reservation not exist", nameof(reservationId));

        if(floor < 0)
            throw new ArgumentException("Floor must be greater than 0", nameof(floor));

        if(spaceCount < 0)
            throw new ArgumentException("Floor must be greater than 0", nameof(spaceCount));
        
        if(price < 0)
            throw new ArgumentException("Price must be greater than 0", nameof(price));

        Room room = new()
        {
            Id = Guid.NewGuid(),
            
            ReservationId = reservationId ?? Guid.Empty,
            IsAvailable = reservationId is null,
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

    public void Update(Guid id, double? price)
    {
        if(Get(id) is not Room room)
            throw new ArgumentException("Room is not exist", nameof(room));

        if(price < 0)
            throw new ArgumentException("Price must be greater than 0", nameof(price));

        room.Price = price ?? room.Price;

        _dbContext.SaveChanges();
    }

    public void Remove(Guid id)
    {
        if(Get(id) is not Room room)
            throw new ArgumentException("Room is not exist", nameof(room));

        if(!room.IsAvailable)
            throw new InvalidOperationException("Room is not avaiable");

        _rooms.Remove(room);
        _dbContext.SaveChanges();
    }

}