using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class EmployeeRegister : PageBase
{
    readonly IAuthService _authService;

    string _login;
    string _password;

    protected override string Title  
    {
        get => "Employee Register"; 
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>() {}; 
    }
    protected override IEnumerable<ElementBase> Elements  
    { 
        get => new List<ElementBase>()
        {
            new TextInputLabel("Login: ", (input) => _login = input),
            new TextInputLabel("Password: ", (input) => _password = input)
        };
    }

    public EmployeeRegister(IAuthService authService) : base()
    {
        _authService = authService;
    }

    public override void Show()
    {
        base.Show();

        try
        {
            Session.PersonId = _authService.CreateAccount(_login, _password);
            PageManager.LoadPage("employee-set-register-data");
        }
        catch(AuthException exc)
        {
            // Console.WriteLine($"Error: {exc}");
            new AuthError(exc.Message, "employee-register").Show();
            return;
        }
    }
}