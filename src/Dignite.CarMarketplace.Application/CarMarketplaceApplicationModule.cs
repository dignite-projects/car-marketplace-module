using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Microsoft.AspNetCore.Authorization;
using Dignite.CarMarketplace.DealerPlatform.Dealers;
using Dignite.CmsKit.Public;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceDomainModule),
    typeof(CarMarketplaceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(DigniteCmsKitPublicApplicationModule)
    )]
public class CarMarketplaceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CarMarketplaceApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CarMarketplaceApplicationModule>(validate: true);
        });

        Configure<AuthorizationOptions>(options =>
        {
            options.AddPolicy("CarMarketplaceUpdatePolicy", policy => policy.Requirements.Add(CommonOperations.Update));
            options.AddPolicy("CarMarketplaceDeletePolicy", policy => policy.Requirements.Add(CommonOperations.Delete));
            options.AddPolicy("UsedCarManagePolicy", policy => policy.Requirements.Add(CommonOperations.UsedCarManage));
        });

        context.Services.AddSingleton<IAuthorizationHandler, DealerAuthorizationHandler>();
    }
}
