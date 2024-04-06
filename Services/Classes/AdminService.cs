using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Interfaces;

namespace LeoBank.Services.Classes;

public class AdminService : IAdminService
{
    private readonly LeobankDbContext _context;

    public AdminService(LeobankDbContext context)
    {
        _context = context;
    }

    public bool AdminLogin(string login, string password)
    {
        Admin admin = _context.Admins.FirstOrDefault(a => a.Name == login);
        if (admin != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, admin.Password);
        }
        return false;
    }

    public Admin AdminRegister(string login, string password)
    {
        Admin admin = new Admin
        {
            Name = login,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
        };
        return admin;
    }
}