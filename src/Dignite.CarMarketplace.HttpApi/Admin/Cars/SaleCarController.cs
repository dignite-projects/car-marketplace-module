using Dignite.CarMarketplace.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Admin.Cars
{
    [Area(CarMarketplaceRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/car-marketplace-admin/sale-car")]
    public class SaleCarController : CarMarketplaceController, ISaleCarAppService
    {
        private readonly ISaleCarAppService _saleCarAppService;

        public SaleCarController(ISaleCarAppService saleCarAppService)
        {
            _saleCarAppService = saleCarAppService;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(CarMarketplacePermissions.SaleCars.Management)]
        public async Task<SaleCarDto> GetAsync(Guid id)
        {
            return await _saleCarAppService.GetAsync(id);
        }

        [HttpGet]
        [Authorize(CarMarketplacePermissions.SaleCars.Management)]
        public async Task<PagedResultDto<SaleCarDto>> GetListAsync(GetSaleCarsInput input)
        {
            return await _saleCarAppService.GetListAsync(input);
        }
    }
}
