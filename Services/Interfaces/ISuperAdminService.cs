namespace LeoBank.Services.Interfaces;

public interface ISuperAdminService
{
    bool SuperAdminLogin(string login, string password);
}