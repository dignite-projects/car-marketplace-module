using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public interface ISaleUsedCarPublicAppService : IApplicationService
    {
        Task<SaleCarDto> CreateAsync(SaleCarCreateDto input);
    }
}
