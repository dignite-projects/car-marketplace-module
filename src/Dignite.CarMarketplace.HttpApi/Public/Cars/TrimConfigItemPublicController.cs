using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars;

[Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/trim-config-item")]
public class TrimConfigItemPublicController : CarMarketplaceController, ITrimConfigItemPublicAppService
{
    private readonly ITrimConfigItemPublicAppService _trimConfigItemAppService;

    public TrimConfigItemPublicController(ITrimConfigItemPublicAppService trimConfigItemAppService)
    {
        _trimConfigItemAppService = trimConfigItemAppService;
    }


    [HttpGet]
    public async Task<ListResultDto<TrimConfigItemDto>> GetListAsync()
    {
        return await _trimConfigItemAppService.GetListAsync();   
    }
}
