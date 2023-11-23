using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dignite.CarMarketplace.Cars
{
    /// <summary>
    /// 汽车品牌下的车型
    /// </summary>
    public class Model : CreationAuditedEntity<Guid>
    {
        public Model(Guid id, Guid brandId, Brand brand, string group, string name, int number)
            : base(id)
        {
            BrandId = brandId;
            Brand = brand;
            Group = group;
            Name = name;
            Number = number;
        }

        protected Model()
        {
        }

        public Guid BrandId { get; set; }

        public Brand Brand { get; set; }

        /// <summary>
        /// 比如一汽奥迪\进口奥迪等
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 车型名称,比如A4L\A8L
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对应原始数据源的数字编号
        /// </summary>
        public int Number { get; protected set; }
    }
}
