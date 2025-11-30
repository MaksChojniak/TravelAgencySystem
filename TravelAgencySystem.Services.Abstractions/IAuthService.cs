using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IAuthService
{
    Guid CreateAccount(string username, string password);
    AuthCredential? Login(string username, string password);
    // void RequestPasswordReset(string username);
    // void ChangePassword(string username, string password);
}