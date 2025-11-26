using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class AuthCredentialRepositoryMemory : RepositoryMemory<AuthCredential>
{
    public AuthCredentialRepositoryMemory(MemoryDbContext dbContext) : base(dbContext) { }

    public override  IQueryable<AuthCredential> Query() => _dbContext.AuthCredentials.AsQueryable();

    public override void Add(AuthCredential entity) => _dbContext.AuthCredentials.Add(entity);

    public override void Remove(AuthCredential entity) => _dbContext.AuthCredentials.Remove(entity);

    public override AuthCredential? Get(Guid id) => _dbContext.AuthCredentials.FirstOrDefault(e => e.PersonId == id);
}