using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Tests.XUnit;

namespace TravelAgencySystems.Tests.XUnit;

public class CarrierServiceTests : IClassFixture<InMemoryServicesFixture>
{
    readonly ICarrierService _carrierService;

    readonly SeedResult _seed;

    public CarrierServiceTests(InMemoryServicesFixture fx)
    {
        _carrierService = fx.CarrierService;
        
        _seed = fx.Seed;
    }

#region Create
    [Fact]
    public void Create_Success()
    {
        Guid carrierId = _carrierService.Create("New Carrier", TypeOfTransport.Bus, 50, "CityA", "CityB", 29.99);

        Carrier? carrier = _carrierService.Get(carrierId);
        Assert.NotNull(carrier);
    }
    [Fact]
    public void Create_Fail()
    {
        Assert.Throws<ArgumentException>( () => _carrierService.Create(string.Empty, TypeOfTransport.Bus, 50, "CityA", "CityB", 29.99));
    }
#endregion

#region Get
    [Fact]
    public void Get_Success()
    {
        Carrier? carrier = _carrierService.Get(_seed.Carriers[0]);
        Assert.NotNull(carrier);
    }
    [Fact]
    public void Get_Fail()
    {
        Carrier? carrier = _carrierService.Get(Guid.Empty);
        Assert.Null(carrier);
    }
#endregion

#region GetAll
    [Fact]
    public void GetAll_Success()
    {
        var carriers = _carrierService.GetAll();
        Assert.NotEmpty(carriers);
    }
#endregion

#region Update
    [Fact]
    public void Update_Success()
    {
        Guid carrierId = _seed.Carriers[0];
        Carrier? beforeUpdate = _carrierService.Get(carrierId);
        Assert.NotNull(beforeUpdate);
        double oldPrice = beforeUpdate.Price;

        _carrierService.Update(carrierId, price: oldPrice + 10);

        Carrier? afterUpdate = _carrierService.Get(carrierId);
        Assert.NotNull(afterUpdate);
        Assert.Equal(oldPrice + 10, afterUpdate.Price);
    }
    [Fact]
    public void Update_Fail()
    {
        Assert.Throws<ArgumentException>( () => _carrierService.Update(Guid.Empty, 129.99));
    }
#endregion

#region Remove
    [Fact]
    public void Remove_Success()
    {
        Guid carrierId = _carrierService.Create("Temp Carrier", TypeOfTransport.Train, 100, "CityX", "CityY", 49.99);

        Carrier? carrier = _carrierService.Get(carrierId);
        Assert.NotNull(carrier);

        _carrierService.Remove(carrierId);

        Carrier? deletedCarrier = _carrierService.Get(carrierId);
        Assert.Null(deletedCarrier);
    }
    [Fact]
    public void Remove_Fail()
    {
        Assert.Throws<ArgumentException>( () => _carrierService.Remove(Guid.Empty));
    }
#endregion

}
