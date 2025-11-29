using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services;

public sealed class DataSeeder : IDataSeeder
{
    readonly IAccomodationService _accomodationService;
    readonly IAuthService<Client> _clientAuthService;
    readonly IAuthService<Employee> _employeeAuthService;
    readonly IBookingService _bookingService;
    readonly ICarrierService _carrierService;
    readonly IClientService _clientService;
    readonly IEmployeeService _employeeService;
    readonly IOffertService _offertService;
    readonly IReservationService _reservationService;
    readonly IRoomService _roomService;

    public DataSeeder(IAccomodationService accomodationService, IAuthService<Client> clientAuthService, IAuthService<Employee> employeeAuthService,
        IBookingService bookingService, ICarrierService carrierService, IClientService clientService, IEmployeeService employeeService, 
        IOffertService offertService, IReservationService reservationService, IRoomService roomService)
    {
        _accomodationService = accomodationService;
        _clientAuthService = clientAuthService;
        _employeeAuthService = employeeAuthService;
        _bookingService = bookingService;
        _carrierService = carrierService;
        _clientService = clientService;
        _employeeService = employeeService;
        _offertService = offertService;
        _reservationService = reservationService;
        _roomService = roomService;
    }

    public SeedResult Seed()
    {

        var employee1 = _employeeAuthService.CreateAccount("emp1", "pass1");
        var employee2 = _employeeAuthService.CreateAccount("emp2", "pass2");
        var employee3 = _employeeAuthService.CreateAccount("emp3", "pass3");
        var employee4 = _employeeAuthService.CreateAccount("emp4", "pass3");
        
        var client1 = _clientAuthService.CreateAccount("client1", "pass1");
        var client2 = _clientAuthService.CreateAccount("client2", "pass2");
        var client3 = _clientAuthService.CreateAccount("client3", "pass3");
        var client4 = _clientAuthService.CreateAccount("client4", "pass3");


        var carrier1 = _carrierService.Create("PKP IC", TypeOfTransport.Train, 120, "Warszawa", "Czestochowa", 50);
        var carrier2 = _carrierService.Create("LOT", TypeOfTransport.Plane, 200, "Wroclaw", "Warszawa", 350);
        var carrier3 = _carrierService.Create("FlixBus", TypeOfTransport.Bus, 50, "Krakow", "Gdansk", 40);
        var carrier4 = _carrierService.Create("Regional Rail", TypeOfTransport.Train, 80, "Poznan", "Szczecin", 60);


        var accomodation1 = _accomodationService.Create("Akademik Blizniak", "Czestochowa ul.akademicka 1", 1);
        var accomodation2 = _accomodationService.Create("Grand Hotel", "Gdansk ul.nieznana 15", 5);
        var accomodation3 = _accomodationService.Create("Hotel Ibis", "Warszawa ul.nadwiślańska 3", 3);
        var accomodation4 = _accomodationService.Create("Comfort Inn", "Wroclaw ul.komfortowa 7", 4);


        var room1 = _roomService.Create(accomodation1, Guid.Empty, 1, 129, 2, 24);
        var room2 = _roomService.Create(accomodation1, Guid.Empty, 2, 220, 2, 24);
        var room3 = _roomService.Create(accomodation1, Guid.Empty, 1, 111, 3, 20);
        var room4 = _roomService.Create(accomodation1, Guid.Empty, 3, 301, 2, 24);

        var room5 = _roomService.Create(accomodation2, Guid.Empty, 2, 210, 2, 1010);
        var room6 = _roomService.Create(accomodation2, Guid.Empty, 2, 212, 2, 1200);
        var room7 = _roomService.Create(accomodation2, Guid.Empty, 3, 320, 4, 1580);
        var room8 = _roomService.Create(accomodation2, Guid.Empty, 5, 555, 5, 5200);
        var room9 = _roomService.Create(accomodation2, Guid.Empty, 5, 519, 2, 32050);
        var room10 = _roomService.Create(accomodation2, Guid.Empty, 2, 202, 2, 820);

        var room11 = _roomService.Create(accomodation3, Guid.Empty, 3, 311, 4, 420);
        var room12 = _roomService.Create(accomodation3, Guid.Empty, 3, 307, 5, 550);
        var room13 = _roomService.Create(accomodation3, Guid.Empty, 1, 123, 2, 310);
        var room14 = _roomService.Create(accomodation3, Guid.Empty, 2, 219, 2, 400);

        var room15 = _roomService.Create(accomodation4, Guid.Empty, 3, 309, 4, 750);
        var room16 = _roomService.Create(accomodation4, Guid.Empty, 3, 310, 5, 810);
        var room17 = _roomService.Create(accomodation4, Guid.Empty, 1, 100, 2, 460);
        var room18 = _roomService.Create(accomodation4, Guid.Empty, 2, 236, 2, 415);


        var offert1 = _offertService.Create(employee1.Id, DateTime.Now.AddDays(1), TimeSpan.FromDays(5), carrier1, accomodation1);
        var offert2 = _offertService.Create(employee3.Id, DateTime.Now.AddDays(2), TimeSpan.FromDays(3), carrier3, accomodation1);
        var offert3 = _offertService.Create(employee4.Id, DateTime.Now.AddDays(14), TimeSpan.FromDays(2), carrier3, accomodation1);

        var offert4 = _offertService.Create(employee4.Id, DateTime.Now.AddDays(22), TimeSpan.FromDays(7), carrier4, accomodation2);
        var offert5 = _offertService.Create(employee1.Id, DateTime.Now.AddDays(1), TimeSpan.FromDays(4), carrier2, accomodation2);

        var offert6 = _offertService.Create(employee3.Id, DateTime.Now.AddDays(2), TimeSpan.FromDays(3), carrier3, accomodation3);
        var offert7 = _offertService.Create(employee3.Id, DateTime.Now.AddDays(16), TimeSpan.FromDays(5), carrier1, accomodation3);

        var offert8 = _offertService.Create(employee4.Id, DateTime.Now.AddDays(7), TimeSpan.FromDays(5), carrier1, accomodation4);
        var offert9 = _offertService.Create(employee1.Id, DateTime.Now.AddDays(10), TimeSpan.FromDays(4), carrier4, accomodation4);
        var offert10 = _offertService.Create(employee2.Id, DateTime.Now.AddDays(3), TimeSpan.FromDays(5), carrier2, accomodation4);


        // var reservation1 = _reservationService.Create()


        _employeeService.Update(employee1.Id, "Maks", "Chojnia", "00000000000", 1500);
        _employeeService.Update(employee2.Id, "Anna", "Nowak", "11111111111", 1600);
        _employeeService.Update(employee3.Id, "Piotr", "Zalewski", "22222222222", 1700);
        _employeeService.Update(employee4.Id, "Kasia", "Kowal", "33333333333", 1400);

        _clientService.Update(client1.Id, "Jan", "Kowalski", "90010112345", "+48 600-111-222", "jan.k@example.com", "Warszawa, ul. Przykladowa 1");
        _clientService.Update(client2.Id, "Ewa", "Nowak", "88020254321", "+48 600-333-444", "ewa.n@example.com", "Krakow, ul. Testowa 2");
        _clientService.Update(client3.Id, "Marek", "Lewandowski", "85030398765", "+48 600-555-666", "marek.l@example.com", "Gdansk, ul. Morska 3");
        _clientService.Update(client4.Id, "Olga", "Wroblewska", "91040411122", "+48 600-777-888", "olga.w@example.com", "Wroclaw, ul. Rynek 4");

        return new()
        {
            Accomodations = new() { accomodation1, accomodation2, accomodation3, accomodation4 },
            AuthCredentials = new() { employee1.Id, employee2.Id, employee3.Id, employee4.Id, client1.Id, 
                                    client2.Id, client3.Id, client4.Id, },
            Carriers = new() { carrier1, carrier2, carrier3, carrier4, },
            Clients = new() { client1.Id, client2.Id, client3.Id, client4.Id},
            Employees = new() { employee1.Id, employee2.Id, employee3.Id, employee4.Id },
            Offerts = new() { offert1, offert2, offert3, offert4, offert5, offert6, offert7, offert8, offert9, offert10 },
            // Reservations = new() {},
            Rooms = new() { room1, room2, room3, room4, room5, room6, room7, room8, room9, room10, room11, room12,
                            room13, room14, room15, room16, room17, room18 }
        };
    }
}