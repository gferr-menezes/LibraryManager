namespace LibraryManager.Core.Interfaces;

public interface IUnitOfWork
{
    /// <summary>
    /// Commit the changes to the database
    /// </summary>
    /// <returns></returns>
    Task<bool> CommitAsync();
}
