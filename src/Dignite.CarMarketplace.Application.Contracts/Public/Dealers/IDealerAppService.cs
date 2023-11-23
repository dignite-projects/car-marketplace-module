using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.Dealers;

public interface IDealerAppService
    : IReadOnlyAppService<
        DealerDto,
        Guid,
        GetDealersInput>
{
}
