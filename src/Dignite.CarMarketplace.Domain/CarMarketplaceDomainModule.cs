using Dignite.CarMarketplace.Cars;
using Dignite.CmsKit;
using Dignite.FileExplorer;
using Volo.Abp.Domain;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Modularity;
using Volo.Abp.Users;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Tags;

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

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        if (GlobalFeatureManager.Instance.IsEnabled<TagsFeature>())
        {
            Configure<CmsKitTagOptions>(options =>
            {
                options.EntityTypes.Add(new TagEntityTypeDefiniton(UsedCarConsts.EntityType));
            });
        }
    }
}
