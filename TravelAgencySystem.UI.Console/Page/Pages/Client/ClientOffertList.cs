using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class ClientOffertList : PageBase
{
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
            new TextLabel("1) Select Offert"),
            new TextLabel("0) Back")
        };
    }

    public ClientOffertList(IOffertService offertService, IAccomodationService accomodationService, 
        IRoomService roomService, ICarrierService carrierService)
    {
        _offertService = offertService;
        _accomodationService = accomodationService;
        _roomService = roomService;
        _carrierService = carrierService;
    }

    protected override void Show()
    {
        base.Show();


    }

    List<TextLabel> GetOffertsAsLabels() => _offertService.GetAll()
        .Select( (o,i) => new TextLabel($"- {i+1}.  \'{o.Title}\'     ({o.Date.ToShortDateString()}-{(o.Date+o.Duration).ToShortDateString()})"))
        .ToList();

    void OpenSelectOffert()
    {
        Console.WriteLine();
        Console.Write("Selected Offert: ");
        string input = Console.ReadLine()??string.Empty;
        if(!string.IsNullOrEmpty(input) && int.TryParse(input, out var selectedOffertIndex) && 0 <= selectedOffertIndex-1 && selectedOffertIndex-1 < _offertService.GetAll().Count)
        {
            Offert offert = _offertService.GetAll()[selectedOffertIndex-1];
            // new ClientOffertDetails(offert, _offertService, _accomodationService, _carrierService).Show();
            return;
        }

        Show();
    } 
}