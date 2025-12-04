using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class EmployeeAccomodations : PageBase
{
    readonly IAccomodationService _accomodationService;
    readonly IRoomService _roomService;

    protected override string Title 
    { 
        get => "Accomodations";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => AddAccomodation(),
            ['2'] = () => RemoveAccomodation(),
            ['3'] = () => UpdateAccomodation(),
            ['4'] = () => {},
            ['0'] = () => PageManager.LoadPage("employee-home"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new ListView<TextLabel>(GetAccomodationsAsLabels()),
            new TextLabel(),
            new TextLabel("1) Add Offert"),
            new TextLabel("2) Remove Offert"),
            new TextLabel("3) Update Offfert"),
            new TextLabel(),
            new TextLabel("4) Show Rooms"),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public EmployeeAccomodations(IAccomodationService accomodationService, IRoomService roomService)
    {
        _accomodationService = accomodationService;
        _roomService = roomService;
    }

    List<TextLabel> GetAccomodationsAsLabels() => _accomodationService.GetAll()
        .Select( (o,i) => new TextLabel(AsText(o,i)) )
        .ToList();

    string AsText(Accomodation accomodation, int index) => 
        $"- {index+1}. {normalizeSize(accomodation.Name, _accomodationService.GetAll().Max(a => a.Name.Length))} {stars(accomodation.Stars)}    Address: {accomodation.Address}";

    string normalizeSize(string text, int size) => text + new string(' ', Math.Clamp(size-text.Length, 0, int.MaxValue));
    string stars(int count) => new string('*', count) + new string(' ', 5-count);

    void AddAccomodation()
    {
        Console.WriteLine($"Adding new Accomodation");
        Console.Write($"Name: ");
        string name = Console.ReadLine()??string.Empty;
        Console.Write($"Address: ");
        string address = Console.ReadLine()??string.Empty;
        Console.Write($"Stars: ");
        int stars = int.Parse(Console.ReadLine()??string.Empty);

        _accomodationService.Create(name, address, stars);

        Console.WriteLine();
        Console.WriteLine("Accomodation added successfully.");
        PageExtension.Pause();
    }

    void RemoveAccomodation()
    {
        var accomodations = _accomodationService.GetAll();

        if(accomodations.Count == 0)
            throw new Exception("No Accomodations available");

        Console.Write($"Select Accomodation: ");
        string input = Console.ReadLine()??string.Empty;

        if(string.IsNullOrEmpty(input))
            throw new Exception("Invalid input");

        if(!int.TryParse(input, out var selectedIndex))
            throw new Exception("Not a number");
        
        selectedIndex -= 1;
        if(selectedIndex < 0 || selectedIndex >= accomodations.Count)
            throw new Exception("Index out of range");

        Accomodation accomodation = accomodations[selectedIndex];
        _accomodationService.Remove(accomodation.Id);

        Console.WriteLine();
        Console.WriteLine("Accomodation removed successfully.");
        PageExtension.Pause();
    }

    void UpdateAccomodation()
    {
        var accomodations = _accomodationService.GetAll();

        if(accomodations.Count == 0)
            throw new Exception("No Accomodations available");

        Console.Write($"Select Accomodation: ");
        string input = Console.ReadLine()??string.Empty;

        if(string.IsNullOrEmpty(input))
            throw new Exception("Invalid input");

        if(!int.TryParse(input, out var selectedIndex))
            throw new Exception("Not a number");
        
        selectedIndex -= 1;
        if(selectedIndex < 0 || selectedIndex >= accomodations.Count)
            throw new Exception("Index out of range");

        Accomodation accomodation = accomodations[selectedIndex];

        Console.WriteLine();
        Console.WriteLine($"Updating Accomodation");
        Console.Write($"Name: ");
        string? name = Console.ReadLine()??string.Empty;
        if(string.IsNullOrEmpty(name))
            name = null;
        Console.Write($"Address: ");
        string? address = Console.ReadLine()??string.Empty;
        if(string.IsNullOrEmpty(address))
            address = null;
        Console.Write($"Stars: ");
        int? stars = null;
        if(int.TryParse(Console.ReadLine()??string.Empty, out var parsedStars))
            stars = parsedStars;

        _accomodationService.Update(accomodation.Id, name, address, stars);

        Console.WriteLine();
        Console.WriteLine("Accomodation updated successfully.");
        PageExtension.Pause();
    }

}