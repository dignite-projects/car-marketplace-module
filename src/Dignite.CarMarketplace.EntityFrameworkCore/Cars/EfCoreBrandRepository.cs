using Dignite.CarMarketplace.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.Cars;

public class EfCoreBrandRepository : EfCoreRepository<ICarMarketplaceDbContext, Brand, Guid>, IBrandRepository
{
    public EfCoreBrandRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public override async Task<List<Brand>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        return (await base.GetListAsync(includeDetails, cancellationToken))
            .OrderBy(b=>b.FirstLetter)
            .ToList();
    }
}
