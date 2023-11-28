using Dignite.CmsKit;
using Dignite.FileExplorer;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Users;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpUsersDomainModule),
    typeof(CarMarketplaceDomainSharedModule),
    typeof(DigniteCmsKitDomainModule),
    typeof(FileExplorerDomainModule)
)]
public class CarMarketplaceDomainModule : AbpModule
{

}
