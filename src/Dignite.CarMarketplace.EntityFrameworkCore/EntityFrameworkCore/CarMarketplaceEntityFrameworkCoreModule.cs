using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.UsedCars;
using Dignite.CmsKit.EntityFrameworkCore;
using Dignite.FileExplorer.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Dignite.CarMarketplace.EntityFrameworkCore;

[DependsOn(
    typeof(CarMarketplaceDomainModule),
    typeof(AbpUsersEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(DigniteCmsKitEntityFrameworkCoreModule),
    typeof(FileExplorerEntityFrameworkCoreModule)
)]
public class CarMarketplaceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CarMarketplaceDbContext>(options =>
        {
            options.AddRepository<Brand, EfCoreBrandRepository>();
            options.AddRepository<TrimConfigItem, EfCoreTrimConfigItemRepository>();
            options.AddRepository<Model, EfCoreModelRepository>();
            options.AddRepository<Trim, EfCoreTrimRepository>();
            options.AddRepository<Dealer, EfCoreDealerRepository>();
            options.AddRepository<UsedCar, EfCoreUsedCarRepository>();
            options.AddRepository<SaleUsedCar, EfCoreSaleCarRepository>();
            options.AddRepository<BuyUsedCar, EfCoreBuyUsedCarRepository>();
        });
    }
}
