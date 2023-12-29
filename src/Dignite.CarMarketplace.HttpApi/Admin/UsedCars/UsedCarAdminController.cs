using Dignite.CarMarketplace.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Admin.UsedCars
{
    [Area(CarMarketplaceRemoteServiceConsts.AdminModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-admin/used-car")]
    public class UsedCarAdminController : CarMarketplaceController, IUsedCarAdminAppService
    {
        private IUsedCarAdminAppService _usedCarAppService;

        public UsedCarAdminController(IUsedCarAdminAppService usedCarAppService)
        {
            _usedCarAppService = usedCarAppService;
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(CarMarketplacePermissions.UsedCars.Management)]
        public async Task DeleteAsync(Guid id)
        {
            await _usedCarAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(CarMarketplacePermissions.UsedCars.Management)]
        public async Task<UsedCarDto> GetAsync(Guid id)
        {
            return await _usedCarAppService.GetAsync(id);
        }

        [HttpGet]
        [Authorize(CarMarketplacePermissions.UsedCars.Management)]
        public async Task<PagedResultDto<UsedCarDto>> GetListAsync(GetUsedCarsInput input)
        {
            return await _usedCarAppService.GetListAsync(input);
        }
    }
}
