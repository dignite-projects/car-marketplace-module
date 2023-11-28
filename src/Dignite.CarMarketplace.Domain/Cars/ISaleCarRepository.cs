using System;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.Cars
{
    public interface ISaleCarRepository : IBasicRepository<SaleCar, Guid>
    {
    }
}
