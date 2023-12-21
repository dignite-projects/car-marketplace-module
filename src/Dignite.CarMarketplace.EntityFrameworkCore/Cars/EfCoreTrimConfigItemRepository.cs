using Dignite.CarMarketplace.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.Cars;

public class EfCoreTrimConfigItemRepository : EfCoreRepository<ICarMarketplaceDbContext, TrimConfigItem, Guid>, ITrimConfigItemRepository
{
    public EfCoreTrimConfigItemRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync()).AnyAsync(ci=>ci.Name==name);
    }
}
