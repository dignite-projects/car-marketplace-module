using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.UsedCars;

[Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/usedcar")]
public class UsedCarPublicController : CarMarketplaceController, IUsedCarPublicAppService
{
    private readonly IUsedCarPublicAppService _usedCarAppService;

    public UsedCarPublicController(IUsedCarPublicAppService usedCarAppService)
    {
        _usedCarAppService = usedCarAppService;
    }

    [HttpGet]
    [Route("all-model-colors")]
    public async Task<List<string>> GetAllModelColorsAsync()
    {
        return await _usedCarAppService.GetAllModelColorsAsync();
    }

    [HttpGet]
    [Route("all-model-levels")]
    public async Task<List<string>> GetAllModelLevelsAsync()
    {
        return await _usedCarAppService.GetAllModelLevelsAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<UsedCarDto> GetAsync(Guid id)
    {
        return await _usedCarAppService.GetAsync(id);
    }

    [HttpGet]
    public async Task<PagedResultDto<UsedCarDto>> GetListAsync(GetUsedCarsInput input)
    {
        return await _usedCarAppService.GetListAsync(input);
    }
}
