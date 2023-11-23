using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Dignite.CarMarketplace.Dealers
{
    /// <summary>
    /// 车商管理员
    /// </summary>
    public class DealerAdministrator:Entity, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        public virtual Guid UserId { get; protected set; }

        /// <summary>
        /// Gets or sets the primary key of the dealer that is linked to the user.
        /// </summary>
        public virtual Guid DealerId { get; protected set; }

        protected DealerAdministrator()
        {

        }

        protected internal DealerAdministrator(Guid userId, Guid dealerId, Guid? tenantId)
        {
            UserId = userId;
            DealerId = dealerId;
            TenantId = tenantId;
        }

        public override object[] GetKeys()
        {
            return new object[] { UserId, DealerId };
        }
    }
}
