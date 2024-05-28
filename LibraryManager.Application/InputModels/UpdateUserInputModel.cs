namespace LibraryManager.Application.InputModels;

public class UpdateUserInputModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Password { get; set; }
}
