using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Tests.XUnit;

namespace TravelAgencySystems.Tests.XUnit;

public class AuthServiceTests : IClassFixture<InMemoryServicesFixture>
{
    readonly IAuthService _clientAuthService;

    readonly SeedResult _seed;

    public AuthServiceTests(InMemoryServicesFixture fx)
    {
        _clientAuthService = fx.ClientAuthService;
        
        _seed = fx.Seed;
    }

#region CreateAccount
    [Fact]
    public void Create_Success()
    {
        Guid clientId = _clientAuthService.CreateAccount("maks", "maks");

        AuthCredential? credential = _clientAuthService.Login("maks", "maks");
        Assert.NotNull(credential);
    }
    [Fact]
    public void Create_Fail()
    {
        Assert.Throws<AuthException>( () => _clientAuthService.CreateAccount("client1", "pass1"));
    }
#endregion

#region Login
    [Fact]
    public void Login_Success()
    {
        AuthCredential? credential = _clientAuthService.Login("client1", "pass1");
        Assert.NotNull(credential);
    }
    [Fact]
    public void Login_Fail()
    {
        Assert.Throws<AuthException>( () => _clientAuthService.CreateAccount("client1", "pass2"));
    }
#endregion

}
