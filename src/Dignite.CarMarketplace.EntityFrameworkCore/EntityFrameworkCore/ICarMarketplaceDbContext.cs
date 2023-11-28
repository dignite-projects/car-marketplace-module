﻿using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.EntityFrameworkCore;

[ConnectionStringName(CarMarketplaceDbProperties.ConnectionStringName)]
public interface ICarMarketplaceDbContext : IEfCoreDbContext
{
    DbSet<Dealer> Dealer { get; }
    DbSet<DealerAdministrator> DealerAdministrator { get; }
    DbSet<Brand> Brand { get; }
    DbSet<Model> Model { get; }
    DbSet<Trim> Trim { get; }
    DbSet<ConfigurationItem> ConfigurationItem { get; }
    DbSet<UsedCar> UsedCar { get; }
    DbSet<SaleCar> SaleCar { get; }
}
