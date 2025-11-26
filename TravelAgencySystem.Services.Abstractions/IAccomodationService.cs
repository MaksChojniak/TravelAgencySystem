using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IAccomodationService
{
    Guid Create(string name, string address, int stars);
    Accomodation? Get(Guid id);
    IReadOnlyList<Accomodation> GetAll();
}