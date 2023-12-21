using Dignite.CarMarketplace.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class TrimConfigItemAppService : CarMarketplaceAppService, ITrimConfigItemAppService
    {
        private readonly ITrimConfigItemRepository  _trimConfigItemRepository;

        public TrimConfigItemAppService(ITrimConfigItemRepository trimConfigItemRepository)
        {
            _trimConfigItemRepository = trimConfigItemRepository;
        }

        public async Task<ListResultDto<TrimConfigItemDto>> GetListAsync()
        {
            var result = await _trimConfigItemRepository.GetListAsync();
            return new ListResultDto<TrimConfigItemDto>(
                ObjectMapper.Map<List<TrimConfigItem>, List<TrimConfigItemDto>>(result)
                );
        }
    }
}
