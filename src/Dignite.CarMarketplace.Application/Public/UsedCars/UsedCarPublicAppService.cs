using Dignite.CarMarketplace.UsedCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.CmsKit.Tags;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class UsedCarPublicAppService : CarMarketplaceAppService, IUsedCarPublicAppService
    {
        private readonly IUsedCarRepository _usedCarRepository;
        private readonly ITagAppService _tagAppService;
        private readonly EntityTagManager _entityTagManager;

        public UsedCarPublicAppService(
            IUsedCarRepository usedCarRepository,
            ITagAppService tagAppService,
            EntityTagManager entityTagManager
            )
        {
            _usedCarRepository = usedCarRepository;
            _tagAppService = tagAppService;
            _entityTagManager = entityTagManager;
        }

        public async Task<List<string>> GetAllModelColorsAsync()
        {
            return await _usedCarRepository.GetAllModelColorsAsync();
        }

        public async Task<List<string>> GetAllModelLevelsAsync()
        {
            return await _usedCarRepository.GetAllModelLevelsAsync();
        }

        public async Task<UsedCarDto> GetAsync(Guid id)
        {
            var dto = ObjectMapper.Map<UsedCar, UsedCarDto>(
                await _usedCarRepository.GetAsync(id)
                );

            dto.Tags = (await _tagAppService.GetAllRelatedTagsAsync(UsedCarConsts.EntityType, dto.Id.ToString()))
                .Select(t => t.Name)
                .ToList();

            return dto;
        }

        public async Task<PagedResultDto<UsedCarDto>> GetListAsync(GetUsedCarsInput input)
        {
            Guid[] ids = null;
            if (!input.TagName.IsNullOrEmpty())
            {
                ids = (await _entityTagManager.GetEntityIdsFilteredByTagNameAsync(input.TagName, UsedCarConsts.EntityType, CurrentTenant.Id))
                    .Select(id => Guid.Parse(id))
                    .ToArray();
            }

            var count = await _usedCarRepository.GetCountAsync(
                UsedCarStatus.Listing, input.Filter, null,
                input.BrandId, input.ModelId, input.DealerId, input.Color,
                input.MinRegistrationDate, input.MaxRegistrationDate,
                input.MinTotalMileage, input.MaxTotalMileage,
                input.MinPrice, input.MaxPrice,
                input.TransmissionType, input.PowerType, input.ModelLevel, ids);

            var result = await _usedCarRepository.GetListAsync(
                input.DealerId.HasValue ? false : true,
                UsedCarStatus.Listing, input.Filter, null,
                input.BrandId, input.ModelId, input.DealerId, input.Color,
                input.MinRegistrationDate, input.MaxRegistrationDate,
                input.MinTotalMileage, input.MaxTotalMileage,
                input.MinPrice, input.MaxPrice,
                input.TransmissionType, input.PowerType, input.ModelLevel, ids,
                input.MaxResultCount, input.SkipCount, input.Sorting);
            return new PagedResultDto<UsedCarDto>(
                count,
                ObjectMapper.Map<List<UsedCar>, List<UsedCarDto>>(result)
                );
        }
    }
}
