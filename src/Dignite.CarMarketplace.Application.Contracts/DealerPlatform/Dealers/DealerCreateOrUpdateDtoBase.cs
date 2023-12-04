using System.ComponentModel.DataAnnotations;
using Dignite.CarMarketplace.Dealers;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers
{
    public abstract class DealerCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(typeof(DealerConsts), nameof(DealerConsts.MaxNameLength))]
        public string Name { get; set; }

        [Required]
        [DynamicStringLength(typeof(DealerConsts), nameof(DealerConsts.MaxShortNameLength))]
        public string ShortName { get; set; }

        [Required]
        [DynamicStringLength(typeof(DealerConsts), nameof(DealerConsts.MaxAddressLength))]
        public string Address { get; set; }

        [Required]
        [DynamicStringLength(typeof(DealerConsts), nameof(DealerConsts.MaxContactPersonLength))]
        public string ContactPerson { get; set; }

        [Required]
        [DynamicStringLength(typeof(DealerConsts), nameof(DealerConsts.MaxContactNumberLength))]
        public string ContactNumber { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
