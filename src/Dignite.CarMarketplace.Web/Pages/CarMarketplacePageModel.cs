using Dignite.CarMarketplace.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dignite.CarMarketplace.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CarMarketplacePageModel : AbpPageModel
{
    protected CarMarketplacePageModel()
    {
        LocalizationResourceType = typeof(CarMarketplaceResource);
        ObjectMapperContext = typeof(CarMarketplaceWebModule);
    }
}
