using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public interface IUsedCarConsultationAppService : IApplicationService
    {
        Task<UsedCarConsultationDto> CreateAsync(UsedCarConsultationCreateDto input);
    }
}
