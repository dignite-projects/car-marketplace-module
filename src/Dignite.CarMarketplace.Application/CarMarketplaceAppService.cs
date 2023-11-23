using Dignite.CarMarketplace.Localization;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace;

public abstract class CarMarketplaceAppService : ApplicationService
{
    protected CarMarketplaceAppService()
    {
        LocalizationResource = typeof(CarMarketplaceResource);
        ObjectMapperContext = typeof(CarMarketplaceApplicationModule);
    }
}
