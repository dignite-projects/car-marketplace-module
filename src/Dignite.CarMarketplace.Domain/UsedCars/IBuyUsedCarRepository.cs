using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.UsedCars
{
    public interface IBuyUsedCarRepository : IBasicRepository<BuyUsedCar, Guid>
    {
        Task<int> GetCountAsync(
            string filter = null,
            Guid? dealerId=null,
            CancellationToken cancellationToken = default
        );

        Task<List<BuyUsedCar>> GetListAsync(
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            Guid? dealerId = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );
    }
}
