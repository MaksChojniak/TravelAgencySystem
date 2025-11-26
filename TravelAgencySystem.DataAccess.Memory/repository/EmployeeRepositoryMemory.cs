using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class EmployeeRepository : IRepository<Accomodation, Guid>
{
    public void Add(Accomodation entity)
    {
        throw new NotImplementedException();
    }

    public Accomodation? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Accomodation> Query()
    {
        throw new NotImplementedException();
    }

    public void Remove(Accomodation entity)
    {
        throw new NotImplementedException();
    }
}