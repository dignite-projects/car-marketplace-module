using Dignite.CarMarketplace.UsedCars;
using System;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public class GetUsedCarsInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }

        public UsedCarStatus? Status { get; set; }
    }
}
