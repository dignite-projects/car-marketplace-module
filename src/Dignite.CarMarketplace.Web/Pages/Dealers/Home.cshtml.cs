using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dignite.CarMarketplace.Web.Pages.Dealers
{
    public class HomeModel : CarMarketplacePageModel
    {
        [BindProperty(SupportsGet = true)]
        public string DealerShortName { get; set; }

        public void OnGet()
        {
        }
    }
}
