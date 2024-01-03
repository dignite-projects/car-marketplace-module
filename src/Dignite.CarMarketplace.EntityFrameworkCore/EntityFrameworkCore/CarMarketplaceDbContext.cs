using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.UsedCars;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.EntityFrameworkCore;

[ConnectionStringName(CarMarketplaceDbProperties.ConnectionStringName)]
public class CarMarketplaceDbContext : AbpDbContext<CarMarketplaceDbContext>, ICarMarketplaceDbContext
{
    public DbSet<Dealer> Dealer { get; set; }
    public DbSet<DealerAdministrator> DealerAdministrator { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Model> Model { get; set; }
    public DbSet<Trim> Trim { get; set; }
    public DbSet<TrimConfigItem> ConfigurationItem { get; set; }
    public DbSet<UsedCar> UsedCar { get; set; }
    public DbSet<SaleUsedCar> SaleCar { get; set; }
    public DbSet<BuyUsedCar> UsedCarConsultations { get; set; }    

    public CarMarketplaceDbContext(DbContextOptions<CarMarketplaceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCarMarketplace();
    }
}
