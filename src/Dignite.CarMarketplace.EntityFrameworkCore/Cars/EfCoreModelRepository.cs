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

public class EfCoreModelRepository : EfCoreRepository<ICarMarketplaceDbContext, Model, Guid>, IModelRepository
{
    public EfCoreModelRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<List<Model>> GetListByBrandAsync(Guid brandId, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .Where(m => m.BrandId == brandId)
            .ToListAsync(cancellationToken);
    }

    public override async Task<IQueryable<Model>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}
