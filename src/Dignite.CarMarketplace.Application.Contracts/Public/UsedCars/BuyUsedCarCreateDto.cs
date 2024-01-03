using Dignite.CarMarketplace.UsedCars;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class BuyUsedCarCreateDto
    {
        public BuyUsedCarCreateDto()
        {
        }

        public BuyUsedCarCreateDto(Guid usedCarId)
        {
            UsedCarId = usedCarId;
            ReservationTime = DateTime.Now.AddDays(1);
        }

        [Required]
        public Guid UsedCarId { get; set; }

        [Required]
        [DynamicStringLength(typeof(BuyUsedCarConsts), nameof(BuyUsedCarConsts.MaxContactPersonLength))]
        public string ContactPerson { get; set; }

        [Required]
        [DynamicStringLength(typeof(BuyUsedCarConsts), nameof(BuyUsedCarConsts.MaxContactNumberLength))]
        public string ContactNumber { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        [Required]
        public DateTime ReservationTime { get; set; }
    }
}
