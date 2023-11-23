using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Public.Dealers;
using System;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class UsedCarDto: CreationAuditedEntityDto<Guid>
    {
        /// <summary>
        /// 汽车品牌Id
        /// </summary>
        public Guid BrandId { get; set; }

        /// <summary>
        /// 车型Id
        /// </summary>
        public Guid ModelId { get; set; }

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
        /// 商家Id
        /// </summary>
        public Guid DealerId { get; protected set; }

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
