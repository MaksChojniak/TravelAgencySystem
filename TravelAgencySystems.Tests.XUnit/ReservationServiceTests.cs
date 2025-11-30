using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Tests.XUnit;

namespace TravelAgencySystems.Tests.XUnit;

public class ReservationServiceTests : IClassFixture<InMemoryServicesFixture>
{
    readonly IReservationService _reservationService;

    readonly SeedResult _seed;

    public ReservationServiceTests(InMemoryServicesFixture fx)
    {
        _reservationService = fx.ReservationService;
        
        _seed = fx.Seed;
    }

#region Create
    [Fact]
    public void Create_Success()
    {
        Guid reservationId = _reservationService.Create(_seed.Clients[0], _seed.Offerts[5], new List<Guid> { _seed.Rooms[12], _seed.Rooms[13] });

        Reservation? reservation = _reservationService.Get(reservationId);
        Assert.NotNull(reservation);

        Assert.Equal(_seed.Clients[0], reservation.ClientId);
        Assert.Equal(_seed.Offerts[5], reservation.OffertId);
    }
    [Fact]
    public void Create_Fail()
    {
        Assert.Throws<ArgumentException>( () => _reservationService.Create(Guid.Empty, Guid.Empty, new List<Guid>()) );
    }
#endregion

#region Get
    [Fact]
    public void Get_Success()
    {
        Reservation? reservation = _reservationService.Get(_seed.Reservations[0]);
        Assert.NotNull(reservation);
    }
    [Fact]
    public void Get_Fail()
    {
        Reservation? reservation = _reservationService.Get(Guid.Empty);
        Assert.Null(reservation);
    }
#endregion

#region Update
    [Fact]
    public void Update_Success()
    {
        _reservationService.Update(_seed.Reservations[0], status: ReservationStatus.Paid);

        Reservation? reservation = _reservationService.Get(_seed.Reservations[0]);
        Assert.Equal(ReservationStatus.Paid, reservation.Status);
    }
    [Fact]
    public void Update_Fail()
    {
        Assert.Throws<ArgumentException>( () => _reservationService.Update(Guid.Empty, status: ReservationStatus.Paid));
    }
#endregion

#region Remove
    [Fact]
    public void Remove_Success()
    {
        Guid reservationId = _reservationService.Create(_seed.Clients[2], _seed.Offerts[5], new List<Guid> { _seed.Rooms[10], _seed.Rooms[11] });
        _reservationService.Remove(reservationId);

        Reservation? reservation = _reservationService.Get(reservationId);
        Assert.Null(reservation);
    }
    [Fact]
    public void Remove_Fail()
    {
        Assert.Throws<ArgumentException>( () => _reservationService.Remove(Guid.Empty));
    }
#endregion

}
