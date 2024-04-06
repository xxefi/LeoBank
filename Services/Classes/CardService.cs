using LeoBank.Context;
using LeoBank.Models;
using LeoBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoBank.Services.Classes
{
    public class CardService : ICardService
    {
        private readonly LeobankDbContext _context;

        public CardService(LeobankDbContext context)
        {
            _context = context;
        }

        public Card GenerateCard(int userId)
        {
            Random random = new();
            string cardNumber = "40985844" + random.Next(10000000, 99999999).ToString();
            cardNumber = cardNumber.Insert(4, " ");
            cardNumber = cardNumber.Insert(9, " ");
            cardNumber = cardNumber.Insert(14, " ");

            int expiryMonth = random.Next(1, 13);
            int expiryYear = DateTime.Now.Year + random.Next(0, 5);
            string expiryDateString = expiryMonth.ToString("00") + "/" + (expiryYear % 100).ToString("00");
            DateTimeOffset expiryDate = DateTimeOffset.ParseExact(expiryDateString, "MM/yy", System.Globalization.CultureInfo.InvariantCulture);
            string PIN = random.Next(1000, 10000).ToString();
            string CVV = random.Next(100, 1000).ToString();

            var card = new Card
            {
                UserId = userId,
                CardNumber = cardNumber,
                ExpiryDate = expiryDate,
                CVV = CVV,
                PIN = PIN
            }; 
            return card;
        }
    }
}
