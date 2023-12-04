using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Cars;

[Area(CarMarketplaceRemoteServiceConsts.PublicModuleName)]
[RemoteService(Name = CarMarketplaceRemoteServiceConsts.RemoteServiceName)]
[Route("api/car-marketplace-public/configuration-item")]
public class ConfigurationItemController : CarMarketplaceController, IConfigurationItemAppService
{
    private readonly IConfigurationItemAppService _configurationItemAppService;

    public ConfigurationItemController(IConfigurationItemAppService configurationItemAppService)
    {
        _configurationItemAppService = configurationItemAppService;
    }


    [HttpGet]
    public async Task<ListResultDto<ConfigurationItemDto>> GetListAsync()
    {
        return await _configurationItemAppService.GetListAsync();   
    }
}
