using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Threading;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers
{
    public class DealerUpdateDto : DealerCreateOrUpdateDtoBase, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dealerAppService = validationContext.GetRequiredService<IDealerAppService>();
            var dealer = AsyncHelper.RunSync(dealerAppService.FindByCurrentUserAsync);
            if (!dealer.ShortName.Equals(ShortName, StringComparison.InvariantCultureIgnoreCase))
            {
                if (AsyncHelper.RunSync(() => dealerAppService.ShortNameExistsAsync(ShortName)))
                {
                    yield return new ValidationResult(
                            $"您修改的新短名称 {ShortName} 已被占用！",
                            new[] { nameof(ShortName) }
                        );
                }
            }
        }
    }
}
