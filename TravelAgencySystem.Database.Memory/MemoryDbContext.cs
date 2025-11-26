using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Database.Memory;  
  
public class MemoryDbContext : IDbContext
{
    public List<Accomodation> Accomodations { get; } = new();
    public List<AuthCredential> AuthCredentials { get; } = new();
    public List<Carrier> Carriers { get; } = new();
    public List<Client> Clients { get; } = new();
    public List<Employee> Employees { get; } = new();
    public List<Offert> Offerts { get; } = new();
    public List<Reservation> Reservations { get; } = new();
    public List<Room> Rooms { get; } = new();

    public int SaveChanges() => 0;
}