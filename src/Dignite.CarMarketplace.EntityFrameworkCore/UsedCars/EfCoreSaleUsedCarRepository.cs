using Dignite.CarMarketplace.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.UsedCars;

public class EfCoreSaleUsedCarRepository : EfCoreRepository<ICarMarketplaceDbContext, SaleUsedCar, Guid>, ISaleUsedCarRepository
{
    public EfCoreSaleUsedCarRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<SaleUsedCar>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}
