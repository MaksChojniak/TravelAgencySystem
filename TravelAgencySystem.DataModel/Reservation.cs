namespace TravelAgencySystem.DataModel;

public class Reservation
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid OffertId { get; set; }
    public int NumberOfPeople { get; set; }
    public ReservationStatus Status { get; set; }
    public double Price { get; set; }
}

public enum ReservationStatus
{
    Paid,
    InProgress,
}

