using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dignite.CarMarketplace.EntityFrameworkCore;

public class CarMarketplaceHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CarMarketplaceHttpApiHostMigrationsDbContext>
{
    public CarMarketplaceHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CarMarketplaceHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("CarMarketplace"));

        return new CarMarketplaceHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
