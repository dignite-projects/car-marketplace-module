using Dignite.CarMarketplace.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Dignite.CarMarketplace;

public abstract class CarMarketplaceController : AbpControllerBase
{
    protected CarMarketplaceController()
    {
        LocalizationResource = typeof(CarMarketplaceResource);
    }
}
