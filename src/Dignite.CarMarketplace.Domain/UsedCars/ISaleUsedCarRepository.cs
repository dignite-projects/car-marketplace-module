using System;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.UsedCars
{
    public interface ISaleUsedCarRepository : IBasicRepository<SaleUsedCar, Guid>
    {
    }
}
