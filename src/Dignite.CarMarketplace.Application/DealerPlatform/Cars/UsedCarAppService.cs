using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;

namespace Dignite.CarMarketplace.DealerPlatform.Cars;

public class UsedCarAppService : CarMarketplaceAppService, IUsedCarAppService
{
    private readonly IUsedCarRepository _usedCarRepository;
    private readonly ITrimRepository _trimRepository;
    private readonly IDealerRepository _dealerRepository;

    public UsedCarAppService(IUsedCarRepository usedCarRepository, ITrimRepository trimRepository, IDealerRepository dealerRepository)
    {
        _usedCarRepository = usedCarRepository;
        _trimRepository = trimRepository;
        _dealerRepository = dealerRepository;
    }

    [Authorize]
    public async Task<UsedCarDto> CreateAsync(UsedCarCreateDto input)
    {
        var dealer = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(),true);
        await AuthorizationService.CheckAsync(dealer, CommonOperations.UsedCarManage);
        var trim = await _trimRepository.GetAsync(input.TrimId);
        var usedCar = new UsedCar(
            GuidGenerator.Create(),
            trim,
            input.Name,input.Description,
            dealer.Id,
            input.RegistrationDate,
            input.TotalMileage,
            input.TransfersCount,
            input.CompulsoryInsuranceExpirationDate,
            input.CompulsoryInsuranceExpirationDate,
            input.Color,
            input.Price,
            CurrentTenant.Id
            );
        usedCar.SetStatus(input.Status);
        usedCar.SetConfig(trim);
        return ObjectMapper.Map<UsedCar, UsedCarDto>(
            await _usedCarRepository.InsertAsync(usedCar)
            );
    }

    [Authorize]
    public async Task DeleteAsync(Guid id)
    {
        var usedCar = await _usedCarRepository.GetAsync(id,false);
        var dealer = await _dealerRepository.GetAsync(usedCar.DealerId);
        await AuthorizationService.CheckAsync(dealer, CommonOperations.UsedCarManage);
        await _usedCarRepository.DeleteAsync(usedCar);
    }

    [Authorize]
    public async Task<UsedCarDto> GetAsync(Guid id)
    {
        var usedCar = await _usedCarRepository.GetAsync(id);
        var dealer = await _dealerRepository.GetAsync(usedCar.DealerId);
        await AuthorizationService.CheckAsync(dealer, CommonOperations.UsedCarManage);
        return ObjectMapper.Map<UsedCar, UsedCarDto>(
            usedCar
            );
    }

    [Authorize]
    public async Task<PagedResultDto<UsedCarDto>> GetListAsync(GetUsedCarsInput input)
    {
        var dealer = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(), false);
        var count = await _usedCarRepository.GetCountAsync(
            input.Status,
            input.Filter,
            dealerId: dealer.Id);
        if (count > 0)
        {
            var result = await _usedCarRepository.GetListAsync(
                input.Status,
                input.Filter,
                dealerId: dealer.Id,
                skipCount: input.SkipCount,
                maxResultCount: input.MaxResultCount,
                sorting: input.Sorting);

            return new PagedResultDto<UsedCarDto>(count,
                ObjectMapper.Map<List<UsedCar>, List<UsedCarDto>>(result)
                );
        }
        else
        {
            return new PagedResultDto<UsedCarDto>(0,new List<UsedCarDto>());
        }
    }

    [Authorize]
    public async Task SetStatusAsync(Guid id, CarStatus status)
    {
        var usedCar = await _usedCarRepository.GetAsync(id,false);
        var dealer = await _dealerRepository.GetAsync(usedCar.DealerId);
        await AuthorizationService.CheckAsync(dealer, CommonOperations.UsedCarManage);
        usedCar.SetStatus(status);
        await _usedCarRepository.UpdateAsync(usedCar);  
    }

    [Authorize]
    public async Task<UsedCarDto> UpdateAsync(Guid id, UsedCarUpdateDto input)
    {
        var usedCar = await _usedCarRepository.GetAsync(id, false);
        var dealer = await _dealerRepository.GetAsync(usedCar.DealerId);
        await AuthorizationService.CheckAsync(dealer, CommonOperations.UsedCarManage);
        var trim = await _trimRepository.GetAsync(input.TrimId);
        usedCar.SetStatus(input.Status);
        usedCar.SetConfig(trim);
        usedCar.Update(
            trim,
            input.Name, input.Description,
            input.RegistrationDate,
            input.TotalMileage,
            input.TransfersCount,
            input.CompulsoryInsuranceExpirationDate,
            input.CompulsoryInsuranceExpirationDate,
            input.Color,
            input.Price);
        return ObjectMapper.Map<UsedCar, UsedCarDto>(
            await _usedCarRepository.UpdateAsync(usedCar)
            );
    }
}
