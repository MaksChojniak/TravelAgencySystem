using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class SetEmployeeData : PageBase
{
    readonly IEmployeeService _employeeService;

    string _firstName;
    string _lastName;
    string _pesel;
    double _salary;

    protected override string Title  
    {
        get => "Set Personal Data"; 
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>() {}; 
    }
    protected override IEnumerable<ElementBase> Elements  
    { 
        get => new List<ElementBase>()
        {
            new TextInputLabel("First Name: ", (input) => _firstName = input),
            new TextInputLabel("Last Name: ", (input) => _lastName = input),
            new TextInputLabel("Pesel: ", (input) => _pesel = input),
            new TextInputLabel("Salary: ", (input) => double.TryParse(input, out _salary))
        };
    }

    public SetEmployeeData(IEmployeeService employeeService) : base()
    {
        _employeeService = employeeService;
    }

    protected override void Show()
    {
        base.Show();

        try
        {
            _employeeService.Update(Session.PersonId, _firstName, _lastName, _pesel, _salary);
            PageManager.LoadPage("employee-home");
            // PageManager.LoadPage("menu");
        }
        catch(AuthException exc)
        {
            Console.WriteLine($"Error: {exc}");
            return;
        }
    }
}