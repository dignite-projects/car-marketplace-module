using System;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public interface IBuyUsedCarAppService : IReadOnlyAppService<
        BuyUsedCarDto,
        Guid,
        GetBuyUsedCarsInput>
    {
    }
}
