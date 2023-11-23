using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.Cars
{
    public interface IConfigurationItemAppService : IApplicationService
    {
        Task<ListResultDto<ConfigurationItemDto>> GetListAsync();
}
}
