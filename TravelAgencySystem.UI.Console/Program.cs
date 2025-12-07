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

IAccomodationService accomodationService = new AccomodationService(accomodationRepository, roomRepository, db);
IAuthService clientAuthService = new AuthService<Client>(authCredentialRepository, clientRepository, db);
IAuthService employeeAuthService = new AuthService<Employee>(authCredentialRepository, employeeRepository, db);
ICarrierService carrierService = new CarrierService(carrierRepository, db);
IClientService clientService = new ClientService(clientRepository, reservationRepository, db);
IEmployeeService employeeService = new EmployeeService(employeeRepository, offertRepository, db);
IOffertService offertService = new OffertService(offertRepository, employeeRepository, reservationRepository, carrierRepository, accomodationRepository, roomRepository, db);
IReservationService reservationService = new ReservationService(reservationRepository, offertRepository, clientRepository, roomRepository, db);
IRoomService roomService = new RoomService(roomRepository, accomodationRepository, reservationRepository, db);

DataSeeder seeder = new(accomodationService, clientAuthService, employeeAuthService, carrierService, clientService, employeeService,
                        offertService, reservationService, roomService);
seeder.Seed();

PageManager.Pages = new()
{
    ["menu"] = new MenuPage(),
   
    ["employee-auth"] = new EmployeeAuth(employeeAuthService),
    ["employee-set-register-data"] = new SetEmployeeData(employeeService),
    ["employee-home"] = new EmployeeHome(),

    ["client-auth"] = new ClientAuth(clientAuthService),
    ["client-set-register-data"] = new SetClientData(clientService),
    ["client-home"] = new ClientHome(),
    
    ["employee-offerts"] = new EmployeeOffertList(offertService, carrierService, accomodationService, roomService, employeeService),
    ["employee-accomodations"] = new EmployeeAccomodations(accomodationService, roomService),
    ["employee-carriers"] = new EmployeeCarriers(carrierService),
    ["employee-profile"] = new ClientHome(),

    ["client-offerts"] = new ClientOffertList(reservationService, offertService, accomodationService, roomService, carrierService),
    ["client-reservations"] = new ClientReservationList(reservationService, clientService, offertService, accomodationService, roomService, carrierService),

};

PageManager.LoadPage("menu");