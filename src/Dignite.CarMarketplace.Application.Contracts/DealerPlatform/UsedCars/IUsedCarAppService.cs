using Dignite.CarMarketplace.UsedCars;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public interface IUsedCarAppService
        : ICrudAppService<
        UsedCarDto,
        Guid,
        GetUsedCarsInput,
        UsedCarCreateDto,
        UsedCarUpdateDto>
    {
        Task SetStatusAsync(Guid id, UsedCarStatus status);
    }
}
