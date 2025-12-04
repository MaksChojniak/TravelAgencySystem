public class MenuPage : PageBase
{
    protected override string Title 
    { 
        get => "Home";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => PageManager.LoadPage("employee-auth"),
            ['2'] = () => PageManager.LoadPage("client-auth"),
            ['0'] = () => Environment.Exit(0),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new TextLabel("1) Employee"),
            new TextLabel("2) Client"),
            new TextLabel(),
            new TextLabel("0) Exit")
        };
    }

    public MenuPage() {}

    protected override void Show()
    {
        Session.PersonId = Guid.Empty;
        base.Show();
    }
}