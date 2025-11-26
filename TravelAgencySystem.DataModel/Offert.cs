namespace ProjectApp.DataModel
{
    public class Offert
    {
        public Guid Id { get; set; }
        public Guid HostEmployeeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid CarrierId { get; set; }
        public Guid AccomodationId { get; set; }
        public double Price { get; set; }
        public int FreeSpaces { get; set; }
        public int SpaceCount { get; set; }
    }

}
