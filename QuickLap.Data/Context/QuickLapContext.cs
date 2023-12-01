using Microsoft.EntityFrameworkCore;
using QuickLap.Data.Entities;
using QuickLap.Data.Entities.Configurations;

namespace QuickLap.Data.Context;

public class QuickLapContext : DbContext
{
    public QuickLapContext(DbContextOptions<QuickLapContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}