using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class CarrierRepository : IRepository<Carrier, Guid>
{
    public void Add(Carrier entity)
    {
        throw new NotImplementedException();
    }

    public Carrier? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Carrier> Query()
    {
        throw new NotImplementedException();
    }

    public void Remove(Carrier entity)
    {
        throw new NotImplementedException();
    }
}
