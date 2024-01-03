using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Dealers;

[Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/dealer")]
public class DealerPublicController : CarMarketplaceController, IDealerPublicAppService
{
    private readonly IDealerPublicAppService _dealerAppService;

    public DealerPublicController(IDealerPublicAppService dealerAppService)
    {
        _dealerAppService = dealerAppService;
    }

    [HttpGet]
    [Route("find/{shortName}")]
    public async Task<DealerDto> FindByShortNameAsync(string shortName)
    {
        return await _dealerAppService.FindByShortNameAsync(shortName);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<DealerDto> GetAsync(Guid id)
    {
        return await _dealerAppService.GetAsync(id);
    }

    [HttpGet]
    public async Task<PagedResultDto<DealerDto>> GetListAsync(GetDealersInput input)
    {
        return await _dealerAppService.GetListAsync(input);
    }
}
