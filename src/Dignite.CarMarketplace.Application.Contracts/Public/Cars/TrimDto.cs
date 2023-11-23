using System;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class TrimDto:  ExtensibleEntityDto<Guid>
    {
        protected TrimDto()
        {
        }

        public TrimDto(int year, string name)
        {
            Year = year;
            Name = name;
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ModelDto Model { get; set; }

        /// <summary>
        /// 年代款
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 车款名称
        /// </summary>
        public string Name { get; set; }
    }
}
