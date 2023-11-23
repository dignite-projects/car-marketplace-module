using System;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.Cars
{
    public interface IBrandRepository : IBasicRepository<Brand, Guid>
    {
    }
}
