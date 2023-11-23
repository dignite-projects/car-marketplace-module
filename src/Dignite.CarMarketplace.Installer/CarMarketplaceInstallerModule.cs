using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class CarMarketplaceInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CarMarketplaceInstallerModule>();
        });
    }
}
