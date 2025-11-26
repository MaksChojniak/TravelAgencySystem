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

    public Reservation? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Reservation> GetAll()
    {
        throw new NotImplementedException();
    }
}