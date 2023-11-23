using Dignite.CarMarketplace.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.DealerPlatform.Cars;

[Area(CarMarketplaceRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-dealer-platform/used-car")]
public class UsedCarController : CarMarketplaceController, IUsedCarAppService
{
    private readonly IUsedCarAppService _usedCarAppService;

    public UsedCarController(IUsedCarAppService usedCarAppService)
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
    public async Task SetStatusAsync(Guid id, CarStatus status)
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
