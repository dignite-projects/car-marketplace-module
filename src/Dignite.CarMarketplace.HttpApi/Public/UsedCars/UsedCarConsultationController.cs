using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    [Area(CarMarketplaceRemoteServiceConsts.DealerPlatformModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-dealer-platform/used-car-consultation")]
    public class UsedCarConsultationController : CarMarketplaceController, IBuyUsedCarAppService
    {
        private readonly IBuyUsedCarAppService _usedCarConsultationAppService;

        public UsedCarConsultationController(IBuyUsedCarAppService usedCarConsultationAppService)
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
