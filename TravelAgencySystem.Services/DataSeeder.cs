using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services;

public sealed class DataSeeder : IDataSeeder
{
    readonly IAccomodationService _accomodationService;
    readonly IAuthService _clientAuthService;
    readonly IAuthService _employeeAuthService;
    readonly ICarrierService _carrierService;
    readonly IClientService _clientService;
    readonly IEmployeeService _employeeService;
    readonly IOffertService _offertService;
    readonly IReservationService _reservationService;
    readonly IRoomService _roomService;

    public DataSeeder(IAccomodationService accomodationService, IAuthService clientAuthService, IAuthService employeeAuthService, ICarrierService carrierService, 
        IClientService clientService, IEmployeeService employeeService, IOffertService offertService, IReservationService reservationService, IRoomService roomService)
    {
        _accomodationService = accomodationService;
        _clientAuthService = clientAuthService;
        _employeeAuthService = employeeAuthService;
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
        var employee4 = _employeeAuthService.CreateAccount("emp4", "pass4");
        var employee5 = _employeeAuthService.CreateAccount("emp5", "pass5");
        
        var client1 = _clientAuthService.CreateAccount("client1", "pass1");
        var client2 = _clientAuthService.CreateAccount("client2", "pass2");
        var client3 = _clientAuthService.CreateAccount("client3", "pass3");
        var client4 = _clientAuthService.CreateAccount("client4", "pass4");


        var carrier1 = _carrierService.Create("PKP IC", TypeOfTransport.Train, 120, "Warszawa", "Czestochowa", 50);
        var carrier2 = _carrierService.Create("LOT", TypeOfTransport.Plane, 200, "Wroclaw", "Warszawa", 350);
        var carrier3 = _carrierService.Create("FlixBus", TypeOfTransport.Bus, 50, "Krakow", "Gdansk", 40);
        var carrier4 = _carrierService.Create("Regional Rail", TypeOfTransport.Train, 80, "Poznan", "Szczecin", 60);


        var accomodation1 = _accomodationService.Create("Akademik Blizniak", "Czestochowa ul.akademicka 1", 1);
        var accomodation2 = _accomodationService.Create("Grand Hotel", "Gdansk ul.nieznana 15", 5);
        var accomodation3 = _accomodationService.Create("Hotel Ibis", "Warszawa ul.nadwiślańska 3", 3);
        var accomodation4 = _accomodationService.Create("Comfort Inn", "Wroclaw ul.komfortowa 7", 4);


        var room1 = _roomService.Create(accomodation1, null, 1, 129, 2, 24);
        var room2 = _roomService.Create(accomodation1, null, 2, 220, 2, 24);
        var room3 = _roomService.Create(accomodation1, null, 1, 111, 3, 20);
        var room4 = _roomService.Create(accomodation1, null, 3, 301, 2, 24);

        var room5 = _roomService.Create(accomodation2, null, 2, 210, 2, 1010);
        var room6 = _roomService.Create(accomodation2, null, 2, 212, 2, 1200);
        var room7 = _roomService.Create(accomodation2, null, 3, 320, 4, 1580);
        var room8 = _roomService.Create(accomodation2, null, 5, 555, 5, 5200);
        var room9 = _roomService.Create(accomodation2, null, 5, 519, 2, 32050);
        var room10 = _roomService.Create(accomodation2, null, 2, 202, 2, 820);

        var room11 = _roomService.Create(accomodation3, null, 3, 311, 4, 420);
        var room12 = _roomService.Create(accomodation3, null, 3, 307, 5, 550);
        var room13 = _roomService.Create(accomodation3, null, 1, 123, 2, 310);
        var room14 = _roomService.Create(accomodation3, null, 2, 219, 2, 400);

        var room15 = _roomService.Create(accomodation4, null, 3, 309, 4, 750);
        var room16 = _roomService.Create(accomodation4, null, 3, 310, 5, 810);
        var room17 = _roomService.Create(accomodation4, null, 1, 100, 2, 460);
        var room18 = _roomService.Create(accomodation4, null, 2, 236, 2, 415);


        var offert1 = _offertService.Create(employee1, "Train Offert To Czestochowa", DateTime.Now.AddDays(1), TimeSpan.FromDays(5), carrier1, accomodation1);
        var offert2 = _offertService.Create(employee3, "Train Offert To Sczecin", DateTime.Now.AddDays(2), TimeSpan.FromDays(3), carrier3, accomodation1);
        var offert3 = _offertService.Create(employee4, "Best Deal Train Offert To Szczecin", DateTime.Now.AddDays(14), TimeSpan.FromDays(2), carrier3, accomodation1);

        var offert4 = _offertService.Create(employee4, "Travel to the best Hotel", DateTime.Now.AddDays(22), TimeSpan.FromDays(7), carrier4, accomodation2);
        var offert5 = _offertService.Create(employee1, "Luxurious Rest on the beach", DateTime.Now.AddDays(1), TimeSpan.FromDays(4), carrier2, accomodation2);

        var offert6 = _offertService.Create(employee3, "Fast and Cheap to Gdansk", DateTime.Now.AddDays(2), TimeSpan.FromDays(3), carrier3, accomodation3);
        var offert7 = _offertService.Create(employee3, "Last Minute Offert to Czestochowa", DateTime.Now.AddDays(16), TimeSpan.FromDays(5), carrier1, accomodation3);

        var offert8 = _offertService.Create(employee4, "Best offert To Czestochowa", DateTime.Now.AddDays(7), TimeSpan.FromDays(5), carrier1, accomodation4);
        var offert9 = _offertService.Create(employee1, "Travel From Poznan to Szczecin", DateTime.Now.AddDays(10), TimeSpan.FromDays(4), carrier4, accomodation4);
        var offert10 = _offertService.Create(employee2, "Offert Plain to Szczecin", DateTime.Now.AddDays(3), TimeSpan.FromDays(5), carrier2, accomodation4);


        var reservation1 = _reservationService.Create(client1, offert1, 1000, new List<Guid> { room1, room2 });
        var reservation2 = _reservationService.Create(client1, offert10, 1250, new List<Guid> { room15 });
        var reservation3 = _reservationService.Create(client2, offert5, 2100, new List<Guid> { room5 });


        _employeeService.Update(employee1, "Maks", "Chojnia", "00000000000", 1500);
        _employeeService.Update(employee2, "Anna", "Nowak", "11111111111", 1600);
        _employeeService.Update(employee3, "Piotr", "Zalewski", "22222222222", 1700);
        _employeeService.Update(employee4, "Kasia", "Kowal", "33333333333", 1400);

        _clientService.Update(client1, "Jan", "Kowalski", "90010112345", "+48 600-111-222", "jan.k@example.com", "Warszawa, ul. Przykladowa 1");
        _clientService.Update(client2, "Ewa", "Nowak", "88020254321", "+48 600-333-444", "ewa.n@example.com", "Krakow, ul. Testowa 2");
        _clientService.Update(client3, "Marek", "Lewandowski", "85030398765", "+48 600-555-666", "marek.l@example.com", "Gdansk, ul. Morska 3");
        _clientService.Update(client4, "Olga", "Wroblewska", "91040411122", "+48 600-777-888", "olga.w@example.com", "Wroclaw, ul. Rynek 4");

        return new()
        {
            Accomodations = new() { accomodation1, accomodation2, accomodation3, accomodation4 },
            AuthCredentials = new() { employee1, employee2, employee3, employee4, client1, 
                                    client2, client3, client4, },
            Carriers = new() { carrier1, carrier2, carrier3, carrier4, },
            Clients = new() { client1, client2, client3, client4},
            Employees = new() { employee1, employee2, employee3, employee4 },
            Offerts = new() { offert1, offert2, offert3, offert4, offert5, offert6, offert7, offert8, offert9, offert10 },
            Reservations = new() { reservation1, reservation2, reservation3 },
            Rooms = new() { room1, room2, room3, room4, room5, room6, room7, room8, room9, room10, room11, room12,
                            room13, room14, room15, room16, room17, room18 }
        };
    }
}