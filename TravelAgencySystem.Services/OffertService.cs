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
        // throw new NotImplementedException();
        Offert offert = new()
        {
            Id = Guid.NewGuid(),

            HostEmployeeId = hostId,
            Date = date,
            Duration = duration,
            CarrierId = carrierId,
            AccomodationId = accomodationId
        };

        _offerts.Add(offert);
        _dbContext.SaveChanges();

        return offert.Id;
    }

    public Offert? Get(Guid id) => _offerts.Get(id);

    public IReadOnlyList<Offert> GetAll() => _offerts.Query().ToList();

    // public IReadOnlyList<Offert> Search<TKey>((DateTime min, DateTime max)? dateRange = null, Func<Offert, TKey>? keySelector = null)
    // {
    //     var list = GetAll();
        
    //     if(dateRange.HasValue)
    //         list = list.Where(e => dateRange.Value.min <= e.Date && e.Date <= dateRange.Value.max).ToList();

    //     if(keySelector is not null)
    //         list.OrderBy(keySelector);

    //     return list;
    // }

    public void Update(Guid id, Guid? hostId, DateTime? date, TimeSpan? duration, Guid? carrierId, Guid? accomodationId)
    {
        if(Get(id) is not Offert offert)
            throw new ArgumentException("Offert is not exist", nameof(offert));

        offert.HostEmployeeId = hostId ?? offert.HostEmployeeId;
        offert.Date = date ?? offert.Date;
        offert.Duration = duration ?? offert.Duration;
        offert.CarrierId = carrierId ?? offert.CarrierId;
        offert.AccomodationId = accomodationId ?? offert.AccomodationId;

        _dbContext.SaveChanges();
    }

}