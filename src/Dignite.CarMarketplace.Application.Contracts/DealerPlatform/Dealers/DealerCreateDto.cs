using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Threading;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers
{
    public class DealerCreateDto : DealerCreateOrUpdateDtoBase , IValidatableObject
    {
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
