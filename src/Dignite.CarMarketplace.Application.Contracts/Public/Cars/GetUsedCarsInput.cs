using System;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class GetUsedCarsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? ModelId { get; set; }
        public Guid? DealerId { get; set; }
        public string Color { get; set; }

        /// <summary>
        /// 上牌日期
        /// </summary>
        public DateTime? MinRegistrationDate { get; set; }
        public DateTime? MaxRegistrationDate { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        public float? MinTotalMileage { get; set; }
        public float? MaxTotalMileage { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float? MinPrice { get; set; }
        public float? MaxPrice { get; set; }

        /// <summary>
        /// 变速箱类型
        /// </summary>
        public string TransmissionType { get; set; }

        /// <summary>
        /// 动力类型
        /// </summary>
        public string PowerType { get; set; }

        /// <summary>
        /// 车型级别(Suv\MPV\豪华车等等)
        /// </summary>
        public string ModelLevel { get; set; }
    }
}
