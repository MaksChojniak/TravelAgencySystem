namespace ProjectApp.DataModel
{
    public class Carrier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TypeOfTransport Type { get; set; }
        public int FreeSpaces { get; set; }
        public int SpaceCount { get; set; }
        public string StartPlace { get; set; }
        public string ReturnPlace { get; set; }

    }

    public enum TypeOfTransport
    {
        Plane,
        Train,
        Bus,
        Boat
    }
}
