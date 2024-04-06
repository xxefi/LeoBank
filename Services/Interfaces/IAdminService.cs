using LeoBank.Models;

namespace LeoBank.Services.Interfaces;

public interface IAdminService
{
    bool AdminLogin(string login, string password);
    Admin AdminRegister(string login, string password);
}