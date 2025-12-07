using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class EmployeeOffertList : PageBase
{
    readonly IOffertService _offertService;
    readonly ICarrierService _carrierService;
    readonly IAccomodationService _accomodationService;
    readonly IRoomService _roomService;
    readonly IEmployeeService _employeeService;

    protected override string Title 
    { 
        get => "Hosted Offerts";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => OpenSelectOffert(),
            ['2'] = () => AddOffert(),
            ['0'] = () => PageManager.LoadPage("employee-home"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new ListView<TextLabel>(GetOffertsAsLabels()),
            new TextLabel(),
            new TextLabel("1) Select Offert"),
            new TextLabel("2) Create new Offfert"),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public EmployeeOffertList(IOffertService offertService, ICarrierService carrierService, IAccomodationService accomodationService, IRoomService roomService, IEmployeeService employeeService)
    {
        _offertService = offertService;
        _carrierService = carrierService;
        _accomodationService = accomodationService;
        _roomService = roomService;
        _employeeService = employeeService;
    }

    List<TextLabel> GetOffertsAsLabels() => _employeeService.GetHostedOfferts(Session.PersonId)
        .Select( (o,i) => new TextLabel(AsText(o, i)))
        .ToList();

    string AsText(Offert offert, int index) => 
        $"- {index+1}. Offert  \'{offert.Title}\'     ({offert.Date.ToShortDateString()}-{(offert.Date+offert.Duration).ToShortDateString()})";

    string AsText(Carrier carrier, int index) => 
        $"- {index+1}. {carrier.Name.NormalizeTextSize(_carrierService.GetAll().Max(a => a.Name.Length))} ({carrier.Type}) Price: {carrier.Price}PLN";

    string AsText(Accomodation accomodation, int index) => 
        $"- {index+1}. {accomodation.Name.NormalizeTextSize(_accomodationService.GetAll().Max(a => a.Name.Length))} {stars(accomodation.Stars)}    Address: {accomodation.Address}";

    string stars(int count) => new string('*', count).NormalizeTextSize(5);

    void AddOffert()
    {
        Console.WriteLine($"Adding new Offert");

        Console.Write($"Title: ");
        string title = Console.ReadLine()??string.Empty;
        Console.Write($"Date (DD.MM.YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine()??string.Empty);
        Console.Write($"Duration: ");
        TimeSpan duration = TimeSpan.FromDays(int.Parse(Console.ReadLine()??string.Empty));
        Console.WriteLine($"Carriers: ");
        var carriers = _carrierService.GetAll();
        Console.WriteLine(string.Join('\n', carriers.Select((c,i) => AsText(c, i)).ToList()));
        Console.Write($"Select Carrier: ");
        Carrier carrier = carriers.SelectFromList();
        Console.WriteLine($"Accomodations: ");
        var accomodations = _accomodationService.GetAll();
        Console.WriteLine(string.Join('\n', accomodations.Select((c,i) => AsText(c, i)).ToList())); 
        Console.Write($"Select Accomodation: ");
        Accomodation accomodation = accomodations.SelectFromList();

        _offertService.Create(Session.PersonId, title, date, duration, carrier.Id, accomodation.Id);

        Console.WriteLine();
        PageExtension.ConsoleSucces("Offert added successfully.");
        PageExtension.Pause();
    }

    void OpenSelectOffert()
    {
        Offert offert = _employeeService.GetHostedOfferts(Session.PersonId).SelectFromList();
        new EmployeeOffertDetails(offert.Id, _offertService, _accomodationService, _roomService, _carrierService).Load();
    } 

}