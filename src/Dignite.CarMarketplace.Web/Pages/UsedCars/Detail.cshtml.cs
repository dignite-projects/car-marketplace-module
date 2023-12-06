using Dignite.CarMarketplace.BlobStoring;
using Dignite.CarMarketplace.Public.Cars;
using Dignite.CarMarketplace.Public.Dealers;
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
        private readonly IConfigurationItemAppService _configurationItemAppService;
        private readonly ITrimAppService _rimAppService;

        public DetailModel(
            IUsedCarAppService usedCarAppService, 
            IFileDescriptorAppService fileDescriptorAppService, 
            IConfigurationItemAppService configurationItemAppService, 
            ITrimAppService rimAppService)
        {
            _usedCarAppService = usedCarAppService;
            _fileDescriptorAppService = fileDescriptorAppService;
            _configurationItemAppService = configurationItemAppService;
            _rimAppService = rimAppService;
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public UsedCarDto UsedCar { get; set; }
        public DealerDto Dealer { get; set; }
        public IReadOnlyList<ConfigurationItemDto> ConfigurationItems { get; set; }
        public string[] ConfigurationGroups { get; set; }
        public TrimDto Trim { get; set; }

        public FileContainerConfigurationDto CarPicContainerConfiguration { get; set; }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            CarPicContainerConfiguration = await _fileDescriptorAppService.GetFileContainerConfigurationAsync(BlobContainerConsts.CarPicsContainerName);
            UsedCar = await _usedCarAppService.GetAsync(Id);
            Trim = await _rimAppService.GetAsync(UsedCar.TrimId);
            ConfigurationItems = await GetTrimConfigurationItems(Trim);
            ConfigurationGroups = ConfigurationItems.Select(m => m.Group).Distinct().ToArray();

            return Page();
        }

        private async Task<IReadOnlyList<ConfigurationItemDto>> GetTrimConfigurationItems(TrimDto trim)
        {
            var trimConfigurationItems=new List<ConfigurationItemDto>();
            var allConfigurationItems = (await _configurationItemAppService.GetListAsync()).Items;
            foreach (var exp in trim.ExtraProperties)
            {
                trimConfigurationItems.Add(allConfigurationItems.Single(ci => ci.Name == exp.Key));
            }
            return trimConfigurationItems;
        }
    }
}
