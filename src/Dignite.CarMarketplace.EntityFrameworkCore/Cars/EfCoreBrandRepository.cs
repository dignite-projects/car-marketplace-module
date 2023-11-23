using Dignite.CarMarketplace.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.Cars;

public class EfCoreBrandRepository : EfCoreRepository<ICarMarketplaceDbContext, Brand, Guid>, IBrandRepository
{
    public EfCoreBrandRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

}
