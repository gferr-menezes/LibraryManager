namespace LibraryManager.Core.Entities;

public class Loan : BaseEntity
{
    public Guid ClientId { get; private set; }
    public Guid BookId { get; private set; }
    public DateTime LoanDate { get; private set; }

    public Loan(Guid clientId, Guid bookId)
    {
        ClientId = clientId;
        BookId = bookId;
        LoanDate = DateTime.UtcNow;
    }

    public Loan()
    {
    }

    public Client Client { get; private set; } = default!;
    public Book Book { get; private set; } = default!;
}
