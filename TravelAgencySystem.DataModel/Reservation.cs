namespace ProjectApp.DataModel
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid OffertId { get; set; }
        public List<Guid> RoomIds { get; set; }
        public ReservationStatus Status { get; set; }
    }

    public enum ReservationStatus
    {
        Paid,
        InProgress,
    }
}
