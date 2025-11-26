using TravelAgencySystem.DataAccess;
using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;


MemoryDbContext db = new MemoryDbContext(); 

IRepository<Accomodation> accomodationRepository = new AccomodationRepositoryMemory(db);
IRepository<AuthCredential> authCredentialRepository = new AuthCredentialRepositoryMemory(db);
IRepository<Carrier> carrierRepository = new CarrierRepositoryMemory(db);
IRepository<Client> clientRepository = new ClientRepositoryMemory(db);
IRepository<Employee> employeeRepository = new EmployeeRepositoryMemory(db);
IRepository<Offert> offertRepository = new OffertRepositoryMemory(db);
IRepository<Reservation> reservationRepository = new ReservationRepositoryMemory(db);
IRepository<Room> roomRepository = new RoomRepositoryMemory(db);

Console.WriteLine("Hello World 2");