using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars;

[Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/trim-config-item")]
public class TrimConfigItemController : CarMarketplaceController, ITrimConfigItemAppService
{
    private readonly ITrimConfigItemAppService _trimConfigItemAppService;

    public TrimConfigItemController(ITrimConfigItemAppService trimConfigItemAppService)
    {
        _trimConfigItemAppService = trimConfigItemAppService;
    }


    [HttpGet]
    public async Task<ListResultDto<TrimConfigItemDto>> GetListAsync()
    {
        return await _trimConfigItemAppService.GetListAsync();   
    }
}
