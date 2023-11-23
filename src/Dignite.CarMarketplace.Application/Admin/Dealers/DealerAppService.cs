using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Admin.Dealers
{
    public class DealerAppService : CarMarketplaceAppService, IDealerAppService
    {
        private readonly IDealerRepository _dealerRepository;

        public DealerAppService(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task Authenticate(Guid id,AuthenticationStatus status)
        {
            var entity = await _dealerRepository.GetAsync(id);
            entity.SetAuthenticationStatus(status);
            await _dealerRepository.UpdateAsync(entity);
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task DeleteAsync(Guid id)
        {
            await _dealerRepository.DeleteAsync(id);
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task<DealerDto> GetAsync(Guid id)
        {
            var entity = await _dealerRepository.GetAsync(id);
            return ObjectMapper.Map<Dealer, DealerDto>(entity);
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task<PagedResultDto<DealerDto>> GetListAsync(GetDealersInput input)
        {
            var count = await _dealerRepository.GetCountAsync(input.Filter,input.AuthenticationStatus);
            var result = await _dealerRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, input.AuthenticationStatus);
            return new PagedResultDto<DealerDto>(count, ObjectMapper.Map<List<Dealer>, List<DealerDto>>(result));
        }
    }
}
