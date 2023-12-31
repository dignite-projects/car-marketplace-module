﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars;

[Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/trim")]
public class TrimPublicController : CarMarketplaceController, ITrimPublicAppService
{
    private readonly ITrimPublicAppService _trimAppService;

    public TrimPublicController(ITrimPublicAppService trimAppService)
    {
        _trimAppService = trimAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<TrimDto> GetAsync(Guid id)
    {
        return await _trimAppService.GetAsync(id);
    }


    [HttpGet]
    public async Task<PagedResultDto<TrimDto>> GetListAsync(GetTrimsInput input)
    {
        return await _trimAppService.GetListAsync(input);
    }
}
