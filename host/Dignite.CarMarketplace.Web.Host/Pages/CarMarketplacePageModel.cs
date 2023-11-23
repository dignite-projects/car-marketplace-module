using Dignite.CarMarketplace.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dignite.CarMarketplace.Pages;

public abstract class CarMarketplacePageModel : AbpPageModel
{
    protected CarMarketplacePageModel()
    {
        LocalizationResourceType = typeof(CarMarketplaceResource);
    }
}
