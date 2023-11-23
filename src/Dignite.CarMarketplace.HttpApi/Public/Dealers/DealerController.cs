using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Dealers;

[Area(CarMarketplaceRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/dealer")]
public class DealerController : CarMarketplaceController, IDealerAppService
{
    private readonly IDealerAppService _dealerAppService;

    public DealerController(IDealerAppService dealerAppService)
    {
        _dealerAppService = dealerAppService;
    }

    [HttpGet]
    [Route("{id}")]
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
