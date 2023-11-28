using Localization.Resources.AbpUi;
using Dignite.CarMarketplace.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Dignite.CmsKit.Public;
using Dignite.FileExplorer;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(DigniteCmsKitPublicHttpApiModule),
    typeof(FileExplorerHttpApiModule))]
public class CarMarketplaceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CarMarketplaceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CarMarketplaceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
