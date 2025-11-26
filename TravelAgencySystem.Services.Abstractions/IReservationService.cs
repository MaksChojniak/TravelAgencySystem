using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IReservationService
{
    Guid Create(Guid personId, Guid offertId);
    Reservation? Get(Guid id);
    IReadOnlyList<Reservation> GetAll();
}