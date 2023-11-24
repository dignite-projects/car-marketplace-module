using Dignite.CarMarketplace.Cars;
using System;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.DealerPlatform.Cars
{
    public class GetUsedCarsInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }


        public CarStatus? Status { get; set; }
    }
}
