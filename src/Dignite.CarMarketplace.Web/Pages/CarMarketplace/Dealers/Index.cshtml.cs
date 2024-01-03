using Dignite.CarMarketplace.Public.Dealers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace Dignite.CarMarketplace.Web.Pages.Dealers
{
    public class IndexModel : CarMarketplacePageModel
    {
        private readonly IDealerPublicAppService _dealerAppService;

        public IndexModel(IDealerPublicAppService dealerAppService)
        {
            _dealerAppService = dealerAppService;
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public GetDealersInput GetDealersInput { get; set; } = new GetDealersInput();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public IReadOnlyList<DealerDto> Dealers { get; set; }

        public PagerModel PagerModel { get; private set; }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            GetDealersInput.MaxResultCount = 9;
            GetDealersInput.SkipCount = (CurrentPage - 1) * GetDealersInput.MaxResultCount;
            var pagedResult = await _dealerAppService.GetListAsync(GetDealersInput);
            Dealers = pagedResult.Items;
            PagerModel = new PagerModel(pagedResult.TotalCount, 10, CurrentPage, GetDealersInput.MaxResultCount, Request.Path);

            return Page();
        }
    }
}
