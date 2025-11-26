using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IAccomodationService
{
    Guid Create();
    Accomodation? Get(Guid id);
    IReadOnlyList<Accomodation> GetAll();
}