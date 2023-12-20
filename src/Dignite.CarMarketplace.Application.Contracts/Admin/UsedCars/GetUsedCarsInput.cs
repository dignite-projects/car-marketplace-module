using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Admin.UsedCars
{
    public class GetUsedCarsInput : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 车源编号
        /// </summary>
        public int? UsedCarId { get; set; }
    }
}
