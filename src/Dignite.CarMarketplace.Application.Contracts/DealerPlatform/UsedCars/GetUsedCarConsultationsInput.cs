using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public class GetUsedCarConsultationsInput : PagedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
