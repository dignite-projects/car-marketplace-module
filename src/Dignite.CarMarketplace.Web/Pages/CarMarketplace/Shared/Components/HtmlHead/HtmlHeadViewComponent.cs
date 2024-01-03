using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dignite.CarMarketplace.Web.Pages.CarMarketplace.Shared.Components.HtmlHead
{
    public class HtmlHeadViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Pages/CarMarketplace/Shared/Components/HtmlHead/Default.cshtml");
        }
    }
}
