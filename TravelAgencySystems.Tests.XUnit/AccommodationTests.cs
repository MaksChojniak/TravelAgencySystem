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

    [Fact]
    public void Create_Success()
    {
        Guid accomodationId = _accomodationService.Create("Name", "Address", 1);

        Accomodation? accomodation = _accomodationService.Get(accomodationId);
        Assert.NotNull(accomodation);

        Assert.Equal("Name", accomodation.Name);
        Assert.Equal("Address", accomodation.Address);
        Assert.Equal(1, accomodation.Stars);
    }
    [Fact]
    public void Create_Fail()
    {
        Assert.Throws<ArgumentException>( () => _accomodationService.Create("Grand Hotel", "Gdansk ul.nieznana 15", 1));
    }


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


    [Fact]
    public void Remove_Success()
    {
        _accomodationService.Remove(_seed.Accomodations[0]);

        Accomodation? accomodation = _accomodationService.Get(_seed.Accomodations[0]);
        Assert.Null(accomodation);
    }
    [Fact]
    public void Remove_Fail()
    {
        Assert.Throws<ArgumentException>( () => _accomodationService.Remove(Guid.Empty));
    }

}
