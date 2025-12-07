using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;

public class EmployeeRooms : PageBase
{
    readonly Guid _accomodationId;
    readonly IAccomodationService _accomodationService;
    readonly IRoomService _roomService;

    protected override string Title 
    { 
        get => $"Rooms of Accomodation {_accomodationService.Get(_accomodationId).Name}";
    }
    protected override Dictionary<char, Action?> Actions 
    { 
        get => new Dictionary<char, Action?>()
        {
            ['1'] = () => AddRoom(),
            ['2'] = () => RemoveRoom(),
            ['3'] = () => UpdateRoom(),
            ['4'] = () => {},
            ['0'] = () => PageManager.LoadPage("employee-accomodations"),
        };
    }
    protected override IEnumerable<ElementBase> Elements 
    { 
        get => new List<ElementBase>()
        {
            new ListView<TextLabel>(GetRoomsAsLabels()),
            new TextLabel(),
            new TextLabel("1) Add Room"),
            new TextLabel("2) Remove Room"),
            new TextLabel("3) Update Room"),
            new TextLabel(),
            new TextLabel("0) Back")
        };
    }

    public EmployeeRooms(Guid accomodationId, IAccomodationService accomodationService, IRoomService roomService)
    {
        _accomodationId = accomodationId;
        _accomodationService = accomodationService;
        _roomService = roomService;
    }

    List<TextLabel> GetRoomsAsLabels() => _accomodationService.GetRooms(_accomodationId)
        .Select( (o,i) => new TextLabel(AsText(o,i)) )
        .ToList();

    string AsText(Room room, int index) => 
        $"- {index+1}. Room {room.Number}, Floor {room.Floor}  Space Count {room.SpaceCount}  Price: {room.Price}PLN [{(room.IsAvailable ? "Available" : "Not Available")}]";

    void AddRoom()
    {
        Console.WriteLine($"Adding new Room");
        Console.Write($"Number: ");
        int number = int.Parse(Console.ReadLine()??string.Empty);
        Console.Write($"Floor: ");
        int floor = int.Parse(Console.ReadLine()??string.Empty);
        Console.Write($"Space Count: ");
        int spaceCount = int.Parse(Console.ReadLine()??string.Empty);
        Console.Write($"Price: ");
        double price = double.Parse(Console.ReadLine()??string.Empty);

        _roomService.Create(_accomodationId, null, floor, number, spaceCount, price);

        Console.WriteLine();
        Console.WriteLine("Room added successfully.");
        PageExtension.Pause();
    }

    void RemoveRoom()
    {
        Room room = _roomService.GetAll().SelectFromList();
        _roomService.Remove(room.Id);

        Console.WriteLine();
        Console.WriteLine("Room removed successfully.");
        PageExtension.Pause();
    }

    void UpdateRoom()
    {
        Room room = _roomService.GetAll().SelectFromList();

        Console.WriteLine();
        Console.WriteLine($"Updating Room Price");
        Console.Write($"Price: ");
        double? price = null;
        if(double.TryParse(Console.ReadLine()??string.Empty, out var parsedPrice))
            price = parsedPrice;

        _roomService.Update(room.Id, price);

        Console.WriteLine();
        Console.WriteLine("Room updated successfully.");
        PageExtension.Pause();
    }

}