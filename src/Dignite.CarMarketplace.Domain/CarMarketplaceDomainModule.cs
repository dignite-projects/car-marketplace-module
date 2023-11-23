using Dignite.CmsKit;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Users;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpUsersDomainModule),
    typeof(CarMarketplaceDomainSharedModule),
    typeof(DigniteCmsKitDomainModule)
)]
public class CarMarketplaceDomainModule : AbpModule
{

}
