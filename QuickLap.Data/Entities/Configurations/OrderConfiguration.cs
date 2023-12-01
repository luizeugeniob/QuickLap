using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLap.Data.Entities.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .ToTable("Orders")
            .HasKey(o => o.Id);

        builder
            .Property(o => o.CreationDate)
            .IsRequired();

        builder
            .HasOne<Customer>()
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.CustomerId);
    }
}
