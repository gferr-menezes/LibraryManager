namespace LibraryManager.Core.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Password { get; private set; } = default!;


    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public User()
    {
    }
}
