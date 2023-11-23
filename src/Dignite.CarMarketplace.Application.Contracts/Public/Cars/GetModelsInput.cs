using System;
using System.ComponentModel.DataAnnotations;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class GetModelsInput
    {
        [Required]
        public Guid BrandId { get; set; }
    }
}
