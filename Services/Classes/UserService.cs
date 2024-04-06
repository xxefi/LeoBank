using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Interfaces;

namespace LeoBank.Services.Classes;

public class UserService : IUserService
{
    private readonly LeobankDbContext _context;

    public UserService(LeobankDbContext context)
    {
        _context = context;
    }

    public User GetUser(string user)
    {
        return _context.Users.FirstOrDefault(u => u.Email == user);
    }
    
    public User UserRegister(string name, string surname, string login, string email, string FIN, string phone, string password, byte[] photoProfile)
    {
        User user = new User
        {
            Name = name,
            Surname = surname,
            Login = login,
            Email = email,
            FIN = FIN,
            Phone = phone,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
            PhotoProfile = photoProfile,
        };
        return user;
    }

    public bool UserLogin(string email, string password)
    {
        User user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        return false;
    }
}