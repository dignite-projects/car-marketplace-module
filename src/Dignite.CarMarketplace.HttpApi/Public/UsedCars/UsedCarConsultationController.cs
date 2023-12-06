using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    [Area(CarMarketplaceRemoteServiceConsts.DealerPlatformModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-dealer-platform/used-car-consultation")]
    public class UsedCarConsultationController : CarMarketplaceController, IUsedCarConsultationAppService
    {
        private readonly IUsedCarConsultationAppService _usedCarConsultationAppService;

        public UsedCarConsultationController(IUsedCarConsultationAppService usedCarConsultationAppService)
        {
            _usedCarConsultationAppService = usedCarConsultationAppService;
        }

        [HttpPost]
        public async Task<UsedCarConsultationDto> CreateAsync(UsedCarConsultationCreateDto input)
        {
            return await _usedCarConsultationAppService.CreateAsync(input);
        }
    }
}
