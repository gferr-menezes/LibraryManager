using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LibraryManager.Infrastructure.Persistence;

public class LibaryManagerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<LibraryManagerDbContext>
{
    public LibraryManagerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibraryManagerDbContext>();
        
        var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";
        
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));

        return new LibraryManagerDbContext(optionsBuilder.Options);
    }
}
