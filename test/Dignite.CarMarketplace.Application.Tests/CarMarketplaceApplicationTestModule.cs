using Volo.Abp.Modularity;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceApplicationModule),
    typeof(CarMarketplaceDomainTestModule)
    )]
public class CarMarketplaceApplicationTestModule : AbpModule
{

}
