using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class ClientOffertList : PageBase
{
    readonly IReservationService _reservationService;
    readonly IOffertService _offertService;
    readonly IAccomodationService _accomodationService;
    readonly IRoomService _roomService;
    readonly ICarrierService _carrierService;

    protected override string Title 
    { 
        get => "List of Offerts";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => OpenSelectOffert(),
            ['0'] = () => PageManager.LoadPage("client-home"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new TextLabel("Offerts: "),
            new ListView<TextLabel>(GetOffertsAsLabels()),
            new TextLabel(),
            new TextLabel("1) Select Offert"),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public ClientOffertList(IReservationService reservationService, IOffertService offertService, IAccomodationService accomodationService, 
        IRoomService roomService, ICarrierService carrierService)
    {
        _reservationService = reservationService;
        _offertService = offertService;
        _accomodationService = accomodationService;
        _roomService = roomService;
        _carrierService = carrierService;
    }

    List<TextLabel> GetOffertsAsLabels() => _offertService.GetAll()
        .Select( (o,i) => new TextLabel($"- {i+1}.  \'{o.Title}\'     ({o.Date.ToShortDateString()}-{(o.Date+o.Duration).ToShortDateString()})"))
        .ToList();

    void OpenSelectOffert()
    {
        Offert offert = _offertService.GetAll().SelectFromList();
        new ClientOffertDetails(offert.Id,_reservationService, _offertService, _accomodationService, _carrierService).Load();
    } 
}