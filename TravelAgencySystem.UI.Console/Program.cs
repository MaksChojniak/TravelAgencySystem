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
IAuthService<Client> clientAuthService = new AuthService<Client>(authCredentialRepository, clientRepository, db);
IAuthService<Employee> employeeAuthService = new AuthService<Employee>(authCredentialRepository, employeeRepository, db);
IBookingService bookingService = new BookingService(db);
ICarrierService carrierService = new CarrierService(carrierRepository, db);
IClientService clientService = new ClientService(clientRepository, db);
IEmployeeService employeeService = new EmployeeService(employeeRepository, db);
IOffertService offertService = new OffertService(offertRepository, db);
IReservationService reservationService = new ReservationService(reservationRepository, db);
IRoomService roomService = new RoomService(roomRepository, db);

PageManager.Pages = new()
{
    ["menu"] = new MenuPage(),
   
    ["employee-auth"] = new EmployeeAuth(),
    ["employee-login"] = new EmployeeLogin(employeeAuthService),
    ["employee-register"] = new EmployeeRegister(employeeAuthService),
    ["employee-set-register-data"] = new SetEmployeeData(employeeService),
    ["employee-home"] = new EmployeeHome(),

    ["client-auth"] = new ClientAuth(),
    ["client-login"] = new ClientLogin(clientAuthService),
    ["client-register"] = new ClientRegister(clientAuthService),
    ["client-set-register-data"] = new SetClientData(clientService),
    ["client-home"] = new ClientHome(),
    
    ["employee-offerts"] = new EmployeeOffertList(offertService),

    ["client-offerts"] = new ClientOffertList(offertService, accomodationService, roomService, carrierService),
    // ["employee-register"] = new MenuPage(),
    // ["Menu"] = new MenuPage(),

};

Session.PersonId = employeeAuthService.CreateAccount("m", "m").Id;
employeeService.Update(Session.PersonId, "Maks", "Chojnia", "000", 1500);

var carrier1 = carrierService.Create("PKP IC", TypeOfTransport.Train, 100, "Warszawa", "Czestochowa", 50);
var carrier2 = carrierService.Create("LOT", TypeOfTransport.Plane, 100, "Wroclaw", "Warszawa", 500);

var accomodation1 = accomodationService.Create("Akademik Blizniak", "Czestochowa ul.akademicka 1", 1);
var accomodation2 = accomodationService.Create("Grand Hotel", "Gdansk ul.nieznana 15", 5);
var accomodation3 = accomodationService.Create("Most Ponatowski", "Warszawa ul....", 1);

roomService.Create(accomodation1, Guid.Empty, 1, 129, 2, 501);
roomService.Create(accomodation1, Guid.Empty, 2, 220, 2, 502);

roomService.Create(accomodation2, Guid.Empty, 3, 31, 4, 5520);
roomService.Create(accomodation2, Guid.Empty, 3, 30, 5, 5200);

offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(5), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(1), carrier1, accomodation3);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(2), carrier1, accomodation2);

offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(3), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(4), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(6), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(7), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(8), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(9), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(9), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(9), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(9), carrier1, accomodation1);
offertService.Create(Session.PersonId, DateTime.Now, TimeSpan.FromDays(9), carrier1, accomodation1);

Session.PersonId = clientAuthService.CreateAccount("maks", "maks").Id;
clientService.Update(Session.PersonId, "Maks", "Chojnia", "000", "+48 536-597-300", "maks@gmail", "wiatrakkebab");

