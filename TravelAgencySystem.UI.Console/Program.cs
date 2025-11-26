using TravelAgencySystem.DataAccess;
using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.Database.Memory;
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

Console.WriteLine("Hello World 2");