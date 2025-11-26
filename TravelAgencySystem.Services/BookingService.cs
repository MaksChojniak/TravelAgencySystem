using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class BookingService : IBookingService
{
    readonly IDbContext _dbContext;

    public BookingService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public bool CancelReservation(Guid clientId, Guid reservationId)
    {
        throw new NotImplementedException();
    }

    public bool CheckAvailability(Guid offertId, int requiredSeats)
    {
        throw new NotImplementedException();
    }

    public Reservation? CreateReservation(Guid clientId, Guid offertId, IReadOnlyList<Guid> roomIds)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Reservation> GetAllClientReservations(Guid clientId)
    {
        throw new NotImplementedException();
    }
}