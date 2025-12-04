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
        .Select( (o,i) => new TextLabel(AsText(o, i)))
        .ToList();

    string AsText(Offert offert, int index) => 
        $"- {index+1}. Offert  \'{offert.Title}\'     ({offert.Date.ToShortDateString()}-{(offert.Date+offert.Duration).ToShortDateString()})";

    void OpenSelectOffert()
    {
        var offerts = _employeeService.GetHostedOfferts(Session.PersonId);

        if(offerts.Count == 0)
            throw new Exception("No offerts available");

        Console.Write($"Select Offert: ");
        string input = Console.ReadLine()??string.Empty;

        if(string.IsNullOrEmpty(input))
            throw new Exception("Invalid input");

        if(!int.TryParse(input, out var selectedIndex))
            throw new Exception("Not a number");
        
        selectedIndex -= 1;
        if(selectedIndex < 0 || selectedIndex >= offerts.Count)
            throw new Exception("Index out of range");

        Offert offert = offerts[selectedIndex];
        // new EmployeeOffertDetails(offert, _offertService, _accomodationService, _carrierService).Show();
    } 

}