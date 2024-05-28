using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Persistence.Mappings;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasColumnName("id")
               .HasColumnType("char(36)")
               .IsRequired();

        builder.Property(b => b.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(100)")
                .IsRequired();

        builder.Property(b => b.Author)
                .HasColumnName("author")
                .HasColumnType("varchar(100)")
                .IsRequired();

        builder.Property(b => b.ISBN)
                .HasColumnName("isbn")
                .HasColumnType("varchar(13)");

        builder.HasIndex(b => b.ISBN)
                .IsUnique();

        builder.Property(b => b.PublicationYear)
                .HasColumnName("publication_year")
                .HasColumnType("int")
                .IsRequired();

        builder.Property(b => b.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .IsRequired();

        builder.Property(b => b.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

        builder.Property(b => b.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime")
                .IsRequired();

        builder.HasMany(b => b.Loans)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
