using TravelAgencySystem.DataAccess;
using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Services;
using TravelAgencySystem.DataModel;


MemoryDbContext db = new MemoryDbContext(); 

IRepository<Accomodation> accomodationRepository = new AccomodationRepository(db);
IRepository<AuthCredential> authCredentialRepository = new AuthCredentialRepository(db);
IRepository<Carrier> carrierRepository = new CarrierRepository(db);
IRepository<Client> clientRepository = new ClientRepository(db);
IRepository<Employee> employeeRepository = new EmployeeRepository(db);
IRepository<Offert> offertRepository = new OffertRepository(db);
IRepository<Reservation> reservationRepository = new ReservationRepository(db);
IRepository<Room> roomRepository = new RoomRepository(db);

IAccomodationService accomodationService = new AccomodationService(accomodationRepository, db);
IAuthService<Client> clientAuthService = new AuthService<Client>(authCredentialRepository, clientRepository, db);
IAuthService<Employee> employeeAuthService = new AuthService<Employee>(authCredentialRepository, employeeRepository, db);
IBookingService bookingService = new BookingService(db);
ICarrierService carrierService = new CarrierService(carrierRepository, db);
IClientService clientService = new ClientService(clientRepository, db);
IEmployeeService employeeService = new EmployeeService(employeeRepository, db);
IOffertService offertService = new OffertService(offertRepository, db);
IReservationService reservationService = new ReservationService(reservationRepository, db);
IRoomService roomService = new RoomService(roomRepository, db);


Console.WriteLine("Hello World 2");