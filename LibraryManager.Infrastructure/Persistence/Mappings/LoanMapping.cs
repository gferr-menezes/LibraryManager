using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Persistence.Mappings;

public class LoanMapping : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("loans");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
               .HasColumnName("id")
               .HasColumnType("char(36)")
               .IsRequired();

        builder.Property(l => l.ClientId)
                .HasColumnName("client_id")
                .HasColumnType("char(36)")
                .IsRequired();

        builder.Property(l => l.BookId)
                .HasColumnName("book_id")
                .HasColumnType("char(36)")
                .IsRequired();

        builder.Property(l => l.LoanDate)
                .HasColumnName("loan_date")
                .HasColumnType("datetime")
                .IsRequired();

        builder.Property(l => l.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

        builder.Property(l => l.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime")
                .IsRequired();

        builder.HasOne(l => l.Client)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Cascade);

                
    }
}
