using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLap.Data.Entities.Configurations;

public class EntityOneConfiguration : IEntityTypeConfiguration<EntityOne>
{
    public void Configure(EntityTypeBuilder<EntityOne> builder)
    {
        builder
            .ToTable("EntityOnes")
            .HasKey(e => e.Id);

        builder
            .HasOne<Customer>()
            .WithMany(e => e.EntityOnes)
            .HasForeignKey(e => e.CustomerId);
    }
}
