using Dignite.Abp.BlobStoring;
using Dignite.CarMarketplace.AspNetCore.BlobStoring;
using Dignite.CarMarketplace.BlobStoring;
using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace Dignite.CarMarketplace.AspNetCore
{
    [DependsOn(
    typeof(CarMarketplaceApplicationModule)
    )]
    public class CarMarketplaceAspNetCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBlobStoringOptions>(options =>
            {
                options.Containers
                    .Configure<CarPicsBlobContainer>(container =>
                    {
                        container.SetBlobNameGenerator<UsedCarCellPicBlobNameGenerator>();
                    });
            });
        }
    }
}
