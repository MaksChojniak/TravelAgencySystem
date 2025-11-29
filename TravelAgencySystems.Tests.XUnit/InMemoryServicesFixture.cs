using TravelAgencySystem.DataAccess;
using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Services;

namespace TravelAgencySystem.Tests.XUnit;

public class InMemoryServicesFixture
{
    public IAccomodationService AccomodationService { get; set; }
    public IAuthService<Client> ClientAuthService { get; set; }
    public IAuthService<Employee> EmployeeAuthService { get; set; }
    public IBookingService BookingService { get; set; }
    public ICarrierService CarrierService { get; set; }
    public IClientService ClientService { get; set; }
    public IEmployeeService EmployeeService { get; set; }
    public IOffertService OffertService { get; set; }
    public IReservationService ReservationService { get; set; }
    public IRoomService RoomService { get; set; }

    public SeedResult Seed { get; set; }

    readonly IDataSeeder _seeder;

    public InMemoryServicesFixture()
    {
        MemoryDbContext db = new MemoryDbContext();

        IRepository<Accomodation> accomodationRepository = new AccomodationRepository(db);
        IRepository<AuthCredential> authCredentialRepository = new AuthCredentialRepository(db);
        IRepository<Carrier> carrierRepository = new CarrierRepository(db);
        IRepository<Client> clientRepository = new ClientRepository(db);
        IRepository<Employee> employeeRepository = new EmployeeRepository(db);
        IRepository<Offert> offertRepository = new OffertRepository(db);
        IRepository<Reservation> reservationRepository = new ReservationRepository(db);
        IRepository<Room> roomRepository = new RoomRepository(db);

        AccomodationService = new AccomodationService(accomodationRepository, roomRepository, db);
        ClientAuthService = new AuthService<Client>(authCredentialRepository, clientRepository, db);
        EmployeeAuthService = new AuthService<Employee>(authCredentialRepository, employeeRepository, db);
        BookingService = new BookingService(db);
        CarrierService = new CarrierService(carrierRepository, db);
        ClientService = new ClientService(clientRepository, db);
        EmployeeService = new EmployeeService(employeeRepository, db);
        OffertService = new OffertService(offertRepository, db);
        ReservationService = new ReservationService(reservationRepository, db);
        RoomService = new RoomService(roomRepository, db);
    
        _seeder = new DataSeeder(AccomodationService, ClientAuthService, EmployeeAuthService, BookingService, CarrierService, ClientService, EmployeeService,
                        OffertService, ReservationService, RoomService);
        Seed = _seeder.Seed();
    }
}