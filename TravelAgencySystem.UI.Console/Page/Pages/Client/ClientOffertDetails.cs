using System.Security;
using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class ClientOffertDetails : PageBase
{
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
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => PageManager.LoadPage("client-reserve-offert"),
            ['0'] = () => PageManager.LoadPage("client-offerts"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new TextLabel($"Date: {_offert.Date.ToShortDateString()}"),
            new TextLabel($"Duration: {_offert.Duration.TotalDays} Days"),
            new TextLabel($"Carrier: "),
            new TextLabel($"  -Name: {_carrier.Name}"),
            new TextLabel($"  -Type: {_carrier.Type}"),
            // new TextLabel($"  -Free Space: {_carrierService.ComputeFreeSpaces(_offert.Id)}"),
            new TextLabel($"  -Start Place: {_carrier.StartPlace}"),
            new TextLabel($"  -Return Place: {_carrier.ReturnPlace}"),
            new TextLabel($"  -Price: {_carrier.Price} PLN / person"),
            new TextLabel($"Accomodation: "),
            new TextLabel($"  -Name: {_accomodation.Name}"),
            new TextLabel($"  -Address: {_accomodation.Address}"),
            new TextLabel($"  -Stars: {_accomodation.Stars}/5"),
            new TextLabel($"  -Free Rooms: "),
            new ListView<TextLabel>(GetFreeRoomsAsLabels()),
            new TextLabel("1) Reserve"),
            new TextLabel("0) Back")
        };
    }

    public ClientOffertDetails(Offert offert, IOffertService offertService, IAccomodationService accomodationService,
        ICarrierService carrierService)
    {
        _offertService = offertService;
        _accomodationService = accomodationService;
        _carrierService = carrierService;
    
        _offert = offert;
        _accomodation = _accomodationService.Get(_offert.AccomodationId);
        _carrier = _carrierService.Get(_offert.CarrierId);
    }

    List<TextLabel> GetFreeRoomsAsLabels()
    {
        List<TextLabel> list = _accomodationService.GetAvaiableRooms(_offert.AccomodationId)
        .Select( r => new TextLabel($"    - Room {r.Number}, Floor: {r.Floor}, Space Count: {r.SpaceCount}, Price: {r.Price} PLN"))
        .ToList(); 

        if(list.Count <= 0)
            list = new() {new TextLabel("None of the Rooms are Avaiable") };

        return list;
    }
}