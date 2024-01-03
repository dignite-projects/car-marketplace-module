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
            var dealerAppService = validationContext.GetRequiredService<IDealerPlatformAppService>();
            var shortNameExists = AsyncHelper.RunSync(() => dealerAppService.ShortNameExistsAsync(ShortName));
            if (shortNameExists)
            {
                yield return new ValidationResult(
                        $"{ShortName} 这个短名称已被占用！",
                        new[] { nameof(ShortName) }
                    );
            }
        }
    }
}
