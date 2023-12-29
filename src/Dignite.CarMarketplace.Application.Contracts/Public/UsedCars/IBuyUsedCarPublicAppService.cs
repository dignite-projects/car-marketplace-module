using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    /// <summary>
    /// 买二手车咨询
    /// </summary>
    public interface IBuyUsedCarPublicAppService : IApplicationService
    {
        Task<BuyUsedCarDto> CreateAsync(BuyUsedCarCreateDto input);
    }
}
