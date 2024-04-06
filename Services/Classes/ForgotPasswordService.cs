using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Interfaces;

namespace LeoBank.Services.Classes;

public class ForgotPasswordService : IForgotPasswordService
{
    private readonly LeobankDbContext _context;

    public ForgotPasswordService(LeobankDbContext context)
    {
        _context = context;
    }

    public User ForgotPassword(string FIN, string phone, string password)
    {
        User user = _context.Users.FirstOrDefault(u => u.FIN == FIN && u.Phone == phone);
        if (user != null)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
        }
        return user;
    }
}