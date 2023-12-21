using System;
using Volo.Abp.Domain.Entities;

namespace Dignite.CarMarketplace.Cars
{
    public class TrimConfigItem:Entity<Guid>
    {
        public TrimConfigItem(Guid id, string group, string name, string displayName) : base(id)
        {
            Group = group;
            Name = name;
            DisplayName = displayName;
        }

        protected TrimConfigItem()
        {
        }

        /// <summary>
        /// 配置分组
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}
