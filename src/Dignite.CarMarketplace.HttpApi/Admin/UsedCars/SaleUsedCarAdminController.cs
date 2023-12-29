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
    [Route("api/car-marketplace-admin/sale-used-car")]
    public class SaleUsedCarAdminController : CarMarketplaceController, ISaleUsedCarAdminAppService
    {
        private readonly ISaleUsedCarAdminAppService _saleCarAppService;

        public SaleUsedCarAdminController(ISaleUsedCarAdminAppService saleCarAppService)
        {
            _saleCarAppService = saleCarAppService;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(CarMarketplacePermissions.SaleCars.Management)]
        public async Task<SaleUsedCarDto> GetAsync(Guid id)
        {
            return await _saleCarAppService.GetAsync(id);
        }

        [HttpGet]
        [Authorize(CarMarketplacePermissions.SaleCars.Management)]
        public async Task<PagedResultDto<SaleUsedCarDto>> GetListAsync(GetSaleUsedCarsInput input)
        {
            return await _saleCarAppService.GetListAsync(input);
        }
    }
}
