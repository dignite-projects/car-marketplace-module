using Dignite.CarMarketplace.Dealers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Dealers
{
    public class DealerAppService : CarMarketplaceAppService, IDealerAppService
    {
        private readonly IDealerRepository _dealerRepository;

        public DealerAppService(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        public async Task<DealerDto> FindByShortNameAsync(string shortName)
        {
            var entity = await _dealerRepository.FindByShortNameAsync(shortName, false);
            return ObjectMapper.Map<Dealer, DealerDto>(entity);
        }

        public async Task<DealerDto> GetAsync(Guid id)
        {
            var entity = await _dealerRepository.GetAsync(id, false);
            return ObjectMapper.Map<Dealer, DealerDto>(entity);
        }

        public async Task<PagedResultDto<DealerDto>> GetListAsync(GetDealersInput input)
        {
            var count = await _dealerRepository.GetCountAsync(input.Filter, AuthenticationStatus.Approved);
            var result = await _dealerRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, AuthenticationStatus.Approved);
            return new PagedResultDto<DealerDto>(count, ObjectMapper.Map<List<Dealer>, List<DealerDto>>(result));
        }
    }
}
