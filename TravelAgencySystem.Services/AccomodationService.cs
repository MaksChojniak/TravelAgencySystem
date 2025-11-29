using TravelAgencySystem.DataModel;
using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;

namespace TravelAgencySystem.Services.Abstractions;

public class AccomodationService : IAccomodationService
{
    readonly IRepository<Accomodation> _accomodations;
    readonly IRepository<Room> _rooms;
    
    readonly IDbContext _dbContext;

    public AccomodationService(IRepository<Accomodation> accomodations, IRepository<Room> rooms, IDbContext dbContext)
    {
        _accomodations = accomodations;
        _rooms = rooms;
        _dbContext = dbContext;
    }


    public Guid Create(string name, string address, int stars)
    {
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Name is required", nameof(name));

        if(string.IsNullOrEmpty(address))
            throw new ArgumentException("Address is required", nameof(address));
        
        if(  stars < 1 || 5 < stars)
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

    public Accomodation? Get(Guid id) => _accomodations.Get(id);

    public IReadOnlyList<Accomodation> GetAll() => _accomodations.Query().ToList();

    public IReadOnlyList<Room> GetRooms(Guid id) => _rooms.Query().Where(r => r.AccomodationId == id).ToList();
    public IReadOnlyList<Room> GetAvaiableRooms(Guid id) => _rooms.Query().Where(r => r.AccomodationId == id && r.IsAvaiable).ToList();

    public void Update(Guid id, string? name, string? address, int? stars)
    {
        if(Get(id) is not Accomodation accomodation)
            throw new ArgumentException("Accomodation is not exist", nameof(accomodation));

        accomodation.Name = name ?? accomodation.Name;
        accomodation.Address = address ?? accomodation.Address;
        accomodation.Stars = stars ?? accomodation.Stars;

        _dbContext.SaveChanges();
    }
}