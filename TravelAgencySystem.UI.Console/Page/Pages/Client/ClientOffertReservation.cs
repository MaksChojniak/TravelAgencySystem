using System.Security;
using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class ClientOffertReservation : PageBase
{
    readonly IReservationService _reservationService;
    readonly IOffertService _offertService;
    readonly IAccomodationService _accomodationService;
    readonly ICarrierService _carrierService;

    Offert _offert;
    Accomodation _accomodation;
    IList<Room> _rooms;
    Carrier _carrier;



    protected override string Title 
    { 
        get => "Offert Details";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>() {};
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new TextLabel($"Name: {_offert.Title}"),
            new TextLabel($"Date: {_offert.Date.ToShortDateString()}"),
            new TextLabel($"Duration: {_offert.Duration.TotalDays} Days"),
            new TextLabel($"Carrier: "),
            new TextLabel($"  -Name: {_carrier.Name} ({_carrier.Type})"),
            new TextLabel($"  -Free Space: {_offertService.FreeSpaces(_offert.Id)}"),
            new TextLabel($"  -Start Place - Return Place: {_carrier.StartPlace} -> {_carrier.ReturnPlace}"),
            new TextLabel($"  -Price: {_carrier.Price}PLN / person"),
            new TextLabel($"Accomodation: "),
            new TextLabel($"  -Name: {_accomodation.Name} {stars(_accomodation.Stars)}"),
            new TextLabel($"  -Address: {_accomodation.Address}"),
            new TextLabel($"  -Free Rooms: "),
            new ListView<TextLabel>(GetFreeRoomsAsLabels()),
        };
    }

    public ClientOffertReservation(Guid offertId,IReservationService reservationService, IOffertService offertService, IAccomodationService accomodationService,
        ICarrierService carrierService)
    {
        _reservationService = reservationService;
        _offertService = offertService;
        _accomodationService = accomodationService;
        _carrierService = carrierService;
    
        _offert = _offertService.Get(offertId);
        _accomodation = _accomodationService.Get(_offert.AccomodationId);
        _carrier = _carrierService.Get(_offert.CarrierId);
    }

    List<TextLabel> GetFreeRoomsAsLabels()
    {
        List<TextLabel> list = _accomodationService.GetAvaiableRooms(_offert.AccomodationId)
        .Select( (room, i) => new TextLabel($"    - {i+1}. Room {room.Number}, Floor {room.Floor}  Space Count {room.SpaceCount}  Price: {room.Price}PLN"))
        .ToList(); 

        if(list.Count <= 0)
            list = new() {new TextLabel("None of the Rooms are Avaiable") };

        return list;
    }

    string stars(int count) => new string('*', count).NormalizeTextSize(5);

    protected override void Show()
    {
        base.Show();

        List<Room> rooms = _accomodationService.GetAvaiableRooms(_accomodation.Id).SelectManyFromList();

        Console.WriteLine();
        Console.WriteLine($"Carrier Price: {rooms.Sum(r => r.SpaceCount)} * {_carrier.Price}PLN");
        Console.WriteLine($"Accomodation Price {string.Join(" + ", rooms.Select(r => $"{r.Price}PLN"))}");
        double totalPrice = (_carrier.Price * rooms.Sum(r => r.SpaceCount)) + rooms.Sum(r => r.Price);
        Console.WriteLine($"=== Total price: {totalPrice}PLN ===");

        Console.WriteLine();
        Console.Write("Reserve? (Yes/No): ");
        string input = (Console.ReadLine()??string.Empty).ToLower();
        if(input == "yes")
        {
            _reservationService.Create(Session.PersonId, _offert.Id, totalPrice, rooms.Select(r => r.Id).ToList());
            Console.WriteLine();
            Console.WriteLine("Reservation created successfully.");
            PageExtension.Pause();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Reservation cancellled.");
            PageExtension.Pause();
        }

        PageManager.LoadPage("client-offerts");
    }
}