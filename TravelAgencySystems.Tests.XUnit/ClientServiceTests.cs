using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Tests.XUnit;

namespace TravelAgencySystems.Tests.XUnit;

public class ClientServiceTests : IClassFixture<InMemoryServicesFixture>
{
    readonly IClientService _clientService;

    readonly SeedResult _seed;

    public ClientServiceTests(InMemoryServicesFixture fx)
    {
        _clientService = fx.ClientService;
        
        _seed = fx.Seed;
    }

#region Get
    [Fact]
    public void Get_Success()
    {
        Client? client = _clientService.Get(_seed.Clients[0]);
        Assert.NotNull(client);
    }
    [Fact]
    public void Get_Fail()
    {
        Client? client = _clientService.Get(Guid.Empty);
        Assert.Null(client);
    }
#endregion

#region Update
    [Fact]
    public void Update_Success()
    {
        string newFirstName = "UpdatedFirstName";
        string newLastName = "UpdatedLastName";

        _clientService.Update(_seed.Clients[0], firstName: newFirstName, lastName: newLastName);

        Client? updatedClient = _clientService.Get(_seed.Clients[0]);
        Assert.NotNull(updatedClient);
        Assert.Equal(newFirstName, updatedClient.FirstName);
        Assert.Equal(newLastName, updatedClient.LastName);
    }
#endregion

#region GetAllReservations
    [Fact]
    public void GetAllReservations_Success()
    {
        var reservations = _clientService.GetAllReservations(_seed.Clients[3]);
        Assert.Empty(reservations);
        // Assert.NotEmpty(reservations);
    }
#endregion

}