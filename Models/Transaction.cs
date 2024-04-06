using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeoBank.Models;

public class Transaction
{
    [Key]
    public string TransactionId { get; set; } = Guid.NewGuid().ToString();
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User Users { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Status { get; set; }
    
}