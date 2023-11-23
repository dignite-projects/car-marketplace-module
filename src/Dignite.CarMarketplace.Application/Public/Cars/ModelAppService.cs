using Dignite.CarMarketplace.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class ModelAppService : CarMarketplaceAppService, IModelAppService
    {
        private readonly IModelRepository  _modelRepository;

        public ModelAppService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<ListResultDto<ModelDto>> GetListAsync(GetModelsInput input)
        {
            var result = await _modelRepository.GetListByBrandAsync(input.BrandId);
            return new ListResultDto<ModelDto>(
                ObjectMapper.Map<List<Model>, List<ModelDto>>(result)
                );
        }
    }
}
