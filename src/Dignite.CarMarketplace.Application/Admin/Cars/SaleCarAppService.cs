using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Admin.Cars
{
    public class SaleCarAppService : CarMarketplaceAppService, ISaleCarAppService
    {
        private readonly ISaleCarRepository _saleCarRepository;

        public SaleCarAppService(ISaleCarRepository saleCarRepository)
        {
            _saleCarRepository = saleCarRepository;
        }


        [Authorize(CarMarketplacePermissions.SaleCars.Management)]
        public async Task<SaleCarDto> GetAsync(Guid id)
        {
            var entity = await _saleCarRepository.GetAsync(id);
            return ObjectMapper.Map<SaleCar, SaleCarDto>(entity);
        }

        [Authorize(CarMarketplacePermissions.SaleCars.Management)]
        public async Task<PagedResultDto<SaleCarDto>> GetListAsync(GetSaleCarsInput input)
        {
            var count = await _saleCarRepository.GetCountAsync();
            var result = await _saleCarRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount,null,true);
            return new PagedResultDto<SaleCarDto>(count, ObjectMapper.Map<List<SaleCar>, List<SaleCarDto>>(result));
        }
    }
}
