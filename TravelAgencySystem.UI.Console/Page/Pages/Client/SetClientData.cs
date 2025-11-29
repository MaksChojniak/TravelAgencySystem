using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class SetClientData : PageBase
{
    readonly IClientService _clientService;

    string _firstName;
    string _lastName;
    string _pesel;
    string _phoneNumber;
    string _email;
    string _address;

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
            new TextInputLabel("Phone Number: ", (input) => _phoneNumber = input),
            new TextInputLabel("Email: ", (input) => _email = input),
            new TextInputLabel("Address: ", (input) => _address = input)
        };
    }

    public SetClientData(IClientService clientService) : base()
    {
        _clientService = clientService;
    }

    public override void Show()
    {
        base.Show();

        try
        {
            _clientService.Update(Session.PersonId, _firstName, _lastName, _pesel, _phoneNumber, _email, _address);
            PageManager.LoadPage("client-home");
        }
        catch(AuthException exc)
        {
            Console.WriteLine($"Error: {exc}");
            return;
        }
    }
}