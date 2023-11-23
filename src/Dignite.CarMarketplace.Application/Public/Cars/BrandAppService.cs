using Dignite.CarMarketplace.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class BrandAppService : CarMarketplaceAppService, IBrandAppService
    {
        private readonly IBrandRepository  _brandRepository;

        public BrandAppService(IBrandRepository brandRepository)
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
