using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dignite.CarMarketplace.Cars
{
    /// <summary>
    /// 车型下的车款
    /// </summary>
    public class Trim : CreationAuditedAggregateRoot<Guid>
    {
        protected Trim()
        {
        }

        public Trim(Guid id, Guid modelId, Model model, int year, string name, int number)
            : base(id)
        {
            ModelId = modelId;
            Model = model;
            Year = year;
            Name = name;
            Number = number;
        }

        public Guid ModelId { get; set; }
        public Model Model { get; set; }

        /// <summary>
        /// 年代款
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 车款名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对应原始数据源的数字编号
        /// </summary>
        public int Number { get; protected set; }
    }
}
