using Dignite.CarMarketplace.Cars;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ListResultDto<ModelCompanyDto>> GetListAsync(GetModelsInput input)
        {
            var result = await _modelRepository.GetListByBrandAsync(input.BrandId);
            var modelCompanies = result.GroupBy(r => r.Group).Select(g => new ModelCompanyDto { 
                Name = g.Key,
                Models = g.Select(m=>new ModelDto() { 
                    Id  = m.Id,
                    Name = m.Name
                }).ToList()
            }).ToList();


            return new ListResultDto<ModelCompanyDto>(
                modelCompanies
                );
        }
    }
}
