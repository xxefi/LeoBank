using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoBank.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string CardNumber { get; set; }
        [Required]
        public DateTimeOffset ExpiryDate { get; set; }
        [Required]
        public string CVV { get; set; }
        [Required]
        public string PIN { get; set; }
    }
}
