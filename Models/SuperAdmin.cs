using System.ComponentModel.DataAnnotations;

namespace LeoBank.Models;

public class SuperAdmin
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
}