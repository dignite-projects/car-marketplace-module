using Dignite.CarMarketplace.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.Dealers;

public class EfCoreDealerRepository : EfCoreRepository<ICarMarketplaceDbContext, Dealer,Guid>, IDealerRepository
{
    public EfCoreDealerRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Dealer> FindByAdministratorAsync(Guid userId, bool includeDetails = true)
    {
        return await (await GetDbSetAsync())
            .IncludeDetails(includeDetails)
            .FirstOrDefaultAsync(d => d.Administrators.Any(a => a.UserId == userId));
    }


    public async Task<int> GetCountAsync(string filter = null, AuthenticationStatus? authenticationStatus = null, CancellationToken cancellationToken = default)
    {
        return await (await GetQueryableAsync(filter, authenticationStatus))
        .CountAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<List<Dealer>> GetListAsync(string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string filter = null, AuthenticationStatus? authenticationStatus = null, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        return await(await GetQueryableAsync(filter,authenticationStatus))
            .IncludeDetails(includeDetails)
            .OrderBy(sorting.IsNullOrEmpty() ? $"{nameof(Dealer.CreationTime)} desc" : sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }
    public override async Task<IQueryable<Dealer>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }

    protected virtual async Task<IQueryable<Dealer>> GetQueryableAsync(
         string filter = null, AuthenticationStatus? authenticationStatus = null)
    {
        return (await GetDbSetAsync())
            .WhereIf(!filter.IsNullOrEmpty(), e => e.Name.Contains(filter))
            .WhereIf(authenticationStatus.HasValue, e => e.AuthenticationStatus == authenticationStatus.Value);
    }
}
