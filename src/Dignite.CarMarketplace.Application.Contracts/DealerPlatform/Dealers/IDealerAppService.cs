using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.CmsKit.Users;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers;

public interface IDealerAppService: IApplicationService
{
    Task<DealerDto> CreateAsync(DealerCreateDto input);
    Task<DealerDto> UpdateAsync(Guid id, DealerUpdateDto input);

    Task<DealerDto> FindByCurrentUserAsync();
    Task<ListResultDto<CmsUserDto>> GetAdministratorsAsync();

    Task AddAdministratorAsync(Guid userId);
    Task RemoveAdministratorAsync(Guid userId);
}
