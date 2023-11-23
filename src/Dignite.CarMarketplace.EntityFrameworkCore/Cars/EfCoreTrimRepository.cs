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

namespace Dignite.CarMarketplace.Cars;

public class EfCoreTrimRepository : EfCoreRepository<ICarMarketplaceDbContext, Trim, Guid>, ITrimRepository
{
    public EfCoreTrimRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }


    public async Task<List<Trim>> GetListByModelAsync(Guid modelId, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .Where(m => m.ModelId == modelId)
            .ToListAsync(cancellationToken);
    }

    public override async Task<IQueryable<Trim>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}
