using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    [Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-public/sale-used-car")]
    public class SaleUsedCarPublicController : CarMarketplaceController, ISaleUsedCarPublicAppService
    {
        private readonly ISaleUsedCarPublicAppService _saleCarAppService;

        public SaleUsedCarPublicController(ISaleUsedCarPublicAppService saleCarAppService)
        {
            _saleCarAppService = saleCarAppService;
        }

        [HttpPost]
        public async Task<SaleCarDto> CreateAsync(SaleCarCreateDto input)
        {
            return await _saleCarAppService.CreateAsync(input);
        }
    }
}
