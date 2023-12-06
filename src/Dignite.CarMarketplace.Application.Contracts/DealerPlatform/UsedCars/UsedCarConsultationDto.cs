using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Dignite.CarMarketplace.DealerPlatform.Cars;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public class UsedCarConsultationDto:CreationAuditedEntityDto<Guid>
    {
        public Guid UsedCarId { get; set; }
        public UsedCarDto UsedCar { get; set; }

        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime ReservationTime { get; set; }
    }
}
