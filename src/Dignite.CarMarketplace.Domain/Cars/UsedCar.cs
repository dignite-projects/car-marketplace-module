using Dignite.CarMarketplace.Dealers;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Dignite.CarMarketplace.Cars
{
    /// <summary>
    /// 二手车辆信息
    /// </summary>
    public class UsedCar: FullAuditedEntity<Guid>, IMultiTenant
    {
        protected UsedCar()
        {
        }

        public UsedCar(Guid id, int usedCarId,  Trim trim, string name, string description, Guid dealerId, DateTime registrationDate, 
            float totalMileage, int transfersCount, DateTime? compulsoryInsuranceExpirationDate, DateTime? commercialInsuranceExpirationDate, 
            string color, float price, Guid? tenantId)
            :base(id)
        {
            UsedCarId = usedCarId;
            BrandId = trim.Model.BrandId;
            ModelId = trim.ModelId;
            TrimId = trim.Id;
            Name = name;
            Description = description;
            DealerId = dealerId;
            RegistrationDate = registrationDate;
            TotalMileage = totalMileage;
            TransfersCount = transfersCount;
            CompulsoryInsuranceExpirationDate = compulsoryInsuranceExpirationDate;
            CommercialInsuranceExpirationDate = commercialInsuranceExpirationDate;
            Color = color;
            Price = price;
            TenantId = tenantId;
        }

        /// <summary>
        /// 车源编号
        /// </summary>
        public int UsedCarId { get; set; }

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

        public CarStatus Status { get; protected set; }

        /// <summary>
        /// 商家Id
        /// </summary>
        public Guid DealerId { get; protected set; }

        public Dealer Dealer { get; protected set; }

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
        public DateTime? CompulsoryInsuranceExpirationDate { get; set; }

        /// <summary>
        /// 商业险过期日期
        /// </summary>
        public DateTime? CommercialInsuranceExpirationDate { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }

        /*
        /// <summary>
        /// 排放标准
        /// </summary>
        public string EmissionStandard { get; set; }
        */

        /// <summary>
        /// 变速箱类型
        /// </summary>
        public string TransmissionType { get; protected set; }

        /// <summary>
        /// 动力类型
        /// </summary>
        public string PowerType { get; protected set; }

        /// <summary>
        /// 车型级别(Suv\MPV\豪华车等等)
        /// </summary>
        public string ModelLevel { get; protected set; }

        public int ViewCount { get; protected set; }

        public int FavoriteCount { get; protected set; }

        public virtual Guid? TenantId { get; protected set; }

        public void SetConfig(Trim trim)
        {
            var transmissionType = trim.GetProperty<string>("m_transtype").Trim();
            TransmissionType = transmissionType=="MT"?"手动档":"自动档";
            PowerType = trim.GetProperty<string>("m_dynamic").Trim();
            ModelLevel = trim.GetProperty<string>("type_name").Trim();
        }

        public void SetStatus(CarStatus status)
        {
            Status = status;
        }
        public void UpdateInternal(Trim trim, string name, string description, DateTime registrationDate, float totalMileage, int transfersCount, DateTime? compulsoryInsuranceExpirationDate, DateTime? commercialInsuranceExpirationDate, string color, float price)            
        {
            BrandId = trim.Model.BrandId;
            ModelId = trim.ModelId;
            TrimId = trim.Id;
            Name = name;
            Description = description;
            RegistrationDate = registrationDate;
            TotalMileage = totalMileage;
            TransfersCount = transfersCount;
            CompulsoryInsuranceExpirationDate = compulsoryInsuranceExpirationDate;
            CommercialInsuranceExpirationDate = commercialInsuranceExpirationDate;
            Color = color;
            Price = price;
        }
    }
}
