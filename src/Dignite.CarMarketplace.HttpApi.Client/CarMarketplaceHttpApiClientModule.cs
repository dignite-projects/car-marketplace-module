using Dignite.CmsKit.Public;
using Dignite.FileExplorer;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceApplicationContractsModule),
    typeof(AbpHttpClientModule),
    typeof(DigniteCmsKitPublicHttpApiClientModule),
    typeof(FileExplorerHttpApiClientModule))]
public class CarMarketplaceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CarMarketplaceApplicationContractsModule).Assembly,
            CarMarketplaceRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CarMarketplaceHttpApiClientModule>();
        });

    }
}
