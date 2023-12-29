using Dignite.CarMarketplace.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class BrandPublicAppService : CarMarketplaceAppService, IBrandPublicAppService
    {
        private readonly IBrandRepository  _brandRepository;

        public BrandPublicAppService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<ListResultDto<BrandDto>> GetListAsync()
        {
            var result = await _brandRepository.GetListAsync(false);
            return new ListResultDto<BrandDto>(
                ObjectMapper.Map<List<Brand>, List<BrandDto>>(result)
                );
        }
    }
}
