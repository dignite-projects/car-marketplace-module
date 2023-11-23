using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class CarMarketplaceApplicationContractsModule : AbpModule
{

}
