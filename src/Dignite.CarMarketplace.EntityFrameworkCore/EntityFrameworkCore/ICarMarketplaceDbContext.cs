using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.EntityFrameworkCore;

[ConnectionStringName(CarMarketplaceDbProperties.ConnectionStringName)]
public interface ICarMarketplaceDbContext : IEfCoreDbContext
{
    DbSet<CarUser> User { get; }
    DbSet<Dealer> Dealer { get; }
    DbSet<Brand> Brand { get; }
    DbSet<Model> Model { get; }
    DbSet<Trim> Trim { get; }
    DbSet<ConfigurationItem> ConfigurationItem { get; }
    DbSet<UsedCar> UsedCar { get; }
    DbSet<DealerAdministrator> DealerAdministrator { get; }
}
