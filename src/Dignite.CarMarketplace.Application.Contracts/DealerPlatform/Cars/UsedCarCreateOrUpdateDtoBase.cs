using Dignite.CarMarketplace.Cars;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Dignite.CarMarketplace.DealerPlatform.Cars
{
    public abstract class UsedCarCreateOrUpdateDtoBase
    {
        /// <summary>
        /// 车款Id
        /// </summary>
        [Required]
        public Guid TrimId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(UsedCarConsts), nameof(UsedCarConsts.MaxNameLength))]
        public string Name { get; set; }

        /// <summary>
        /// 车辆情况描述
        /// </summary>
        [DynamicStringLength(typeof(UsedCarConsts), nameof(UsedCarConsts.MaxDescriptionLength))]
        public string Description { get; set; }

        [Required]
        public CarStatus Status { get; set; }

        /// <summary>
        /// 注册日期\初次上牌日期
        /// </summary>
        [Required]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// 万公里
        /// </summary>
        [Required]
        public float TotalMileage { get; set; }

        /// <summary>
        /// 过户次数
        /// </summary>
        [Required]
        public int TransfersCount { get; set; }

        /// <summary>
        /// 交强险过期日期
        /// </summary>
        public DateTime? CompulsoryInsuranceExpirationDate { get; set; }

        /// <summary>
        /// 商业险过期日期
        /// </summary>
        public DateTime? CommercialInsuranceExpirationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DynamicStringLength(typeof(UsedCarConsts), nameof(UsedCarConsts.MaxColorLength))]
        public string? Color { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }
    }
}
