using System;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class UsedCarConsultationDto:CreationAuditedEntityDto<Guid>
    {
        public Guid UsedCarId { get; set; }

        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime ReservationTime { get; set; }
    }
}
