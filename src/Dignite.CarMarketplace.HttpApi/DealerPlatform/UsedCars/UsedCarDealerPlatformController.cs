using Dignite.CarMarketplace.UsedCars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars;

[Area(CarMarketplaceRemoteServiceConsts.DealerPlatformModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-dealer-platform/used-car")]
public class UsedCarDealerPlatformController : CarMarketplaceController, IUsedCarDealerPlatformAppService
{
    private readonly IUsedCarDealerPlatformAppService _usedCarAppService;

    public UsedCarDealerPlatformController(IUsedCarDealerPlatformAppService usedCarAppService)
    {
        _usedCarAppService = usedCarAppService;
    }


    [HttpPost]
    [Authorize]
    public async Task<UsedCarDto> CreateAsync(UsedCarCreateDto input)
    {
        return await _usedCarAppService.CreateAsync(input);
    }

    [HttpDelete]
    [Authorize]
    public async Task DeleteAsync(Guid id)
    {
        await _usedCarAppService.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    [Authorize]
    public async Task<UsedCarDto> GetAsync(Guid id)
    {
        return await _usedCarAppService.GetAsync(id);
    }

    [HttpGet]
    [Authorize]
    public async Task<PagedResultDto<UsedCarDto>> GetListAsync(GetUsedCarsInput input)
    {
        return await _usedCarAppService.GetListAsync(input);
    }

    [HttpPut]
    [Route("{id:Guid}/set-status")]
    [Authorize]
    public async Task SetStatusAsync(Guid id, UsedCarStatus status)
    {
        await _usedCarAppService.SetStatusAsync(id, status);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    [Authorize]
    public async Task<UsedCarDto> UpdateAsync(Guid id, UsedCarUpdateDto input)
    {
        return await _usedCarAppService.UpdateAsync(id, input);
    }

}
