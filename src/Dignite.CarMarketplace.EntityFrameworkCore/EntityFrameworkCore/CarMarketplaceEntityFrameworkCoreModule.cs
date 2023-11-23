using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.Users;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Dignite.CarMarketplace.EntityFrameworkCore;

[DependsOn(
    typeof(CarMarketplaceDomainModule),
    typeof(AbpUsersEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class CarMarketplaceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CarMarketplaceDbContext>(options =>
        {
            options.AddRepository<CarUser, EfCoreCarUserRepository>();
            options.AddRepository<Brand, EfCoreBrandRepository>();
            options.AddRepository<ConfigurationItem, EfCoreConfigurationItemRepository>();
            options.AddRepository<Model, EfCoreModelRepository>();
            options.AddRepository<Trim, EfCoreTrimRepository>();
            options.AddRepository<Dealer, EfCoreDealerRepository>();
            options.AddRepository<UsedCar, EfCoreUsedCarRepository>();
        });
    }
}
