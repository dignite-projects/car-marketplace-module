using Dignite.CarMarketplace.UsedCars;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class SaleCarCreateDto
    {

        /// <summary>
        /// 车型Id
        /// </summary>
        [Required]
        public Guid ModelId { get; set; }

        /// <summary>
        /// 车辆情况描述
        /// </summary>
        [DynamicStringLength(typeof(SaleUsedCarConsts), nameof(SaleUsedCarConsts.MaxDescriptionLength))]
        public string Description { get; set; }

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
        /// 验车地址
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(SaleUsedCarConsts), nameof(SaleUsedCarConsts.MaxAddressLength))]
        public string Address { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(SaleUsedCarConsts), nameof(SaleUsedCarConsts.MaxContactPersonLength))]
        public string ContactPerson { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(SaleUsedCarConsts), nameof(SaleUsedCarConsts.MaxContactNumberLength))]
        public string ContactNumber { get; set; }
    }
}
