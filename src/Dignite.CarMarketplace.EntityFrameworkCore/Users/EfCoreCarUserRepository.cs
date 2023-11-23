using Dignite.CarMarketplace.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Dignite.CarMarketplace.Users;

public class EfCoreCarUserRepository : EfCoreUserRepositoryBase<ICarMarketplaceDbContext, CarUser>, ICarUserRepository
{
    public EfCoreCarUserRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}
