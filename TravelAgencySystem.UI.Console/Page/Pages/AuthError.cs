public class AuthError : PageBase
{
    string _error;
    string _page;

    protected override string Title 
    { 
        get => "Client Auth";
    }
    protected override Dictionary<char, Action?> Actions
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => PageManager.LoadPage(_page),
            ['0'] = () => PageManager.LoadPage("menu"),
        };
    }
    protected override IEnumerable<ElementBase> Elements
    {
        get => new List<ElementBase>()
        {
            new TextLabel(_error, ConsoleColor.Red),
            new TextLabel(),
            new TextLabel("1) Try Again"),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public AuthError(string error, string page)
    {
        _error = error;
        _page = page;
    }
}