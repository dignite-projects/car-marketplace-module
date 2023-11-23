﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars;

[Area(CarMarketplaceRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/usedcar")]
public class UsedCarController : CarMarketplaceController, IUsedCarAppService
{
    private readonly IUsedCarAppService _usedCarAppService;

    public UsedCarController(IUsedCarAppService usedCarAppService)
    {
        _usedCarAppService = usedCarAppService;
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
