using Dignite.CarMarketplace.DealerPlatform.Dealers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dignite.CarMarketplace.Web.Pages.Dealers
{
    public class RegisterModel : CarMarketplacePageModel
    {
        private readonly IDealerAppService _dealerAppService;

        public RegisterModel(IDealerAppService dealerAppService)
        {
            _dealerAppService = dealerAppService;
        }

        [BindProperty]
        public DealerCreateDto DealerCreateInput { get; set; }= new DealerCreateDto();

        public DealerDto CurrentDealer { get; set; }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            CurrentDealer = await _dealerAppService.FindByCurrentUserAsync();

            if (CurrentDealer.AuthenticationStatus == CarMarketplace.Dealers.AuthenticationStatus.Approved)
            {
                return Redirect("/dealer-platform");
            }
            else
                return Page();
        }

        public virtual async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dealer = await _dealerAppService.CreateAsync(DealerCreateInput);

            return RedirectToPage("/Dealers/Register");
        }
    }
}
