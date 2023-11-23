using Dignite.CarMarketplace.Dealers;
using System;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Dealers;

public class DealerDto : EntityDto<Guid>
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
