using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IAccomodationService
{
    Guid Create(string name, string address, int stars);
    Accomodation? Get(Guid id);
    IReadOnlyList<Accomodation> GetAll();
    IReadOnlyList<Room> GetRooms(Guid id);
    IReadOnlyList<Room> GetAvaiableRooms(Guid id);
    void Update(Guid id, string? name = null, string? address = null, int? stars = null);
    void Remove(Guid id);
}