using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IRoomService
{
    Guid Create();
    Room? Get(Guid id);
    IReadOnlyList<Room> GetAll();
}