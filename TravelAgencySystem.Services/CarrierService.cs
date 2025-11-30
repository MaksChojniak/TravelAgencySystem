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

    public Guid Create(string name, TypeOfTransport type, int spaceCount, string startPlace, string returnPlace, double price)
    {
        if(string.IsNullOrEmpty(name))
            throw new ArgumentException("Name is required", nameof(name));

        if(spaceCount <= 0)
            throw new ArgumentException("Space Count must be greater than 0", nameof(name));
        
        if(string.IsNullOrEmpty(startPlace))
            throw new ArgumentException("Name is required", nameof(name));

        if(string.IsNullOrEmpty(returnPlace))
            throw new ArgumentException("Name is required", nameof(name));

        if(price <= 0)
            throw new ArgumentException("Price must be greater than 0", nameof(price));

        if(_carriers.Query().Any(c => c.Name == name && c.StartPlace == startPlace && c.ReturnPlace == returnPlace))
            throw new ArgumentException("That Carrier exist");

        Carrier carrier = new()
        {
            Id = Guid.NewGuid(),

            Name = name,
            Type = type,
            SpaceCount = spaceCount,
            StartPlace = startPlace,
            ReturnPlace = returnPlace,
            Price = price
        };

        _carriers.Add(carrier);
        _dbContext.SaveChanges();

        return carrier.Id;
    }

    public Carrier? Get(Guid id) => _carriers.Get(id);

    public IReadOnlyList<Carrier> GetAll() => _carriers.Query().ToList();

    public void Update(Guid id, double? price)
    {
        if(Get(id) is not Carrier carrier)
            throw new ArgumentException("Carrier not exist", nameof(carrier));

        if(price <= 0)
            throw new ArgumentException("Price must be greater than 0", nameof(price));

        carrier.Price = price ?? carrier.Price;
        _dbContext.SaveChanges();
    }

    public void Remove(Guid id)
    {
        if(Get(id) is not Carrier carrier)
            throw new ArgumentException("Carrier not exist", nameof(carrier));

        _carriers.Remove(carrier);
        _dbContext.SaveChanges();
    }
}