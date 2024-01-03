using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.CmsKit.Users;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers;

[Area(CarMarketplaceRemoteServiceConsts.DealerPlatformModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-dealer-platform/dealer")]
public class DealerPlatformController : CarMarketplaceController, IDealerPlatformAppService
{
    private readonly IDealerPlatformAppService _dealerAppService;

    public DealerPlatformController(IDealerPlatformAppService dealerAppService)
    {
        _dealerAppService = dealerAppService;
    }

    [HttpPost]
    [Route("add-administrator")]
    [Authorize]
    public async Task AddAdministratorAsync(Guid userId)
    {
        await _dealerAppService.AddAdministratorAsync(userId);
    }

    [HttpPost]
    [Authorize]
    public async Task<DealerDto> CreateAsync(DealerCreateDto input)
    {
        return await _dealerAppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("find-by-current-user")]
    [Authorize]
    public async Task<DealerDto> FindByCurrentUserAsync()
    {
        return await _dealerAppService.FindByCurrentUserAsync();
    }

    [HttpGet]
    [Route("administrators")]
    [Authorize]
    public async Task<ListResultDto<CmsUserDto>> GetAdministratorsAsync()
    {
        return await _dealerAppService.GetAdministratorsAsync();
    }

    [HttpPut]
    [Route("remove-administrator")]
    [Authorize]
    public async Task RemoveAdministratorAsync(Guid userId)
    {
        await _dealerAppService.RemoveAdministratorAsync(userId);
    }

    [HttpPut]
    [Route("short-name-exists")]
    [Authorize]
    public async Task<bool> ShortNameExistsAsync(string shortName)
    {
        return await _dealerAppService.ShortNameExistsAsync(shortName);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    [Authorize]
    public async Task<DealerDto> UpdateAsync(Guid id,DealerUpdateDto input)
    {
        return await _dealerAppService.UpdateAsync(id,input);
    }
}
