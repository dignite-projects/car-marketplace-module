using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.Dealers
{
    public interface IDealerRepository : IBasicRepository<Dealer, Guid>
    {
        Task<int> GetCountAsync(
            string filter = null,
            AuthenticationStatus? authenticationStatus=null,
            CancellationToken cancellationToken = default
        );

        Task<List<Dealer>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            AuthenticationStatus? authenticationStatus = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<Dealer> FindByAdministratorAsync(Guid userId, bool includeDetails = true);

        Task<Dealer> FindByShortNameAsync(string shortName, bool includeDetails = false);

        Task<bool> ShortNameExistsAsync(string shortName, CancellationToken cancellationToken = default);
    }
}
