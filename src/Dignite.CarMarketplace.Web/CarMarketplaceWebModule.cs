﻿using Dignite.CarMarketplace.Localization;
using Dignite.CarMarketplace.Web.Menus;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Ui.LayoutHooks;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Dignite.CarMarketplace.Web.Pages.CarMarketplace.Shared.Components.HtmlHead;

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

        Configure<RouteOptions>(options =>
        {
            options.ConstraintMap.Add("dealerNameConstraint", typeof(DealerNameConstraint));
        });

        Configure<CarMarketplaceUrlOptions>(options =>
        {
            var bundlingOptions = context.Services.GetRequiredService<IOptions<AbpBundlingOptions>>().Value;
            if (bundlingOptions.Mode != BundlingMode.None)
            {
                options.IgnoredPaths.Add(bundlingOptions.BundleFolderName);
            }

            options.IgnoredPaths.AddRange(new[]
            {
                    "error", "ApplicationConfigurationScript", "ServiceProxyScript", "Languages/Switch",
                    "ApplicationLocalizationScript"
                });
        });

        Configure<RazorPagesOptions>(options =>
        {
            var urlOptions = context.Services
                .GetRequiredServiceLazy<IOptions<CarMarketplaceUrlOptions>>()
                .Value.Value;

            var routePrefix = urlOptions.RoutePrefix;

            options.Conventions.AddPageRoute("/CarMarketplace/Index", routePrefix);
            options.Conventions.AddPageRoute("/CarMarketplace/Dealers/Index", routePrefix + "dealer");
            options.Conventions.AddPageRoute("/CarMarketplace/Dealers/Register", routePrefix + "dealer/register");
            options.Conventions.AddPageRoute("/CarMarketplace/Dealers/Home", routePrefix + "dealer/{shortName:dealerNameConstraint}");
            options.Conventions.AddPageRoute("/CarMarketplace/SaleUsedCar/Index", routePrefix + "sale-used-car");
            options.Conventions.AddPageRoute("/CarMarketplace/UsedCars/Index", routePrefix + "used-car");
            options.Conventions.AddPageRoute("/CarMarketplace/UsedCars/Detail", routePrefix + "used-car/{id:Guid}");

            options.Conventions.AuthorizePage("/CarMarketplace/Dealers/Register");
        });
        Configure<AbpLayoutHookOptions>(options =>
        {
            options.Add(
                LayoutHooks.Head.First, //The hook name
                typeof(HtmlHeadViewComponent), //The component to add
                layout: StandardLayouts.Public
            );
        });
    }
}
