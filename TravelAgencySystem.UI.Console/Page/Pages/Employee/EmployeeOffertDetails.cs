using System.Security;
using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class EmployeeOffertDetails : PageBase
{
    readonly IOffertService _offertService;
    readonly IAccomodationService _accomodationService;
    readonly IRoomService _roomService;
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
        get => new Dictionary<char, Action?>()
        {
            ['0'] = () => PageManager.LoadPage("employee-offerts"),
        };
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
            new TextLabel($"  -Rooms: "),
            new ListView<TextLabel>(GetRoomsAsLabels()),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public EmployeeOffertDetails(Guid offertId, IOffertService offertService, IAccomodationService accomodationService, 
        IRoomService roomService, ICarrierService carrierService)
    {
        _offertService = offertService;
        _accomodationService = accomodationService;
        _roomService = roomService;
        _carrierService = carrierService;

        _offert = _offertService.Get(offertId);
        _accomodation = _accomodationService.Get(_offert.AccomodationId);
        _carrier = _carrierService.Get(_offert.CarrierId);
    }

    List<TextLabel> GetRoomsAsLabels()
    {
        List<TextLabel> list = _accomodationService.GetRooms(_accomodation.Id)
        .Select( room => new TextLabel($"    - Room {room.Number}, Floor {room.Floor}  Space Count {room.SpaceCount}  Price: {room.Price}PLN"))
        .ToList(); 

        if(list.Count <= 0)
            list = new() {new TextLabel("None of the Rooms are Avaiable") };

        return list;
    }

    string stars(int count) => new string('*', count).NormalizeTextSize(5);
}