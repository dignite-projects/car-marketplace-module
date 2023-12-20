using System;
using System.Threading.Tasks;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;

namespace Dignite.CarMarketplace.Admin.Dealers;

[Area(CarMarketplaceRemoteServiceConsts.AdminModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-admin/dealer")]
public class DealerController : CarMarketplaceController, IDealerAppService
{
    private readonly IDealerAppService _dealerAppService;

    public DealerController(IDealerAppService dealerAppService)
    {
        _dealerAppService = dealerAppService;
    }

    [HttpPut]
    [Route("{id:Guid}/authenticate")]
    [Authorize(CarMarketplacePermissions.Dealers.Management)]
    public async Task Authenticate(Guid id, AuthenticationStatus status)
    {
        await _dealerAppService.Authenticate(id, status);
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    [Authorize(CarMarketplacePermissions.Dealers.Management)]
    public async Task DeleteAsync(Guid id)
    {
        await _dealerAppService.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    [Authorize(CarMarketplacePermissions.Dealers.Management)]
    public async Task<DealerDto> GetAsync(Guid id)
    {
        return await _dealerAppService.GetAsync(id);
    }

    [HttpGet]
    [Route("as-excel-file")]
    [Authorize(CarMarketplacePermissions.Dealers.Management)]
    public Task<IRemoteStreamContent> GetListAsExcelFileAsync(DealerExcelDownloadInput input)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Authorize(CarMarketplacePermissions.Dealers.Management)]
    public async Task<PagedResultDto<DealerDto>> GetListAsync(GetDealersInput input)
    {
        return await _dealerAppService.GetListAsync(input);
    }
}
