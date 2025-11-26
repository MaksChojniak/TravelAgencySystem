using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IAuthService<T>
{
    T? Login(string username, string password);
    T? CreateAccount(string username, string password);
    void RequestPasswordReset(string username);
    void ChangePassword(string username, string password);
}