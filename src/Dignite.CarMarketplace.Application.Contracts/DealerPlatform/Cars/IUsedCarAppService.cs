using Dignite.CarMarketplace.Cars;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.DealerPlatform.Cars
{
    public interface IUsedCarAppService
        : ICrudAppService<
        UsedCarDto,
        Guid,
        GetUsedCarsInput,
        UsedCarCreateDto,
        UsedCarUpdateDto>
    {
        Task SetStatusAsync(Guid id, CarStatus status);
    }
}
