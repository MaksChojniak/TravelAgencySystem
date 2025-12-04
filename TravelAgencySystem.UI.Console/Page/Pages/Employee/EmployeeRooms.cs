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
        // Console.WriteLine($"Adding new Accomodation");
        // Console.Write($"Name: ");
        // string name = Console.ReadLine()??string.Empty;
        // Console.Write($"Address: ");
        // string address = Console.ReadLine()??string.Empty;
        // Console.Write($"Stars: ");
        // int stars = int.Parse(Console.ReadLine()??string.Empty);

        // _accomodationService.Create(name, address, stars);

        // Console.WriteLine();
        // Console.WriteLine("Accomodation added successfully.");
        // PageExtension.Pause();
    }

    void RemoveRoom()
    {
        // var accomodations = _accomodationService.GetAll();

        // if(accomodations.Count == 0)
        //     throw new Exception("No Accomodations available");

        // Console.Write($"Select Accomodation: ");
        // string input = Console.ReadLine()??string.Empty;

        // if(string.IsNullOrEmpty(input))
        //     throw new Exception("Invalid input");

        // if(!int.TryParse(input, out var selectedIndex))
        //     throw new Exception("Not a number");
        
        // selectedIndex -= 1;
        // if(selectedIndex < 0 || selectedIndex >= accomodations.Count)
        //     throw new Exception("Index out of range");

        // Accomodation accomodation = accomodations[selectedIndex];
        // _accomodationService.Remove(accomodation.Id);

        // Console.WriteLine();
        // Console.WriteLine("Accomodation removed successfully.");
        // PageExtension.Pause();
    }

    void UpdateRoom()
    {
        // var accomodations = _accomodationService.GetAll();

        // if(accomodations.Count == 0)
        //     throw new Exception("No Accomodations available");

        // Console.Write($"Select Accomodation: ");
        // string input = Console.ReadLine()??string.Empty;

        // if(string.IsNullOrEmpty(input))
        //     throw new Exception("Invalid input");

        // if(!int.TryParse(input, out var selectedIndex))
        //     throw new Exception("Not a number");
        
        // selectedIndex -= 1;
        // if(selectedIndex < 0 || selectedIndex >= accomodations.Count)
        //     throw new Exception("Index out of range");

        // Accomodation accomodation = accomodations[selectedIndex];

        // Console.WriteLine();
        // Console.WriteLine($"Updating Accomodation");
        // Console.Write($"Name: ");
        // string? name = Console.ReadLine()??string.Empty;
        // if(string.IsNullOrEmpty(name))
        //     name = null;
        // Console.Write($"Address: ");
        // string? address = Console.ReadLine()??string.Empty;
        // if(string.IsNullOrEmpty(address))
        //     address = null;
        // Console.Write($"Stars: ");
        // int? stars = null;
        // if(int.TryParse(Console.ReadLine()??string.Empty, out var parsedStars))
        //     stars = parsedStars;

        // _accomodationService.Update(accomodation.Id, name, address, stars);

        // Console.WriteLine();
        // Console.WriteLine("Accomodation updated successfully.");
        // PageExtension.Pause();
    }

}