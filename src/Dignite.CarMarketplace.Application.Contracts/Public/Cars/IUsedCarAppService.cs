using System;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.Cars
{
    public interface IUsedCarAppService : IReadOnlyAppService<UsedCarDto,Guid,GetUsedCarsInput>
    {
    }
}
