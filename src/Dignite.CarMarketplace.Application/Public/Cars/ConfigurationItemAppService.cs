using Dignite.CarMarketplace.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class ConfigurationItemAppService : CarMarketplaceAppService, IConfigurationItemAppService
    {
        private readonly IConfigurationItemRepository  _configurationItemRepository;

        public ConfigurationItemAppService(IConfigurationItemRepository configurationItemRepository)
        {
            _configurationItemRepository = configurationItemRepository;
        }

        public async Task<ListResultDto<ConfigurationItemDto>> GetListAsync()
        {
            var result = await _configurationItemRepository.GetListAsync();
            return new ListResultDto<ConfigurationItemDto>(
                ObjectMapper.Map<List<ConfigurationItem>, List<ConfigurationItemDto>>(result)
                );
        }
    }
}
