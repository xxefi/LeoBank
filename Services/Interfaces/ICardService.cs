using LeoBank.Models;

namespace LeoBank.Services.Interfaces;

public interface ICardService
{
    Card GenerateCard(int userId);
}