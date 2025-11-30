using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IRoomService
{
    Guid Create(Guid accomodationId, Guid? reservationId, int floor, int number, int spaceCount, double price);
    Room? Get(Guid id);
    IReadOnlyList<Room> GetAll();
    void Update(Guid id, double? price = null);
    void Remove(Guid id);
}