using LeoBank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LeoBank.Context;

public class LeobankDbContext : DbContext
{
    public LeobankDbContext()
    {
        
    }   
    
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }    
    public DbSet<SuperAdmin> SuperAdmins { get; set; }
    public DbSet<Card> Cards { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(builder.GetConnectionString("Default"));
        }
    }

    
}