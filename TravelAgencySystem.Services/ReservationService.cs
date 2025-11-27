using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class ReservationService : IReservationService
{
    readonly IRepository<Reservation> _reservation;

    readonly IDbContext _dbContext;

    public ReservationService(IRepository<Reservation> reservation, IDbContext dbContext)
    {
        _reservation = reservation;
        _dbContext = dbContext;
    }


    public Guid Create(Guid personId, Guid offertId)
    {
        throw new NotImplementedException();
    }

    public Reservation? Get(Guid id) => _reservation.Get(id);

    public IReadOnlyList<Reservation> GetAll() => _reservation.Query().ToList();

    public void Update(Guid id, Guid? personId, Guid? offertId)
    {
        if(Get(id) is not Reservation reservation)
            throw new ArgumentException("Reservation is not exist", nameof(reservation));

        reservation.PersonId = personId ?? reservation.PersonId;
        reservation.OffertId = offertId ?? reservation.OffertId;

        _dbContext.SaveChanges();
    }

}