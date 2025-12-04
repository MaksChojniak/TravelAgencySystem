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
            new TextLabel(),
            new TextLabel("1) Select Offert"),
            new TextLabel("2) Create new Offfert"),
            new TextLabel(),
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
        if(_employeeService.GetHostedOfferts(Session.PersonId).Count == 0)
        {
            Console.WriteLine("-- No offerts available --");
            PageExtension.Pause();
            return;
        }

        Console.WriteLine();
        Console.Write($"Select Offert: ");
        string input = Console.ReadLine()??string.Empty;

        if(string.IsNullOrEmpty(input))
        {
            PageExtension.ConsoleError("-- Invalid input --");
            PageExtension.Pause();
            Show();
            return;
        }

        if(!int.TryParse(input, out var selectedOffertIndex))
        {
            PageExtension.ConsoleError("-- Not a number --");
            PageExtension.Pause();
            Show();
            return;
        }
        
        selectedOffertIndex -= 1;
        if(selectedOffertIndex < 0 || selectedOffertIndex >= _employeeService.GetHostedOfferts(Session.PersonId).Count)
        {
            PageExtension.ConsoleError("-- Number out of range --");
            PageExtension.Pause();
            Show();
            return;
        }


        Offert offert = _employeeService.GetHostedOfferts(Session.PersonId)[selectedOffertIndex];
        // new EmployeeOffertDetails(offert, _offertService, _accomodationService, _carrierService).Show();
    } 

}