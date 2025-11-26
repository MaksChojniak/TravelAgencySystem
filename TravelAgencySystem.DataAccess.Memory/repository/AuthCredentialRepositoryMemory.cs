using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class AuthCredentialRepository : IRepository<AuthCredential, Guid>
{
    public void Add(AuthCredential entity)
    {
        throw new NotImplementedException();
    }

    public AuthCredential? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<AuthCredential> Query()
    {
        throw new NotImplementedException();
    }

    public void Remove(AuthCredential entity)
    {
        throw new NotImplementedException();
    }
}