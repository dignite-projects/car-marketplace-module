using Dignite.CarMarketplace.Cars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class TrimAppService : CarMarketplaceAppService, ITrimAppService
    {
        private readonly ITrimRepository  _trimRepository;

        public TrimAppService(ITrimRepository trimRepository)
        {
            _trimRepository = trimRepository;
        }

        public async Task<TrimDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Trim, TrimDto>(
                await _trimRepository.GetAsync(id)
                );
        }

        public async Task<PagedResultDto<TrimDto>> GetListAsync(GetTrimsInput input)
        {
            var result = await _trimRepository.GetListByModelAsync(input.ModelId);
            return new PagedResultDto<TrimDto>(
                result.Count,
                ObjectMapper.Map<List<Trim>, List<TrimDto>>(result)
                );
        }
    }
}
