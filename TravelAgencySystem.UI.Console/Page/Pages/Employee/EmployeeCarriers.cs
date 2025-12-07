using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class EmployeeCarriers : PageBase
{
    readonly ICarrierService _carrierService;

    protected override string Title 
    { 
        get => "Carriers";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => AddCarrier(),
            ['2'] = () => RemoveCarrier(),
            ['3'] = () => UpdateCarrier(),
            ['0'] = () => PageManager.LoadPage("employee-home"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new ListView<TextLabel>(GetAccomodationsAsLabels()),
            new TextLabel(),
            new TextLabel("1) Add Carrier"),
            new TextLabel("2) Remove Carrier"),
            new TextLabel("3) Update Carrier"),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public EmployeeCarriers(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }

    List<TextLabel> GetAccomodationsAsLabels() => _carrierService.GetAll()
        .Select( (o,i) => new TextLabel(AsText(o,i)) )
        .ToList();

    string AsText(Carrier carrier, int index) => 
        $"- {index+1}. {carrier.Name.NormalizeTextSize(_carrierService.GetAll().Max(a => a.Name.Length))} ({carrier.Type}) Price: {carrier.Price}PLN";

    void AddCarrier()
    {
        Console.WriteLine($"Adding new Carrier");
        Console.Write($"Name: ");
        string name = Console.ReadLine()??string.Empty;
        Console.Write($"Type (Plane, Train, Bus, Boat): ");
        TypeOfTransport type = Enum.Parse<TypeOfTransport>(Console.ReadLine()??string.Empty);
        Console.Write($"Space Count: ");
        int spaceCount = int.Parse(Console.ReadLine()??string.Empty);
        Console.Write($"Start Place: ");
        string startPlace = Console.ReadLine()??string.Empty;
        Console.Write($"Return Place: ");
        string returnPlace = Console.ReadLine()??string.Empty;
        Console.Write($"Price: ");
        double price = double.Parse(Console.ReadLine()??string.Empty);

        _carrierService.Create(name, type, spaceCount, startPlace, returnPlace, price);

        Console.WriteLine();
        PageExtension.ConsoleSucces("Carrier added successfully.");
        PageExtension.Pause();
    }

    void RemoveCarrier()
    {
        Carrier carrier = _carrierService.GetAll().SelectFromList();
        _carrierService.Remove(carrier.Id);

        Console.WriteLine();
        PageExtension.ConsoleSucces("Carrier removed successfully.");
        PageExtension.Pause();
    }

    void UpdateCarrier()
    {
        Carrier carrier = _carrierService.GetAll().SelectFromList();

        Console.WriteLine();
        Console.WriteLine($"Updating Carrier");
        Console.Write($"Price: ");
        double? price = null;
        if(double.TryParse(Console.ReadLine()??string.Empty, out var parsedPrice))
            price = parsedPrice;

        _carrierService.Update(carrier.Id, price);

        Console.WriteLine();
        PageExtension.ConsoleSucces("Carrier updated successfully.");
        PageExtension.Pause();
    }


}