using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class CarrierService : ICarrierService
{
    readonly IRepository<Carrier> _carriers;

    readonly IDbContext _dbContext;

    public CarrierService(IRepository<Carrier> carriers, IDbContext dbContext)
    {
        _carriers = carriers;
        _dbContext = dbContext;
    }

    public Guid Create(string name, TypeOfTransport type, int spaceCount, string startPlace, string returnPlace)
    {
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Name is required", nameof(name));

        if(spaceCount <= 0)
            throw new ArgumentException("Space Count must be greater than 0", nameof(name));

        if(string.IsNullOrEmpty(startPlace))
            throw new ArgumentException("Name is required", nameof(name));

        if(string.IsNullOrEmpty(returnPlace))
            throw new ArgumentException("Name is required", nameof(name));

        Carrier carrier = new()
        {
            Id = Guid.NewGuid(),

            Name = name,
            Type = type,
            SpaceCount = spaceCount,
            StartPlace = startPlace,
            ReturnPlace = returnPlace
        };

        _carriers.Add(carrier);
        _dbContext.SaveChanges();

        return carrier.Id;
    }

    public Carrier? Get(Guid id) => _carriers.Get(id);

    public IReadOnlyList<Carrier> GetAll() => _carriers.Query().ToList();

    public void Update(Guid id, string? name, TypeOfTransport? type, int? spaceCount, string? startPlace, string? returnPlace)
    {
        if(Get(id) is not Carrier carrier)
            throw new ArgumentException("Carrier is not exist", nameof(carrier));

        carrier.Name = name ?? carrier.Name;
        carrier.Type = type ?? carrier.Type;
        carrier.SpaceCount = spaceCount ?? carrier.SpaceCount;
        carrier.StartPlace = startPlace ?? carrier.StartPlace;
        carrier.ReturnPlace = returnPlace ?? carrier.ReturnPlace;

        _dbContext.SaveChanges();
    }

}