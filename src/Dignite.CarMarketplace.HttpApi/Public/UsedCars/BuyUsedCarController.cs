using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    [Area(CarMarketplaceRemoteServiceConsts.DealerPlatformModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-public/buy-used-car")]
    public class BuyUsedCarController : CarMarketplaceController, IBuyUsedCarAppService
    {
        private readonly IBuyUsedCarAppService _usedCarConsultationAppService;

        public BuyUsedCarController(IBuyUsedCarAppService usedCarConsultationAppService)
        {
            _usedCarConsultationAppService = usedCarConsultationAppService;
        }

        [HttpPost]
        public async Task<BuyUsedCarDto> CreateAsync(BuyUsedCarCreateDto input)
        {
            return await _usedCarConsultationAppService.CreateAsync(input);
        }
    }
}
