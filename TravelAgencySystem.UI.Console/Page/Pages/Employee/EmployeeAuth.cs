public class EmployeeAuth : PageBase
{
    protected override string Title 
    { 
        get => "Employee Auth";
    }
    protected override Dictionary<char, Action?> Actions
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => PageManager.LoadPage("employee-login"),
            ['2'] = () => PageManager.LoadPage("employee-register"),
            ['0'] = () => PageManager.LoadPage("menu"),
        };
    }
    protected override IEnumerable<ElementBase> Elements
    {
        get => new List<ElementBase>()
        {
            new TextLabel("1) Login"),
            new TextLabel("2) Register"),
            new TextLabel("0) Back")
        };
    }

    public EmployeeAuth() {}
}