using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    [Area(CarMarketplaceRemoteServiceConsts.DealerPlatformModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-public/buy-used-car")]
    public class BuyUsedCarPublicController : CarMarketplaceController, IBuyUsedCarPublicAppService
    {
        private readonly IBuyUsedCarPublicAppService _usedCarConsultationAppService;

        public BuyUsedCarPublicController(IBuyUsedCarPublicAppService usedCarConsultationAppService)
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
