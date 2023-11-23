using Dignite.CarMarketplace.Dealers;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers;

public class DealerDto : CreationAuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactPerson { get; set; }
    public string ContactNumber { get; set; }

    // 地图经纬度
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public AuthenticationStatus AuthenticationStatus { get; set; }
}
