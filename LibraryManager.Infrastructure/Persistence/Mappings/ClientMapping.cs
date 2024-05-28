using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Persistence.Mappings;

public class ClientMapping : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("clients");

        builder.HasKey(c => c.Id);

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

        builder.HasIndex(c => c.Email)
               .IsUnique();

        builder.Property(c => c.CreatedAt)
               .HasColumnName("created_at")
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(c => c.UpdatedAt)
               .HasColumnName("updated_at")
               .HasColumnType("datetime")
               .IsRequired();

        builder.HasMany(c => c.Loans)
                .WithOne(l => l.Client)
                .HasForeignKey(l => l.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
