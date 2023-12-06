using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dignite.CarMarketplace.Cars
{
    /// <summary>
    /// 汽车品牌
    /// </summary>
    public class Brand: CreationAuditedEntity<Guid>
    {
        protected Brand()
        {
        }

        public Brand(Guid id, string name, string firstLetter, int number)
            : base(id)
        {
            Name = name;
            FirstLetter = firstLetter;
            Number = number;
        }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 首字母
        /// </summary>
        public string FirstLetter { get; set; }

        /// <summary>
        /// 对应原始数据源的数字编号
        /// </summary>
        public int Number { get; protected set; }

    }
}
