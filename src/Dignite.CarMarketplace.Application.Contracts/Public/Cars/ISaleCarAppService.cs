using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.Cars
{
    public interface ISaleCarAppService : IApplicationService
    {
        Task<SaleCarDto> CreateAsync(SaleCarCreateDto input);
    }
}
