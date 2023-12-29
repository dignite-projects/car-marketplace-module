using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.Dealers;

public interface IDealerPublicAppService
    : IReadOnlyAppService<
        DealerDto,
        Guid,
        GetDealersInput>
{
    Task<DealerDto> FindByShortNameAsync(string shortName);
}
