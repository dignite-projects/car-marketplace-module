using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dignite.CarMarketplace.Public.Cars
{
    [Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-public/sale-car")]
    public class SaleCarController : CarMarketplaceController, ISaleCarAppService
    {
        private readonly ISaleCarAppService _saleCarAppService;

        public SaleCarController(ISaleCarAppService saleCarAppService)
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
