using Dignite.CarMarketplace.Cars;
using System;

namespace Dignite.CarMarketplace.DealerPlatform.Cars
{
    public abstract class UsedCarCreateOrUpdateDtoBase
    {
        /// <summary>
        /// 车款Id
        /// </summary>
        public Guid TrimId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 车辆情况描述
        /// </summary>
        public string Description { get; set; }

        public CarStatus Status { get; set; }

        /// <summary>
        /// 注册日期\初次上牌日期
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// 万公里
        /// </summary>
        public float TotalMileage { get; set; }

        /// <summary>
        /// 过户次数
        /// </summary>
        public int TransfersCount { get; set; }

        /// <summary>
        /// 交强险过期日期
        /// </summary>
        public DateTime CompulsoryInsuranceExpirationDate { get; set; }

        /// <summary>
        /// 商业险过期日期
        /// </summary>
        public DateTime CommercialInsuranceExpirationDate { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }
    }
}
