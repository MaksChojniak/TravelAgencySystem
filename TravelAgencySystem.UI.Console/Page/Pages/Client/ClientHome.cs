using TravelAgencySystem.Services.Abstractions;

public class ClientHome : PageBase
{
    protected override string Title 
    { 
        get => "Home";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => PageManager.LoadPage("client-offerts"),
            ['2'] = () => PageManager.LoadPage("client-reservations"),
            ['3'] = () => PageManager.LoadPage("client-proile"),
            ['0'] = () => PageManager.LoadPage("menu"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new TextLabel("1) All Offerts"),
            new TextLabel("2) Reservations"),
            new TextLabel(),
            new TextLabel("3) Profile"),
            new TextLabel(),
            new TextLabel("0) Logout")
        };
    }

    public ClientHome() {}
}