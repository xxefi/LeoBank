using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Interfaces;

namespace LeoBank.Services.Classes;

public class SuperAdminService : ISuperAdminService
{
    private readonly LeobankDbContext _context;

    public SuperAdminService(LeobankDbContext context)
    {
        _context = context;
    }

    public bool SuperAdminLogin(string login, string password)
    {
        SuperAdmin superAdmin = _context.SuperAdmins.FirstOrDefault(s => s.Name == login);
        if (superAdmin != null)
        {
            return superAdmin.Password == password;
        }
        return false;
    }
}