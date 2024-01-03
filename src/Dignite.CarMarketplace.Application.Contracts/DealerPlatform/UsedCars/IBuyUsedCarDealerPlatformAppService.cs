using System;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public interface IBuyUsedCarDealerPlatformAppService : IReadOnlyAppService<
        BuyUsedCarDto,
        Guid,
        GetBuyUsedCarsInput>
    {
    }
}
