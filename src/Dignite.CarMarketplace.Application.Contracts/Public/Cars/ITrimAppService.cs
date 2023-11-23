using System;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.Cars
{
    public interface ITrimAppService : IReadOnlyAppService<TrimDto,Guid,GetTrimsInput>
    {
    }
}
