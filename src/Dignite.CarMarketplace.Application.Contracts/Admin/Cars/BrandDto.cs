using System;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Admin.Cars
{
    public class BrandDto : EntityDto<Guid>
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 首字母
        /// </summary>
        public string FirstLetter { get; set; }
    }
}
