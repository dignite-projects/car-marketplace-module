using System;
using System.ComponentModel.DataAnnotations;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class GetTrimsInput
    {
        [Required]
        public Guid ModelId { get; set; }
    }
}
