using Microsoft.AspNetCore.Mvc;

namespace Dignite.CarMarketplace.Web.Pages.Dealers
{
    public class HomeModel : CarMarketplacePageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ShortName { get; set; }

        public void OnGet()
        {
        }
    }
}