PageManager.LoadPage("menu");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Login Error ----");
// Console.WriteLine("Wrong Login or Password!");
// Console.WriteLine("1) Login");
// Console.WriteLine("2) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Set Personal Data ----");
// Console.Write("First Name: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Last Name: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Pesel: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Phone Number: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Email: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Address: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Home ----");
// Console.WriteLine("1) All Offerts");
// Console.WriteLine("2) Reservations");
// Console.WriteLine("3) Profile");
// Console.WriteLine("4) Logout");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- List of Offerts ----");
// Console.WriteLine("0) Set Filters");
// Console.WriteLine("Filters: None");
// Console.WriteLine("Offerts: "); // or empty
// Console.WriteLine("  1) Offert 1");
// Console.WriteLine("2) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Offert 1 ----");
// Console.WriteLine("Date: ");
// Console.WriteLine("Duration: ");
// Console.WriteLine("Carrier Info: ");
// Console.WriteLine("  -Name: ");
// Console.WriteLine("  -Type: ");
// Console.WriteLine("  -Free Space: ");
// Console.WriteLine("  -Start Place: ");
// Console.WriteLine("  -Return Place: ");
// Console.WriteLine("  -Price:  / person");
// Console.WriteLine("Accomodation Info: ");
// Console.WriteLine("  -Name: ");
// Console.WriteLine("  -Address: ");
// Console.WriteLine("  -Stars: ");
// Console.WriteLine("  -Free Rooms: "); // or empty
// Console.WriteLine("    -Number 1: : Floor: , Space Count: , Price: ");
// Console.WriteLine("    -Number 2: : Floor: , Space Count: , Price: ");
// Console.WriteLine("1) Reserve"); // if rooms and carrier avaiable "Sold Out"
// Console.WriteLine("2) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Offert Reservation ----");
// Console.WriteLine("Date: ");
// Console.WriteLine("Duration: ");
// Console.WriteLine("Carrier Name: , Price: ");
// Console.WriteLine("Accomodation Name: ");
// Console.WriteLine("Free Rooms: ");
// Console.WriteLine("  -Number 1: Floor: , Space Count: , Price: ");
// Console.WriteLine("  -Number 2: Floor: , Space Count: , Price: ");
// Console.Write("Selected Rooms (1,2,..):");
// _ = Console.ReadLine()??string.Empty; // can't be empty
// Console.WriteLine("Total price: ");
// Console.WriteLine("1) Reserve");
// Console.WriteLine("2) Reserve and Pay");
// Console.WriteLine("3) Cancel");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Reserved Offerts ----");
// Console.WriteLine("Reservations:");
// Console.WriteLine("1) Reservation 1");
// Console.WriteLine("2) Reservation 2");
// Console.WriteLine("3) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Reservation 1 ----");
// Console.WriteLine("Status: ");
// Console.WriteLine("Total Price: ");
// Console.WriteLine("Date: ");
// Console.WriteLine("Duration: ");
// Console.WriteLine("Carrier Name: ");
// Console.WriteLine("Accomodation Name: ");
// Console.WriteLine("Rooms: ");
// Console.WriteLine("  -Number 1: Floor: , Space Count: ");
// Console.WriteLine("  -Number 2: Floor: , Space Count: ");
// Console.WriteLine("1) Pay"); // if not payed;
// Console.WriteLine("2) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Profile ----");
// Console.WriteLine("First Name: ");
// Console.WriteLine("Last Name: ");
// Console.WriteLine("Pesel: ");
// Console.WriteLine("Phone Number: ");
// Console.WriteLine("Email: ");
// Console.WriteLine("Address: ");
// Console.WriteLine("1) Update Data");
// Console.WriteLine("2) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Update Profile ----");
// Console.Write("First Name: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Last Name: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Pesel: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Phone Number: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Email: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Address: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Home ----");
// Console.WriteLine("1) Hosted Offerts");
// Console.WriteLine("2) Accomodations");
// Console.WriteLine("3) Carriers");
// Console.WriteLine("4) Profile");
// Console.WriteLine("5) Logout");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Offerts ----");
// Console.WriteLine("  1) Offert 1");
// Console.WriteLine("  2) Offert 2");
// Console.WriteLine("3) Create new Offert");
// Console.WriteLine("4) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Offert 1 ----");
// Console.WriteLine("Date: ");
// Console.WriteLine("Duration: ");
// Console.WriteLine("Carrier Name: , Price: ");
// Console.WriteLine("Accomodation Name: ");
// Console.WriteLine("Rooms: ");
// Console.WriteLine("  -Number: 1, Price: ");
// Console.WriteLine("  -Number: 2, Price: ");
// Console.WriteLine("1) Update");
// Console.WriteLine("2) Remove");
// Console.WriteLine("3) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Update Offert ----");
// Console.Write("Date: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Duration: ");
// _ = Console.ReadLine()??string.Empty;
// Console.WriteLine("Avaiable Carriers: ");
// Console.WriteLine("  1) Name: Price: ");
// Console.WriteLine("  2) Name: Price: ");
// Console.Write("Carrier: ");
// _ = Console.ReadLine()??string.Empty;
// Console.WriteLine("Avaiable Accomodations: ");
// Console.WriteLine("  1) Name: ");
// Console.WriteLine("  2) Name: ");
// Console.Write("Accomodation: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Offert Creator ----");
// Console.Write("Date: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Duration: ");
// _ = Console.ReadLine()??string.Empty;
// Console.WriteLine("Avaiable Carriers: ");
// Console.WriteLine("  1) Name: Price: ");
// Console.WriteLine("  2) Name: Price: ");
// Console.Write("Carrier: ");
// _ = Console.ReadLine()??string.Empty;
// Console.WriteLine("Avaiable Accomodations: ");
// Console.WriteLine("  1) Name: ");
// Console.WriteLine("  2) Name: ");
// Console.Write("Accomodation: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Accomodations ----");
// Console.WriteLine("  1) Accomodation 1");
// Console.WriteLine("  2) Accomodation 2");
// Console.WriteLine("3) Create new Accomodation");
// Console.WriteLine("4) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Accomodation 1 ----");
// Console.WriteLine("Name: ");
// Console.WriteLine("Address: ");
// Console.WriteLine("Stars: ");
// Console.WriteLine("Rooms: ");
// Console.WriteLine("  1) Number: 1, Price: ");
// Console.WriteLine("  2) Number: 2, Price: ");
// Console.WriteLine("3) Create new Room");
// Console.WriteLine("4) Update");
// Console.WriteLine("5) Remove");
// Console.WriteLine("6) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Room 1 ----");
// Console.WriteLine("Number: ");
// Console.WriteLine("Floor: ");
// Console.WriteLine("Space Count: ");
// Console.WriteLine("Price:  ");
// Console.WriteLine("2) Update");
// Console.WriteLine("3) Remove");
// Console.WriteLine("4) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Update Room ----");
// Console.Write("Number: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Floor: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Space Count: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Price: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Room Creator ----");
// Console.Write("Number: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Floor: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Space Count: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Price: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Update Accomodation ----");
// Console.Write("Name: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Address: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Stars: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Accomodation Creator ----");
// Console.Write("Name: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Address: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Stars: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Carriers ----");
// Console.WriteLine("  1) Carrier 1");
// Console.WriteLine("  2) Carrier 2");
// Console.WriteLine("3) Create new Carrier");
// Console.WriteLine("4) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Carrier 1 ----");
// Console.WriteLine("Name: ");
// Console.WriteLine("Type: ");
// Console.WriteLine("Space Count: ");
// Console.WriteLine("Start Place: ");
// Console.WriteLine("Return Place: ");
// Console.WriteLine("Price: ");
// Console.WriteLine("1) Update");
// Console.WriteLine("2) Remove");
// Console.WriteLine("3) Back");

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Update Carrier ----");
// Console.Write("Name: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Type: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Space Count: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Start Place: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Return Place: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Price: ");
// _ = Console.ReadLine()??string.Empty;

// Console.ReadKey();
// Console.Clear();
// Console.WriteLine("---- Carrier Creator ----");
// Console.Write("Name: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Type: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Space Count: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Start Place: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Return Place: ");
// _ = Console.ReadLine()??string.Empty;
// Console.Write("Price: ");
// _ = Console.ReadLine()??string.Empty;

