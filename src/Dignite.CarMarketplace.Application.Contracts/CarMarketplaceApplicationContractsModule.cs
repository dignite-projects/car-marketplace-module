using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Dignite.CmsKit;
using Dignite.CmsKit.Public;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule),
    typeof(DigniteCmsKitPublicApplicationContractsModule)
    )]
public class CarMarketplaceApplicationContractsModule : AbpModule
{

}
