using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public class GetBuyUsedCarsInput : PagedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
