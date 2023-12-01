using Microsoft.EntityFrameworkCore;
using QuickLap.Data.Entities;
using QuickLap.Data.Entities.Configurations;

namespace QuickLap.Data.Context;

public class QuickLapContext : DbContext
{
    public QuickLapContext(DbContextOptions<QuickLapContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}