namespace TravelAgencySystem.DataModel;

public class Offert
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public Guid HostEmployeeId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid CarrierId { get; set; }
    public Guid AccomodationId { get; set; }
}


