using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars;

[Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/model")]
public class ModelPublicController : CarMarketplaceController, IModelPublicAppService
{
    private readonly IModelPublicAppService _modelAppService;

    public ModelPublicController(IModelPublicAppService modelAppService)
    {
        _modelAppService = modelAppService;
    }


    [HttpGet]
    public async Task<ListResultDto<ModelCompanyDto>> GetListAsync(GetModelsInput input)
    {
        return await _modelAppService.GetListAsync(input);   
    }
}
