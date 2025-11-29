namespace TravelAgencySystem.Services.Abstractions;

public interface IDataSeeder
{
    public SeedResult Seed();
}

public readonly struct SeedResult
{
    public List<Guid> Accomodations { get; init; }
    public List<Guid> AuthCredentials { get; init; }
    public List<Guid> Carriers { get; init; }
    public List<Guid> Clients { get; init; }
    public List<Guid> Employees { get; init; }
    public List<Guid> Offerts { get; init; }
    public List<Guid> Reservations { get; init; }
    public List<Guid> Rooms { get; init; }
}