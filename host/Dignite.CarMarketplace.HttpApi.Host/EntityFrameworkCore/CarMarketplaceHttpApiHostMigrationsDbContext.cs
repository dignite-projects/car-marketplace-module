using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.EntityFrameworkCore;

public class CarMarketplaceHttpApiHostMigrationsDbContext : AbpDbContext<CarMarketplaceHttpApiHostMigrationsDbContext>
{
    public CarMarketplaceHttpApiHostMigrationsDbContext(DbContextOptions<CarMarketplaceHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCarMarketplace();
    }
}
