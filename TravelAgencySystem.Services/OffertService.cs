using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class OffertService : IOffertService
{
    readonly IRepository<Offert> _offerts;

    readonly IDbContext _dbContext;

    public OffertService(IRepository<Offert> offerts, IDbContext dbContext)
    {
        _offerts = offerts;
        _dbContext = dbContext;
    }


    public Guid Create(Guid hostId, DateTime date, TimeSpan duration, Guid carrierId, Guid accomodationId)
    {
        throw new NotImplementedException();
    }

    public Offert? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Offert> GetAll()
    {
        throw new NotImplementedException();
    }
}