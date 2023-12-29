using System;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Public.Cars
{
    public interface ITrimPublicAppService : IReadOnlyAppService<TrimDto,Guid,GetTrimsInput>
    {
    }
}
