using System;
using Dignite.CarMarketplace.Dealers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Dignite.CarMarketplace.Admin.Dealers;

public class DealerDto : FullAuditedEntityDto<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Address { get; set; }
    public string ContactPerson { get; set; }
    public string ContactNumber { get; set; }

    // 地图经纬度
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public AuthenticationStatus AuthenticationStatus { get; set; }

}
