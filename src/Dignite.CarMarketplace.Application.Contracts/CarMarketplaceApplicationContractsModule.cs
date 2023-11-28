using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Dignite.CmsKit;
using Dignite.CmsKit.Public;
using Dignite.FileExplorer;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule),
    typeof(DigniteCmsKitPublicApplicationContractsModule),
    typeof(FileExplorerApplicationContractsModule)
    )]
public class CarMarketplaceApplicationContractsModule : AbpModule
{

}
