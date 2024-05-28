using LibraryManager.Core.Interfaces;
using LibraryManager.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryManagerDbContext _context;

    public UnitOfWork(LibraryManagerDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}