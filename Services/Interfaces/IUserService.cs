using LeoBank.Models;

namespace LeoBank.Services.Interfaces;

public interface IUserService
{
    User GetUser(string user);
    bool UserLogin(string login, string password);
    User UserRegister(string name, string surname, string login, string email, string FIN, string phone,
        string password, byte[] photoProfile);
}