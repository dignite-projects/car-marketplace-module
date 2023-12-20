using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dignite.CarMarketplace.Dealers;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using Volo.Abp.Validation;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers
{
    public abstract class DealerCreateOrUpdateDtoBase : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dealerAppService = validationContext.GetRequiredService<Public.Dealers.IDealerAppService>();
            var dealer = AsyncHelper.RunSync(() => dealerAppService.FindByShortNameAsync(ShortName));
            if (dealer != null)
            {
                yield return new ValidationResult(
                        $"{ShortName} 这个短名称已被占用！",
                        new[] { nameof(ShortName) }
                    );
            }
        }
    }
}
