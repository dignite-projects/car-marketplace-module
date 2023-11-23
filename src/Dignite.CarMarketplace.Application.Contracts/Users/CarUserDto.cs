using System;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Users;

[Serializable]
public class CarUserDto : ExtensibleEntityDto<Guid>
{
    public virtual Guid? TenantId { get; protected set; }

    public virtual string UserName { get; protected set; }

    public virtual string Name { get; set; }

    public virtual string Surname { get; set; }
}
