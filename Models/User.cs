﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeoBank.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Login { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string FIN { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public decimal Balance { get; set; }
    [Required]
    public byte[] PhotoProfile { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}