using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class EmployeeLogin : PageBase
{
    readonly IAuthService<Employee> _authService;

    string _login;
    string _password;

    protected override string Title  
    {
        get => "Employee Login"; 
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

    public EmployeeLogin(IAuthService<Employee> authService) : base()
    {
        _authService = authService;
    }

    public override void Show()
    {
        base.Show();

        try
        {
            Session.PersonId = _authService.Login(_login, _password).Id;
            PageManager.LoadPage("employee-home");
        }
        catch(AuthException exc)
        {
            // Console.WriteLine($"Error: {exc}");
            new AuthError(exc.Message, "employee-login").Show();
            return;
        }
    }
}