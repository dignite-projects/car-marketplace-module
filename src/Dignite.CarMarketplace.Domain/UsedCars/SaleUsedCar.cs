using Dignite.CarMarketplace.Cars;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Dignite.CarMarketplace.UsedCars
{
    /// <summary>
    /// 用户提交的二手车辆信息
    /// </summary>
    public class SaleUsedCar : CreationAuditedEntity<Guid>, IMultiTenant
    {
        public SaleUsedCar(Guid id, Guid modelId, string description, DateTime registrationDate, float totalMileage, string address, string contactPerson, string contactNumber, Guid? tenantId)
            :base(id)
        {
            ModelId = modelId;
            Description = description;
            RegistrationDate = registrationDate;
            TotalMileage = totalMileage;
            Address = address;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            TenantId = tenantId;
        }

        protected SaleUsedCar()
        {
        }

        /// <summary>
        /// 车型Id
        /// </summary>
        public Guid ModelId { get; set; }

        public Model Model { get; set; }

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

        public virtual Guid? TenantId { get; protected set; }
    }
}
