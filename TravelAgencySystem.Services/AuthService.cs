using TravelAgencySystem.DataModel;
using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using System.Data.Common;

namespace TravelAgencySystem.Services.Abstractions;

public class AuthService<T> : IAuthService<T> where T : Person, new()
{
    readonly IRepository<AuthCredential> _credentials;
    readonly IRepository<T> _people;
    
    readonly IDbContext _db;

    public AuthService(IRepository<AuthCredential> credentialRepository, IRepository<T> personRepository, IDbContext db)
    {
        _credentials = credentialRepository;
        _people = personRepository;
        _db = db;
    }

    public T? CreateAccount(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            throw new AuthException(AuthErrorCode.EmptyUsernameOrPassword);

        if (_credentials.Query().Any(c => c.Username == username))
            throw new AuthException(AuthErrorCode.AccountExists);

        var credential = new AuthCredential()
        {
            PersonId = Guid.NewGuid(),
            Username = username,
            Password = password

        };

        T client = new()
        {
            Id = credential.PersonId,
        };

        _credentials.Add(credential);
        _people.Add(client);
        _db.SaveChanges();

        return client;
    }

    public T? Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            throw new AuthException(AuthErrorCode.EmptyUsernameOrPassword);

        AuthCredential? credential = _credentials.Query().FirstOrDefault(c => c.Username == username);
        if(credential is null)
            throw new AuthException(AuthErrorCode.WrongUsername);

        if (credential.Password != password)
            throw new AuthException(AuthErrorCode.WrongPassword);

        T? person = _people.Get(credential.PersonId);
        if(person is null)
            throw new AuthException(AuthErrorCode.PersonNotExist);

        return person;
    }
}


 public class AuthException : Exception
 {
     readonly AuthErrorCode Code;
     public AuthException(AuthErrorCode code) : base(GetMessage(code)) 
     {
         Code = code;
     }

     public static string GetMessage(AuthErrorCode code) => code switch
     {
         AuthErrorCode.EmptyUsernameOrPassword => "Empty username or password.",
         AuthErrorCode.EmptyUsername => "Empty username.",
         AuthErrorCode.WrongUsername => "Wrong username.",
         AuthErrorCode.WrongPassword => "Wrong password.",
         AuthErrorCode.AccountExists => "Account already exists.",
         AuthErrorCode.AccountNotExist => "Account does not exist.",
         AuthErrorCode.PersonNotExist => "User record does not exist.",
         AuthErrorCode.NewPasswordSameAsOld => "New password is the same as the old password.",
         _ => "Unknown authentication error."
     };

 }

 public enum AuthErrorCode
 {
     EmptyUsernameOrPassword = 1000,
     EmptyUsername= 1001,
     WrongUsername = 1002,
     WrongPassword = 1003,
     AccountExists = 1004,
     AccountNotExist = 1005,
     PersonNotExist = 1006,
     NewPasswordSameAsOld = 1007
 }