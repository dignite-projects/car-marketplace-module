using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.Cars
{
    public interface IBrandAppService : IApplicationService
    {
        Task<ListResultDto<BrandDto>> GetListAsync();
}
}
