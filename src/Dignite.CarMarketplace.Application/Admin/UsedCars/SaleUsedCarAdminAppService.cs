using Dignite.CarMarketplace.Permissions;
using Dignite.CarMarketplace.UsedCars;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Admin.UsedCars
{
    public class SaleUsedCarAdminAppService : CarMarketplaceAppService, ISaleUsedCarAdminAppService
    {
        private readonly ISaleUsedCarRepository _saleCarRepository;

        public SaleUsedCarAdminAppService(ISaleUsedCarRepository saleCarRepository)
        {
            _saleCarRepository = saleCarRepository;
        }


        [Authorize(CarMarketplacePermissions.SaleCars.Management)]
        public async Task<SaleUsedCarDto> GetAsync(Guid id)
        {
            var entity = await _saleCarRepository.GetAsync(id);
            return ObjectMapper.Map<SaleUsedCar, SaleUsedCarDto>(entity);
        }

        [Authorize(CarMarketplacePermissions.SaleCars.Management)]
        public async Task<PagedResultDto<SaleUsedCarDto>> GetListAsync(GetSaleUsedCarsInput input)
        {
            var count = await _saleCarRepository.GetCountAsync();
            var result = await _saleCarRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, null, true);
            return new PagedResultDto<SaleUsedCarDto>(count, ObjectMapper.Map<List<SaleUsedCar>, List<SaleUsedCarDto>>(result));
        }
    }
}
