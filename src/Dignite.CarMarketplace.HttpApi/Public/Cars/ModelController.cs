using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars;

[Area(CarMarketplaceRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/model")]
public class ModelController : CarMarketplaceController, IModelAppService
{
    private readonly IModelAppService _modelAppService;

    public ModelController(IModelAppService modelAppService)
    {
        _modelAppService = modelAppService;
    }


    [HttpGet]
    public async Task<ListResultDto<ModelDto>> GetListAsync(GetModelsInput input)
    {
        return await _modelAppService.GetListAsync(input);   
    }
}
