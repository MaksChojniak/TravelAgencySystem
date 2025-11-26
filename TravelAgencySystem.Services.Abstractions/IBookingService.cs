using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;
    
public interface IBookingService
{
    Reservation? CreateReservation(Guid clientId, Guid offertId, IReadOnlyList<Guid> roomIds);
    bool CancelReservation(Guid clientId, Guid reservationId);
    IReadOnlyList<Reservation> GetAllClientReservations(Guid clientId);
    bool CheckAvailability(Guid offertId, int requiredSeats);
}