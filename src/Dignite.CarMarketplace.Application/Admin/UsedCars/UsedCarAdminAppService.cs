using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Permissions;
using Dignite.CarMarketplace.UsedCars;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.CmsKit.Tags;

namespace Dignite.CarMarketplace.Admin.UsedCars
{
    public class UsedCarAdminAppService : CarMarketplaceAppService, IUsedCarAdminAppService
    {
        private readonly IUsedCarRepository _usedCarRepository;
        private readonly ITagAppService _tagAppService;

        public UsedCarAdminAppService(IUsedCarRepository usedCarRepository, ITagAppService tagAppService)
        {
            _usedCarRepository = usedCarRepository;
            _tagAppService = tagAppService;
        }

        [Authorize(CarMarketplacePermissions.UsedCars.Management)]
        public async Task DeleteAsync(Guid id)
        {
            await _usedCarRepository.DeleteAsync(id);
        }

        [Authorize(CarMarketplacePermissions.UsedCars.Management)]
        public async Task<UsedCarDto> GetAsync(Guid id)
        {
            var usedCar = await _usedCarRepository.GetAsync(id);

            var dto = ObjectMapper.Map<UsedCar, UsedCarDto>(
                usedCar
                );

            dto.Tags = (await _tagAppService.GetAllRelatedTagsAsync(UsedCarConsts.EntityType, dto.Id.ToString()))
                .Select(t => t.Name)
                .ToList();

            return dto;
        }

        [Authorize(CarMarketplacePermissions.UsedCars.Management)]
        public async Task<PagedResultDto<UsedCarDto>> GetListAsync(GetUsedCarsInput input)
        {
            var count = await _usedCarRepository.GetCountAsync(
                usedCarId:input.UsedCarId);
            if (count > 0)
            {
                var result = await _usedCarRepository.GetListAsync(
                    true,
                    null,null,
                    input.UsedCarId,
                    skipCount: input.SkipCount,
                    maxResultCount: input.MaxResultCount,
                    sorting: input.Sorting);

                return new PagedResultDto<UsedCarDto>(count,
                    ObjectMapper.Map<List<UsedCar>, List<UsedCarDto>>(result)
                    );
            }
            else
            {
                return new PagedResultDto<UsedCarDto>(0, new List<UsedCarDto>());
            }
        }
    }
}
