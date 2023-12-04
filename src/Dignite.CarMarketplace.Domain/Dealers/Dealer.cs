using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Dignite.CarMarketplace.Dealers
{
    /// <summary>
    /// 车商
    /// </summary>
    public class Dealer : FullAuditedEntity<Guid>, IMultiTenant
    {
        protected Dealer()
        {
        }

        public Dealer(Guid id, string name, string shortName, string address, string contactPerson, string contactNumber, double? latitude, double? longitude, Guid? tenantId)
            : base(id)
        {
            Name = name;
            ShortName = shortName;
            Address = address;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            Latitude = latitude;
            Longitude = longitude;
            TenantId = tenantId;
            Administrators = new Collection<DealerAdministrator>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        
        // 地图经纬度
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public AuthenticationStatus AuthenticationStatus { get; protected set; }

        public virtual Guid? TenantId { get; protected set; }

        public ICollection<DealerAdministrator> Administrators { get; protected set; }

        public void SetAuthenticationStatus(AuthenticationStatus status)
        {
            AuthenticationStatus = status;
        }

        public virtual void AddAdministrator(Guid userId)
        {
            Check.NotNull(userId, nameof(userId));

            if (IsInAdministrator(userId))
            {
                return;
            }

            Administrators.Add(new DealerAdministrator( userId,Id, TenantId));
        }

        public virtual void RemoveAdministrator(Guid userId)
        {
            Check.NotNull(userId, nameof(userId));

            if (!IsInAdministrator(userId))
            {
                return;
            }

            Administrators.RemoveAll(r => r.UserId == userId);
        }

        public virtual bool IsInAdministrator(Guid userId)
        {
            Check.NotNull(userId, nameof(userId));

            return Administrators.Any(r => r.UserId == userId);
        }

        public virtual void UpdateInternal(string name, string shortName, string address, string contactPerson, string contactNumber, double? latitude, double? longitude)
        {
            Name = name;
            ShortName = shortName;
            Address = address;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
