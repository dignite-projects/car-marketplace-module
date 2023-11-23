using Dignite.CarMarketplace.Cars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class UsedCarAppService : CarMarketplaceAppService, IUsedCarAppService
    {
        private readonly IUsedCarRepository  _usedCarRepository;

        public UsedCarAppService(IUsedCarRepository usedCarRepository)
        {
            _usedCarRepository = usedCarRepository;
        }

        public async Task<UsedCarDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UsedCar, UsedCarDto>(
                await _usedCarRepository.GetAsync(id)
                );
        }

        public async Task<PagedResultDto<UsedCarDto>> GetListAsync(GetUsedCarsInput input)
        {
            var count = await _usedCarRepository.GetCountAsync(CarStatus.Listing,input.Filter,
                input.BrandId,input.ModelId,input.DealerId,input.Color,
                input.MinRegistrationDate,input.MaxRegistrationDate,
                input.MinTotalMileage,input.MaxTotalMileage,
                input.MinPrice,input.MaxPrice,
                input.TransmissionType,input.PowerType,input.ModelLevel);

            var result = await _usedCarRepository.GetListAsync(CarStatus.Listing, input.Filter,
                input.BrandId, input.ModelId, input.DealerId, input.Color,
                input.MinRegistrationDate, input.MaxRegistrationDate,
                input.MinTotalMileage, input.MaxTotalMileage,
                input.MinPrice, input.MaxPrice,
                input.TransmissionType, input.PowerType, input.ModelLevel,
                input.MaxResultCount,input.SkipCount,input.Sorting);
            return new PagedResultDto<UsedCarDto>(
                count,
                ObjectMapper.Map<List<UsedCar>, List<UsedCarDto>>(result)
                );
        }
    }
}
