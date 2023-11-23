using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CarMarketplaceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CarMarketplaceConsoleApiClientModule : AbpModule
{

}
