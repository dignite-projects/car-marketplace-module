using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.Cars
{
    public interface IModelRepository : IBasicRepository<Model, Guid>
    {
        Task<List<Model>> GetListByBrandAsync(
            Guid brandId,
            CancellationToken cancellationToken = default
        );
    }
}
