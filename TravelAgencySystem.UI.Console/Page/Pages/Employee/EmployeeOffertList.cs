using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class EmployeeOffertList : PageBase
{
    readonly IOffertService _offertService;
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
            ['2'] = () => PageManager.LoadPage(""),
            ['0'] = () => PageManager.LoadPage("employee-home"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new ListView<TextLabel>(GetOffertsAsLabels()),
            new TextLabel("1) Select Offert"),
            new TextLabel("2) Create new Offfert"),
            new TextLabel("0) Back")
        };
    }

    public EmployeeOffertList(IOffertService offertService, IEmployeeService employeeService)
    {
        _offertService = offertService;
        _employeeService = employeeService;
    }

    List<TextLabel> GetOffertsAsLabels() => _employeeService.GetHostedOfferts(Session.PersonId)
        .Select( (o,i) => new TextLabel($"- {i+1}. Offert  \'{o.Title}\'     ({o.Date.ToShortDateString()}-{(o.Date+o.Duration).ToShortDateString()})"))
        .ToList();

    void OpenSelectOffert()
    {
        Console.WriteLine();
        Console.Write("Selected Offert: ");
        string input = Console.ReadLine()??string.Empty;
        if(!string.IsNullOrEmpty(input) && int.TryParse(input, out var selectedOffertIndex) && 0 <= selectedOffertIndex-1 && selectedOffertIndex-1 < _offertService.GetAll().Count)
        {
            Offert offert = _offertService.GetAll()[selectedOffertIndex-1];
            // new EmployeeOffertDetails(offert, _offertService, _accomodationService, _carrierService).Show();
            return;
        }

        Show();
    } 

}