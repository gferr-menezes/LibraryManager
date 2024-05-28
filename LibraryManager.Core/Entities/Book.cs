using LibraryManager.Core.Enums;

namespace LibraryManager.Core.Entities;

public class Book : BaseEntity
{
    public string Title { get; private set; } = default!;
    public string Author { get; private set; } = default!;
    public string ISBN { get; private set; } = default!;
    public int PublicationYear { get; private set; }
    public BookStatusEnum Status { get; private set; } = BookStatusEnum.Available;
    public List<Loan> Loans { get; private set; } = new List<Loan>();

    public Book(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }

    public Book()
    {
    }

}
