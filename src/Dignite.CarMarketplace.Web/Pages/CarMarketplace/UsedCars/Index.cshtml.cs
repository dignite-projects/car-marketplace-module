using Dignite.CarMarketplace.Public.Cars;
using Dignite.CarMarketplace.Public.UsedCars;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace Dignite.CarMarketplace.Web.Pages.UsedCars
{
    public class IndexModel : CarMarketplacePageModel
    {
        private readonly IBrandAppService _brandAppService;
        private readonly IModelAppService _modelAppService;
        private readonly IUsedCarAppService _usedCarAppService;

        public IndexModel(IBrandAppService brandAppService, IModelAppService modelAppService, IUsedCarAppService usedCarAppService)
        {
            _brandAppService = brandAppService;
            _modelAppService = modelAppService;
            _usedCarAppService = usedCarAppService;
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public GetUsedCarsInput GetUsedCarsInput { get; set; }=new GetUsedCarsInput();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public IReadOnlyList<UsedCarDto> UsedCars { get; set; }

        public IReadOnlyList<BrandDto> AllBrands { get; set; }
        public IReadOnlyList<ModelCompanyDto> AllModels { get; set; }
        public IReadOnlyList<string> AllModelLevels {  get; set; }
        public IReadOnlyList<string> AllModelColors { get; set; }
        public IReadOnlyDictionary<string,string> PriceRanges { get; set; }
        public IReadOnlyDictionary<string, string> MileageRanges { get; set; }
        public IReadOnlyDictionary<string, string> PopularTags { get; set; }
        public IReadOnlyDictionary<string, string> Sorts { get; set; }
        public PagerModel PagerModel { get; private set; }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            GetUsedCarsInput.MaxResultCount = 30;
            AllBrands = (await _brandAppService.GetListAsync()).Items;
            AllModelLevels = await _usedCarAppService.GetAllModelLevelsAsync();
            AllModelColors = await _usedCarAppService.GetAllModelColorsAsync();
            PriceRanges= new Dictionary<string,string>() 
            {
                ["1万以下"]="0-10000",
                ["1万至3万"] = "10000-30000",
                ["3万至5万"] = "30000-50000",
                ["5万至8万"] = "50000-80000",
                ["8万至10万"] = "80000-100000",
                ["10万至15万"] = "100000-150000",
                ["15万至20万"] = "150000-200000",
                ["20万至30万"] = "200000-300000",
                ["30万至50万"] = "300000-500000",
                ["50万以上"] = "500000-100000000"
            };
            MileageRanges = new Dictionary<string, string>()
            {
                ["1万公里以下"] = "0-10000",
                ["1万公里至5万公里"] = "10000-50000",
                ["5万公里至10万公里"] = "50000-100000",
                ["10万公里至20万公里"] = "100000-200000",
                ["20万公里以上"] = "200000-500000"
            };
            if (GetUsedCarsInput.BrandId.HasValue)
            {
                AllModels = (await _modelAppService.GetListAsync(new GetModelsInput { BrandId = GetUsedCarsInput.BrandId.Value }))
                    .Items;
            }

            PopularTags = new Dictionary<string, string>()
            {
                ["推荐"] = "",
                ["准新车"] = "准新车",
                ["急售车型"] = "急售车型",
                ["奥迪认证车"] = "奥迪认证车",
            };

            Sorts = new Dictionary<string, string>()
            {
                ["默认"] = "",
                ["最新上架"] = "CreationTime",
                ["查看次数最多"] = "ViewCount",
                ["最受喜爱的"] = "FavoriteCount"
            };


            GetUsedCarsInput.SkipCount = (CurrentPage - 1) * GetUsedCarsInput.MaxResultCount;
            var pagedResult = await _usedCarAppService.GetListAsync(GetUsedCarsInput);
            UsedCars = pagedResult.Items;
            PagerModel = new PagerModel(pagedResult.TotalCount, 10, CurrentPage, GetUsedCarsInput.MaxResultCount, Request.Path);

            return Page();
        }
    }
}
