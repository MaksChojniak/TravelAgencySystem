using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class ReservationService : IReservationService
{
    readonly IRepository<Reservation> _reservation;
    readonly IRepository<Offert> _offerts;
    readonly IRepository<Client> _clients;
    readonly IRepository<Room> _rooms;

    readonly IDbContext _dbContext;

    public ReservationService(IRepository<Reservation> reservation, IRepository<Offert> offerts, IRepository<Client> clients, IRepository<Room> rooms, IDbContext dbContext)
    {
        _reservation = reservation;
        _offerts = offerts;
        _clients = clients;
        _rooms = rooms;
        _dbContext = dbContext;
    }


    public Guid Create(Guid clientId, Guid offertId, double price, IReadOnlyList<Guid> roomIds)
    {
        if(_clients.Get(clientId) is null)
            throw new ArgumentException("Client not exist", nameof(clientId));

        if(_offerts.Get(offertId) is null)
            throw new ArgumentException("Offert not exist", nameof(offertId));

        if(price < 0)
            throw new ArgumentException("Price must be greater than 0", nameof(price));

        if(roomIds.Count <= 0)
            throw new ArgumentException("No rooms selected", nameof(roomIds));

        if(roomIds.Any(roomId => _rooms.Get(roomId) is null))
            throw new ArgumentException("Some rooms not exist", nameof(roomIds));

        if(roomIds.Any(roomId => !_rooms.Get(roomId).IsAvailable))
            throw new ArgumentException("Some rooms not avaiable", nameof(roomIds));

        if(_reservation.Query().Any(r => r.ClientId == clientId && r.OffertId == offertId))
            throw new ArgumentException("Reservation for this Client already exist");

        Reservation reservation = new()
        {
            Id = Guid.NewGuid(),

            ClientId = clientId,
            OffertId = offertId,
            Status = ReservationStatus.InProgress,
            Price = price,
            NumberOfPeople = roomIds.Sum(roomId => _rooms.Get(roomId).SpaceCount)
        };

        foreach(var roomId in roomIds)
        {
            var room = _rooms.Get(roomId);
            room.IsAvailable = false;
            room.ReservationId = reservation.Id;
        }
        
        _reservation.Add(reservation);
        _dbContext.SaveChanges();

        return reservation.Id;
    }

    public Reservation? Get(Guid id) => _reservation.Get(id);

    public void Update(Guid id, ReservationStatus? status)
    {
        if(Get(id) is not Reservation reservation)
            throw new ArgumentException("Reservation is not exist", nameof(reservation));

        reservation.Status = status ?? reservation.Status;
        _dbContext.SaveChanges();
    }

    public void Remove(Guid id)
    {
        if(Get(id) is not Reservation reservation)
            throw new ArgumentException("Reservation is not exist", nameof(reservation));

        foreach(var roomId in _rooms.Query().Where(r => r.ReservationId == reservation.Id).Select(r => r.Id))
        {
            var room = _rooms.Get(roomId);
            room.IsAvailable = true;
            room.ReservationId = Guid.Empty;
        }
        _reservation.Remove(reservation);
        _dbContext.SaveChanges();
    }

}