using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IReservationService
{
    Guid Create(Guid clientId, Guid offertId, double price, IReadOnlyList<Guid> roomIds);
    Reservation? Get(Guid id);
    void Update(Guid id, ReservationStatus? status = null);
    void Remove(Guid id);
}