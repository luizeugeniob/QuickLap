using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLap.Data.Entities.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .ToTable("Customers")
            .HasKey(c => c.Id);

        builder
            .HasIndex(c => c.Email)
            .IsUnique();

        builder
            .Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}
