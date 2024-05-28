using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Entities;

public class Client : BaseEntity
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public Client(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public Client()
    {
    }

    public List<Loan> Loans { get; private set; } = new List<Loan>();
}
