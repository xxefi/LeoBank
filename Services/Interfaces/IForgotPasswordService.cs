using LeoBank.Models;

namespace LeoBank.Services.Interfaces;

public interface IForgotPasswordService
{
    User ForgotPassword(string FIN, string phone, string password);
}