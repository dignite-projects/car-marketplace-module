﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars;

[Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/brand")]
public class BrandPublicController : CarMarketplaceController, IBrandPublicAppService
{
    private readonly IBrandPublicAppService _brandAppService;

    public BrandPublicController(IBrandPublicAppService brandAppService)
    {
        _brandAppService = brandAppService;
    }


    [HttpGet]
    public async Task<ListResultDto<BrandDto>> GetListAsync()
    {
        return await _brandAppService.GetListAsync();   
    }
}
