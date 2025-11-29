using TravelAgencySystem.Services.Abstractions;

public class EmployeeHome : PageBase
{
    protected override string Title 
    { 
        get => "Home";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => PageManager.LoadPage("employee-offerts"),
            ['2'] = () => PageManager.LoadPage("employee-accomodations"),
            ['2'] = () => PageManager.LoadPage("employee-carriers"),
            ['2'] = () => PageManager.LoadPage("employee-proile"),
            ['0'] = () => PageManager.LoadPage("menu"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new TextLabel("1) Hosted Offerts"),
            new TextLabel("2) Accomodations"),
            new TextLabel("3) Carriers"),
            new TextLabel("4) Profile"),
            new TextLabel("0) Logout")
        };
    }

    public EmployeeHome() {}
}