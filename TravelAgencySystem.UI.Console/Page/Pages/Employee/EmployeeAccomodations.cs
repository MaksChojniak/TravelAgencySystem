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
            ['4'] = () => ShowRooms(),
            ['0'] = () => PageManager.LoadPage("employee-home"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new ListView<TextLabel>(GetAccomodationsAsLabels()),
            new TextLabel(),
            new TextLabel("1) Add Accomodation"),
            new TextLabel("2) Remove Accomodation"),
            new TextLabel("3) Update Accomodation"),
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
        $"- {index+1}. {accomodation.Name.NormalizeTextSize(_accomodationService.GetAll().Max(a => a.Name.Length))} {stars(accomodation.Stars)}    Address: {accomodation.Address}";

    string stars(int count) => new string('*', count).NormalizeTextSize(5);

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
        Accomodation accomodation = _accomodationService.GetAll().SelectFromList();
        _accomodationService.Remove(accomodation.Id);

        Console.WriteLine();
        Console.WriteLine("Accomodation removed successfully.");
        PageExtension.Pause();
    }

    void UpdateAccomodation()
    {
        Accomodation accomodation = _accomodationService.GetAll().SelectFromList();

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


    void ShowRooms()
    {
        Accomodation accomodation = _accomodationService.GetAll().SelectFromList();
        new EmployeeRooms(accomodation.Id, _accomodationService, _roomService).Load();
    }

}