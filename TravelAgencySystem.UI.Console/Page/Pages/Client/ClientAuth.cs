using TravelAgencySystem.Services.Abstractions;

public class ClientAuth : PageBase
{
    readonly IAuthService _authService;

    protected override string Title 
    { 
        get => "Client Auth";
    }
    protected override Dictionary<char, Action?> Actions
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => Login(),
            ['2'] = () => Register(),
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

    public ClientAuth(IAuthService authService)
    {
        _authService = authService;
    }

    void Login()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Login: ");
        string login = Console.ReadLine() ?? string.Empty;
        Console.Write("Password: ");
        string password = Console.ReadLine() ?? string.Empty;

        Session.PersonId = _authService.Login(login, password).PersonId;
        PageManager.LoadPage("client-home");
    }

    void Register()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Login: ");
        string login = Console.ReadLine() ?? string.Empty;
        Console.Write("Password: ");
        string password = Console.ReadLine() ?? string.Empty;

        Session.PersonId = _authService.CreateAccount(login, password);
        PageManager.LoadPage("client-set-register-data");
    }
}