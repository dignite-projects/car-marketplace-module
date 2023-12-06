using Dignite.CarMarketplace.Cars;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dignite.CarMarketplace.UsedCars
{
    /// <summary>
    /// 二手车咨询
    /// </summary>
    public class UsedCarConsultation:CreationAuditedEntity<Guid>
    {
        protected UsedCarConsultation()
        {
        }

        public UsedCarConsultation(Guid id, Guid usedCarId, string contactPerson, string contactNumber, DateTime reservationTime)
            :base(id)
        {
            UsedCarId = usedCarId;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            ReservationTime = reservationTime;
        }

        public Guid UsedCarId { get; set; }
        public UsedCar UsedCar { get; set; }

        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime ReservationTime { get; set; }
    }
}
