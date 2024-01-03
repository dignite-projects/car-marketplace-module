using Microsoft.AspNetCore.Mvc;
using Dignite.CarMarketplace.Public.Dealers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
using Dignite.CarMarketplace.Public.UsedCars;

namespace Dignite.CarMarketplace.Web.Pages.Dealers
{
    public class HomeModel : CarMarketplacePageModel
    {
        private readonly IDealerPublicAppService _dealerAppService;
        private readonly IUsedCarPublicAppService _usedCarAppService;

        public HomeModel(IDealerPublicAppService dealerAppService, IUsedCarPublicAppService usedCarAppService)
        {
            _dealerAppService = dealerAppService;
            _usedCarAppService = usedCarAppService;
        }

        [BindProperty(SupportsGet = true)]
        public string ShortName { get; set; }

        public DealerDto Dealer { get; set; }


        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public IReadOnlyList<UsedCarDto> UsedCars { get; set; }


        public GetUsedCarsInput GetUsedCarsInput { get; set; } = new GetUsedCarsInput();
        public PagerModel PagerModel { get; private set; }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            GetUsedCarsInput.MaxResultCount = 9;
            Dealer = await _dealerAppService.FindByShortNameAsync(ShortName);

            GetUsedCarsInput.SkipCount = (CurrentPage - 1) * GetUsedCarsInput.MaxResultCount;
            GetUsedCarsInput.DealerId = Dealer.Id;
            var pagedResult = await _usedCarAppService.GetListAsync(GetUsedCarsInput);
            UsedCars = pagedResult.Items;
            foreach (var item in UsedCars)
            {
                item.Dealer = Dealer;
            }
            PagerModel = new PagerModel(pagedResult.TotalCount, 10, CurrentPage, GetUsedCarsInput.MaxResultCount, Request.Path);

            return Page();
        }
    }
}
