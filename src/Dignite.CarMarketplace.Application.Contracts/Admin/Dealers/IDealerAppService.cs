
using Dignite.CarMarketplace.Dealers;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Dignite.CarMarketplace.Admin.Dealers;

public interface IDealerAppService
    : IReadOnlyAppService<
        DealerDto,
        Guid,
        GetDealersInput>
{
    Task DeleteAsync(Guid id);

    Task Authenticate(Guid id, AuthenticationStatus status);


    Task<IRemoteStreamContent> GetListAsExcelFileAsync(DealerExcelDownloadInput input);
}
