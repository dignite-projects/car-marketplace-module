using Dignite.CarMarketplace.BlobStoring;
using Dignite.CarMarketplace.Public.Cars;
using Dignite.CarMarketplace.Public.Dealers;
using Dignite.CarMarketplace.Public.UsedCars;
using Dignite.FileExplorer.Files;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dignite.CarMarketplace.Web.Pages.UsedCars
{
    public class DetailModel : CarMarketplacePageModel
    {
        private readonly IUsedCarAppService _usedCarAppService;
        private readonly IFileDescriptorAppService _fileDescriptorAppService;
        private readonly ITrimConfigItemAppService _trimConfigItemAppService;
        private readonly ITrimAppService _trimAppService;

        public DetailModel(
            IUsedCarAppService usedCarAppService, 
            IFileDescriptorAppService fileDescriptorAppService, 
            ITrimConfigItemAppService trimConfigItemAppService, 
            ITrimAppService trimAppService)
        {
            _usedCarAppService = usedCarAppService;
            _fileDescriptorAppService = fileDescriptorAppService;
            _trimConfigItemAppService = trimConfigItemAppService;
            _trimAppService = trimAppService;
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public UsedCarDto UsedCar { get; set; }
        public DealerDto Dealer { get; set; }
        public IReadOnlyList<TrimConfigItemDto> ConfigItems { get; set; }
        public string[] ConfigGroups { get; set; }
        public TrimDto Trim { get; set; }
        public BuyUsedCarCreateDto BuyUsedCarCreateInput { get; set; }

        public FileContainerConfigurationDto CarPicContainerConfiguration { get; set; }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            CarPicContainerConfiguration = await _fileDescriptorAppService.GetFileContainerConfigurationAsync(BlobContainerConsts.CarPicsContainerName);
            UsedCar = await _usedCarAppService.GetAsync(Id);
            Trim = await _trimAppService.GetAsync(UsedCar.TrimId);
            ConfigItems = await GetTrimConfigurationItems(Trim);
            ConfigGroups = ConfigItems.Select(m => m.Group).Distinct().ToArray();
            BuyUsedCarCreateInput = new BuyUsedCarCreateDto(Id);

            return Page();
        }

        private async Task<IReadOnlyList<TrimConfigItemDto>> GetTrimConfigurationItems(TrimDto trim)
        {
            var trimConfigurationItems=new List<TrimConfigItemDto>();
            var allConfigurationItems = (await _trimConfigItemAppService.GetListAsync()).Items;
            foreach (var exp in trim.ExtraProperties)
            {
                trimConfigurationItems.Add(allConfigurationItems.Single(ci => ci.Name == exp.Key));
            }
            return trimConfigurationItems;
        }
    }
}
