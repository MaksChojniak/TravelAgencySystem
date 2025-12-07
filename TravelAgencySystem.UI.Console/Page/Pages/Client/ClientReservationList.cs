using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class ClientReservationList : PageBase
{
    readonly IReservationService _reservationService;
    readonly IClientService _clientService;
    readonly IOffertService _offertService;
    readonly IAccomodationService _accomodationService;
    readonly IRoomService _roomService;
    readonly ICarrierService _carrierService;

    protected override string Title 
    { 
        get => "List of Reservations";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => OpenSelectReservation(),
            ['0'] = () => PageManager.LoadPage("client-home"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new TextLabel("Reservations: "),
            new ListView<TextLabel>(GetOffertsAsLabels()),
            new TextLabel(),
            new TextLabel("1) Select Reservation"),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public ClientReservationList(IReservationService reservationService, IClientService clientService, IOffertService offertService, IAccomodationService accomodationService, 
        IRoomService roomService, ICarrierService carrierService)
    {
        _reservationService = reservationService;
        _clientService = clientService;
        _offertService = offertService;
        _accomodationService = accomodationService;
        _roomService = roomService;
        _carrierService = carrierService;
    }

    List<TextLabel> GetOffertsAsLabels() => _clientService.GetAllReservations(Session.PersonId)
        .Select( r => (
            Reservation: r,
            Offert: _offertService.Get(r.OffertId),
            Accomodation: _accomodationService.Get(_offertService.Get(r.OffertId).AccomodationId),
            Carrier: _carrierService.Get(_offertService.Get(r.OffertId).CarrierId)) )
        .Select( (o, i) => new TextLabel($"- {i+1}.  \'{o.Offert.Title}\'  ({o.Reservation.Status})   ({o.Offert.Date.ToShortDateString()}-{(o.Offert.Date+o.Offert.Duration).ToShortDateString()})"))
        .ToList();

    void OpenSelectReservation()
    {
        Reservation reservation = _clientService.GetAllReservations(Session.PersonId).SelectFromList();
        new ClientReservationDetails(reservation.Id, _reservationService, _offertService, _accomodationService, _roomService, _carrierService).Load();
    } 
}