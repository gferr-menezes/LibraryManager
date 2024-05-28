using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Persistence.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(c => c.Id)
             .HasColumnName("id")
             .HasColumnType("char(36)")
             .IsRequired();

        builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

        builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(100)")
                .IsRequired();

        builder.Property(c => c.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(100)")
                .IsRequired();

        builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

        builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime")
                .IsRequired();

    }
}

