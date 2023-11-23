﻿using Dignite.CarMarketplace.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers;

[Area(CarMarketplaceRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-dealer-platform/dealer")]
public class DealerController : CarMarketplaceController, IDealerAppService
{
    private readonly IDealerAppService _dealerAppService;

    public DealerController(IDealerAppService dealerAppService)
    {
        _dealerAppService = dealerAppService;
    }

    [HttpPost]
    [Route("add-administrator")]
    [Authorize]
    public async Task AddAdministrator(Guid userId)
    {
        await _dealerAppService.AddAdministrator(userId);
    }

    [HttpPost]
    [Authorize]
    public async Task<DealerDto> CreateAsync(DealerCreateDto input)
    {
        return await _dealerAppService.CreateAsync(input);
    }

    [HttpGet]
    [Route("find-by-current-user")]
    [Authorize]
    public async Task<DealerDto> FindByCurrentUserAsync()
    {
        return await _dealerAppService.FindByCurrentUserAsync();
    }

    [HttpGet]
    [Route("administrators")]
    [Authorize]
    public async Task<ListResultDto<CarUserDto>> GetAdministratorsAsync()
    {
        return await _dealerAppService.GetAdministratorsAsync();
    }

    [HttpPut]
    [Route("remove-administrator")]
    [Authorize]
    public async Task RemoveAdministratorAsync(Guid userId)
    {
        await _dealerAppService.RemoveAdministratorAsync(userId);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    [Authorize]
    public async Task<DealerDto> UpdateAsync(Guid id,DealerUpdateDto input)
    {
        return await _dealerAppService.UpdateAsync(id,input);
    }
}
