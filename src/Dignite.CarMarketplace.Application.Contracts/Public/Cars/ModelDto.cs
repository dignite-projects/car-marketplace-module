﻿using System;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class ModelDto : EntityDto<Guid>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BrandDto Brand { get; set; }

        /// <summary>
        /// 车型名称,比如A4L\A8L
        /// </summary>
        public string Name { get; set; }
    }
}
