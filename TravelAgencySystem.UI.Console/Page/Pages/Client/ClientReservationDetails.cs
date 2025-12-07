using System.Security;
using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class ClientReservationDetails : PageBase
{
    readonly IReservationService _reservationService;
    readonly IOffertService _offertService;
    readonly IAccomodationService _accomodationService;
    readonly IRoomService _roomService;
    readonly ICarrierService _carrierService;

    Reservation _reservation;
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
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => Pay(),
            ['2'] = () => Cancel(),
            ['0'] = () => PageManager.LoadPage("client-reservations"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new TextLabel($"Name: {_offert.Title}"),
            new TextLabel($"Status: {_reservation.Status}"),
            new TextLabel($"Date: {_offert.Date.ToShortDateString()}"),
            new TextLabel($"Duration: {_offert.Duration.TotalDays} Days"),
            new TextLabel($"Carrier: "),
            new TextLabel($"  -Name: {_carrier.Name} ({_carrier.Type})"),
            new TextLabel($"  -Free Space: {_offertService.FreeSpaces(_offert.Id)}"),
            new TextLabel($"  -Start Place - Return Place: {_carrier.StartPlace} -> {_carrier.ReturnPlace}"),
            new TextLabel($"Accomodation: "),
            new TextLabel($"  -Name: {_accomodation.Name} {stars(_accomodation.Stars)}"),
            new TextLabel($"  -Address: {_accomodation.Address}"),
            new TextLabel($"  -Rooms: "),
            new ListView<TextLabel>(GetRoomsAsLabels()),
            new TextLabel(),
            new TextLabel($"=== Total Price: {_reservation.Price}PLN ==="),
            new TextLabel(),
            new TextLabel("1) Pay"),
            new TextLabel("2) Cancel"),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public ClientReservationDetails(Guid reservationId, IReservationService reservationService, IOffertService offertService, IAccomodationService accomodationService, 
        IRoomService roomService, ICarrierService carrierService)
    {
        _reservationService = reservationService;
        _offertService = offertService;
        _accomodationService = accomodationService;
        _roomService = roomService;
        _carrierService = carrierService;
    
        _reservation = _reservationService.Get(reservationId);
        _offert = _offertService.Get(_reservation.OffertId);
        _accomodation = _accomodationService.Get(_offert.AccomodationId);
        _carrier = _carrierService.Get(_offert.CarrierId);
    }

    List<TextLabel> GetRoomsAsLabels()
    {
        List<TextLabel> list = _roomService.GetAll().Where(r => r.ReservationId == _reservation.Id)
        .Select( room => new TextLabel($"    - Room {room.Number}, Floor {room.Floor}  Space Count {room.SpaceCount}"))
        .ToList(); 

        if(list.Count <= 0)
            list = new() {new TextLabel("None of the Rooms are Avaiable") };

        return list;
    }

    string stars(int count) => new string('*', count).NormalizeTextSize(5);

    void Pay()
    {
        if(_reservationService.Get(_reservation.Id).Status == ReservationStatus.Paid)
        {
            Console.WriteLine();
            Console.WriteLine("Reservation status is Payed .");
            PageExtension.Pause();    
        }

        _reservationService.Update(_reservation.Id, ReservationStatus.Paid);

        Console.WriteLine();
        Console.WriteLine("Reservation Payed successfully.");
        PageExtension.Pause();
    }

    void Cancel()
    {
        _reservationService.Remove(_reservation.Id);

        Console.WriteLine();
        Console.WriteLine("Reservation cancelled successfully.");
        PageExtension.Pause();

        PageManager.LoadPage("client-reservations");
    }

}