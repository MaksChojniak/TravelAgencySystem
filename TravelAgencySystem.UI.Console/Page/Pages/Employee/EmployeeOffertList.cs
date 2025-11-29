using TravelAgencySystem.Services.Abstractions;

public class EmployeeOffertList : PageBase
{
    readonly IOffertService _offertService;

    protected override string Title 
    { 
        get => "Hosted Offerts";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => PageManager.LoadPage(""),
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

    public EmployeeOffertList(IOffertService offertService)
    {
        _offertService = offertService;
    }

    List<TextLabel> GetOffertsAsLabels() => _offertService.GetAll()
        .Select( o => new TextLabel($"- Offert ({o.Date.ToShortDateString()}-{(o.Date+o.Duration).ToShortDateString()})"))
        .ToList(); 
}