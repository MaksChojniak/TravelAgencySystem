using TravelAgencySystem.DataModel;
using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;

namespace TravelAgencySystem.Services.Abstractions;

public class AccomodationService : IAccomodationService
{
    readonly IRepository<Accomodation> _accomodations;
    
    readonly IDbContext _dbContext;

    public AccomodationService(IRepository<Accomodation> accomodations, IDbContext dbContext)
    {
        _accomodations = accomodations;
        _dbContext = dbContext;
    }


    public Guid Create(string name, string address, int stars)
    {
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Name is required", nameof(name));

        if(string.IsNullOrEmpty(address))
            throw new ArgumentException("Address is required", nameof(address));
        
        if(stars < 1 || 5 > stars)
            throw new ArgumentException("Stars is out of range [1,5] ", nameof(stars));

        Accomodation accomodation = new()
        {
            Id = Guid.NewGuid(),

            Name = name,
            Address = address,
            Stars = stars
        };

        _accomodations.Add(accomodation);
        _dbContext.SaveChanges();

        return accomodation.Id;
    }

    public Accomodation? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Accomodation> GetAll()
    {
        throw new NotImplementedException();
    }
}