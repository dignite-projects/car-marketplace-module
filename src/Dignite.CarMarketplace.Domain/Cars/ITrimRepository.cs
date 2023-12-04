using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.Cars
{
    public interface ITrimRepository : IBasicRepository<Trim, Guid>
    {
        Task<List<Trim>> GetListByModelAsync(
            Guid modelId,
            CancellationToken cancellationToken = default
        );

        Task<Trim> GetByMaxNumberAsync();

        Task<bool> AnyAsync(int number);

        Task<int[]> GetNumberArrayAsync();
    }
}
