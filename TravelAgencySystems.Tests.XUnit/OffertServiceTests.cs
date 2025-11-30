using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Tests.XUnit;

namespace TravelAgencySystems.Tests.XUnit;

public class OffertServiceTests : IClassFixture<InMemoryServicesFixture>
{
    readonly IOffertService _offertService;

    readonly SeedResult _seed;

    public OffertServiceTests(InMemoryServicesFixture fx)
    {
        _offertService = fx.OffertService;
        
        _seed = fx.Seed;
    }

#region Create
    [Fact]
    public void Create_Success()
    {
        Guid offertId = _offertService.Create(_seed.Employees[0], "Sample Offert", DateTime.Now.AddDays(1), TimeSpan.FromDays(7), _seed.Carriers[0], _seed.Accomodations[0]);

        Offert? offert = _offertService.Get(offertId);
        Assert.NotNull(offert);
    }
    [Fact]
    public void Create_Fail()
    {
        Assert.Throws<ArgumentException>( () => _offertService.Create(Guid.Empty, "Sample Offert", DateTime.Now.AddDays(1), TimeSpan.FromDays(7), _seed.Carriers[0], _seed.Accomodations[0]));
    }
#endregion

#region Get
    [Fact]
    public void Get_Success()
    {
        Offert? offert = _offertService.Get(_seed.Offerts[0]);
        Assert.NotNull(offert);
    }
    [Fact]
    public void Get_Fail()
    {
        Offert? offert = _offertService.Get(Guid.Empty);
        Assert.Null(offert);
    }
#endregion

#region GetAll
    [Fact]
    public void GetAll_Success()
    {
        var offerts = _offertService.GetAll();
        Assert.NotEmpty(offerts);
    }
#endregion

#region Search
    [Fact]
    public void Search_Success()
    {
        var offerts = _offertService.Search(DateTime.Now, DateTime.Now + TimeSpan.FromDays(9));
        Assert.NotEmpty(offerts);
        Assert.Contains(offerts, o => o.Title == "Train Offert To Czestochowa");
    }
#endregion

#region FreeSpaces
    [Fact]
    public void FreeSpaces_Success()
    {
        int freeSpaces = _offertService.FreeSpaces(_seed.Offerts[5]);
        Assert.Equal(13, freeSpaces);
    }
#endregion

#region Remove
    [Fact]
    public void Remove_Success()
    {
        Guid offertId = _offertService.Create(_seed.Employees[0], "Temp Offert", DateTime.Now, TimeSpan.FromDays(3), _seed.Carriers[0], _seed.Accomodations[0]);

        Offert? offert = _offertService.Get(offertId);
        Assert.NotNull(offert);

        _offertService.Remove(offertId);

        Offert? deletedOffert = _offertService.Get(offertId);
        Assert.Null(deletedOffert);
    }
#endregion

}