using System;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class SaleCarDto : CreationAuditedEntityDto<Guid>
    {
        /// <summary>
        /// 车型Id
        /// </summary>
        public Guid ModelId { get; set; }

        /// <summary>
        /// 车辆情况描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 注册日期\初次上牌日期
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// 万公里
        /// </summary>
        public float TotalMileage { get; set; }

        /// <summary>
        /// 验车地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNumber { get; set; }
    }
}
