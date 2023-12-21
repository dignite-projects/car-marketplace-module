using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    [Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-public/sale-used-car")]
    public class SaleUsedCarController : CarMarketplaceController, ISaleUsedCarAppService
    {
        private readonly ISaleUsedCarAppService _saleCarAppService;

        public SaleUsedCarController(ISaleUsedCarAppService saleCarAppService)
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
