using Dignite.CarMarketplace.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Dignite.CarMarketplace;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(CarMarketplaceEntityFrameworkCoreTestModule)
    )]
public class CarMarketplaceDomainTestModule : AbpModule
{

}
