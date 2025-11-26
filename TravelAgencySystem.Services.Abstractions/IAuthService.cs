using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IAuthService<T> where T : Person, new()
{
    T? Login(string username, string password);
    T? CreateAccount(string username, string password);
    void RequestPasswordReset(string username);
    void ChangePassword(string username, string password);
}