using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class OffertService : IOffertService
{
    readonly IRepository<Offert> _offerts;
    readonly IRepository<Employee> _employees;
    readonly IRepository<Reservation> _reservations;
    readonly IRepository<Carrier> _carriers;
    readonly IRepository<Accomodation> _accomodations;
    readonly IRepository<Room> _rooms;

    readonly IDbContext _dbContext;

    public OffertService(IRepository<Offert> offerts, IRepository<Employee> employees, IRepository<Reservation> reservations, IRepository<Carrier> carriers, IRepository<Accomodation> accomodations, IRepository<Room> rooms, IDbContext dbContext)
    {
        _offerts = offerts;
        _employees = employees;
        _reservations = reservations;
        _carriers = carriers;
        _accomodations = accomodations;
        _rooms = rooms;
        _dbContext = dbContext;
    }


    public Guid Create(Guid hostId, string title, DateTime date, TimeSpan duration, Guid carrierId, Guid accomodationId)
    {
        if(_employees.Get(hostId) is null)
            throw new ArgumentException("Employee not exist", nameof(hostId));

        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is empty", nameof(title));

        if(date.Date < DateTime.Now.Date)
            throw new ArgumentException("Date must be in future", nameof(date));

        if(duration.TotalDays <= 0)
            throw new ArgumentException("Duration greater than 0 days", nameof(duration));

        if(_carriers.Get(carrierId) is null)
            throw new ArgumentException("Carrier not exist", nameof(carrierId));

        if(_accomodations.Get(accomodationId) is null)
            throw new ArgumentException("Accomodation not exist", nameof(accomodationId));

        if(_offerts.Query().Any(e => e.Title == title && e.Date == date && e.Duration == duration &&  e.CarrierId == carrierId && e.AccomodationId == accomodationId))
            throw new ArgumentException("Offert already exist");

        Offert offert = new()
        {
            Id = Guid.NewGuid(),

            Title = title,
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

    public IReadOnlyList<Offert> Search(DateTime? min, DateTime? max)
    {
        var list = GetAll();
        
        if(min.HasValue)
            list = list.Where(e => min <= e.Date).ToList();

        if(max.HasValue)
            list = list.Where(e => e.Date <= max).ToList();

        return list;
    }

    public void Remove(Guid id)
    {
        if(Get(id) is not Offert offert)
            throw new ArgumentException("Offert not exist", nameof(offert));

        _offerts.Remove(offert);
        _dbContext.SaveChanges();
    }

    public int FreeSpaces(Guid id)
    {
        if(Get(id) is not Offert offert)
            throw new ArgumentException("Offert not exist", nameof(offert));

        int freeRoomSpaces = _rooms.Query().Where(r => r.AccomodationId == offert.AccomodationId && r.IsAvailable).Sum(r => r.SpaceCount);
        int freeCarrierSpaces = _carriers.Get(offert.CarrierId).SpaceCount - _reservations.Query().Where(r => _offerts.Get(r.OffertId).CarrierId == offert.CarrierId).Sum(r => r.NumberOfPeople);

        int freeSpaces = Math.Min(freeRoomSpaces, freeCarrierSpaces);
        if (freeSpaces < 0)
            return 0;

        return freeSpaces;
    }
}