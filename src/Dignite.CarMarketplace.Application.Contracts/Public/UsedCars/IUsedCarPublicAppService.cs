using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public interface IUsedCarPublicAppService : IReadOnlyAppService<UsedCarDto, Guid, GetUsedCarsInput>
    {
        Task<List<string>> GetAllModelColorsAsync();
        Task<List<string>> GetAllModelLevelsAsync();
    }
}
