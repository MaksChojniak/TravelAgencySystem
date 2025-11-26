using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IReservationService
{
    Guid Create();
    Reservation? Get(Guid id);
    IReadOnlyList<Reservation> GetAll();
}