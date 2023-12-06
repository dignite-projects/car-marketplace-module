using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
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

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<UsedCarConsultationDto> GetAsync(Guid id)
        {
            return await _usedCarConsultationAppService.GetAsync(id);
        }

        [HttpGet]
        [Authorize]
        public async Task<PagedResultDto<UsedCarConsultationDto>> GetListAsync(GetUsedCarConsultationsInput input)
        {
            return await _usedCarConsultationAppService.GetListAsync(input);
        }
    }
}
