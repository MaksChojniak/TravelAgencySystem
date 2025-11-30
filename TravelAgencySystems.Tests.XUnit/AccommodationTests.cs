using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Tests.XUnit;

namespace TravelAgencySystems.Tests.XUnit;

public class AccommodationTests : IClassFixture<InMemoryServicesFixture>
{
    readonly IAccomodationService _accomodationService;

    readonly SeedResult _seed;

    public AccommodationTests(InMemoryServicesFixture fx)
    {
        _accomodationService = fx.AccomodationService;
        
        _seed = fx.Seed;
    }

#region Create
    [Fact]
    public void Create_Success()
    {
        Guid accomodationId = _accomodationService.Create("Name", "Address", 1);

        Accomodation? accomodation = _accomodationService.Get(accomodationId);
        Assert.NotNull(accomodation);

        Assert.Equal("Name", accomodation.Name);
        Assert.Equal("Address", accomodation.Address);
        Assert.Equal(1, accomodation.Stars);

        _accomodationService.Remove(accomodationId);
    }
    [Fact]
    public void Create_Fail()
    {
        Assert.Throws<ArgumentException>( () => _accomodationService.Create("Grand Hotel", "Gdansk ul.nieznana 15", 1));
    }
#endregion

#region Get
    [Fact]
    public void Get_Success()
    {
        Accomodation? accomodation = _accomodationService.Get(_seed.Accomodations[0]);
        Assert.NotNull(accomodation);
    }
    [Fact]
    public void Get_Fail()
    {
        Accomodation? accomodation = _accomodationService.Get(Guid.Empty);
        Assert.Null(accomodation);
    }
#endregion

#region GetAll
    [Fact]
    public void GetAll_Success()
    {
        var accomodations = _accomodationService.GetAll();
        Assert.NotEmpty(accomodations);

        Assert.Equal(4, accomodations.Count);
        Assert.Contains(accomodations, a => a.Id == _seed.Accomodations[0]);
    }
#endregion

#region GetRooms
    [Fact]
    public void GetRooms_Success()
    {
        var rooms = _accomodationService.GetRooms(_seed.Accomodations[0]);
        Assert.NotEmpty(rooms);

        Assert.Equal(4, rooms.Count);
        Assert.Equal(129, rooms[0].Number);
        Assert.Equal(_seed.Accomodations[0], rooms[0].AccomodationId);
    }
#endregion

#region GetAllAvaiableRooms
    [Fact]
    public void GetAllAvaiableRooms_Success()
    {
        var rooms = _accomodationService.GetAvaiableRooms(_seed.Accomodations[0]);
        Assert.NotEmpty(rooms);

        Assert.Equal(2, rooms.Count);
        Assert.Contains(rooms, r => r.Number == 111);
        Assert.Equal(_seed.Accomodations[0], rooms[0].AccomodationId);
        Assert.True(rooms.All(r => r.IsAvailable));
    }
#endregion

#region Update
    [Fact]
    public void Update_Success()
    {
        _accomodationService.Update(_seed.Accomodations[0], "New Name");

        Accomodation? accomodation = _accomodationService.Get(_seed.Accomodations[0]);
        Assert.Equal("New Name", accomodation.Name);
    }
    [Fact]
    public void Update_Fail()
    {
        Assert.Throws<ArgumentException>( () => _accomodationService.Update(Guid.Empty, "New Name"));
    }
#endregion

#region Remove
    [Fact]
    public void Remove_Success()
    {
        Guid accomodationId = _accomodationService.Create("Test Name", "Address", 1);
        _accomodationService.Remove(accomodationId);

        Accomodation? accomodation = _accomodationService.Get(accomodationId);
        Assert.Null(accomodation);
    }
    [Fact]
    public void Remove_Fail()
    {
        Assert.Throws<ArgumentException>( () => _accomodationService.Remove(Guid.Empty));
    }
#endregion

}
