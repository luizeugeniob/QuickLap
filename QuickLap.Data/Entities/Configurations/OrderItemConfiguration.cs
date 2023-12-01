using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLap.Data.Entities.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .ToTable("OrderItems")
            .HasKey(oi => oi.Id);

        builder
            .Property(oi => oi.Quantity)
            .IsRequired();

        builder
            .HasOne<Order>()
            .WithMany(oi => oi.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        builder
            .HasOne<Product>()
            .WithMany(oi => oi.OrderItems)
            .HasForeignKey(oi => oi.ProductId);
    }
}
