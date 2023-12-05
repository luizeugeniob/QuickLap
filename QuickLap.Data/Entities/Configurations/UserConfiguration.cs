using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLap.Data.Entities.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users")
            .HasKey(u => u.Id);

        builder
            .HasIndex(u => u.Email)
            .IsUnique();

        builder
            .Property(u => u.FirstName)
            .IsRequired(false)
            .HasMaxLength(100);

        builder
            .Property(u => u.LastName)
            .IsRequired(false)
            .HasMaxLength(100);

        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);
    }
}
