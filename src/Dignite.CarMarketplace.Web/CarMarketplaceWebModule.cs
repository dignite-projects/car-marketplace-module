using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Dignite.CarMarketplace.Localization;
using Dignite.CarMarketplace.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Dignite.CarMarketplace.Permissions;

namespace Dignite.CarMarketplace.Web;

[DependsOn(
    typeof(CarMarketplaceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
    )]
public class CarMarketplaceWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(CarMarketplaceResource), typeof(CarMarketplaceWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CarMarketplaceWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new CarMarketplaceMenuContributor());
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CarMarketplaceWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<CarMarketplaceWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CarMarketplaceWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
                //Configure authorization.
            });
    }
}
