using System;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public interface IUsedCarConsultationAppService : IReadOnlyAppService<
        UsedCarConsultationDto,
        Guid,
        GetUsedCarConsultationsInput>
    {
    }
}
