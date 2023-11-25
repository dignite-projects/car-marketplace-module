using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CmsKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.CmsKit.EntityFrameworkCore;

namespace Dignite.CarMarketplace.EntityFrameworkCore;

public static class CarMarketplaceDbContextModelCreatingExtensions
{
    public static void ConfigureCarMarketplace(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.ConfigureCmsKit();
        builder.ConfigureDigniteCmsKit();

        builder.Entity<Dealer>(b =>
        {
            b.ToTable(CarMarketplaceDbProperties.DbTablePrefix + "Dealers", CarMarketplaceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Name).IsRequired().HasMaxLength(DealerConsts.MaxNameLength);
            b.Property(q => q.Address).IsRequired().HasMaxLength(DealerConsts.MaxAddressLength);
            b.Property(q => q.ContactPerson).HasMaxLength(DealerConsts.MaxContactPersonLength);
            b.Property(q => q.ContactNumber).HasMaxLength(DealerConsts.MaxContactNumberLength);

        });

        builder.Entity<DealerAdministrator>(b =>
        {
            b.ToTable(CarMarketplaceDbProperties.DbTablePrefix + "DealerAdministrators", CarMarketplaceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Indexes
            b.HasIndex(q => q.DealerId);
            b.HasIndex(q => q.UserId);

            b.HasKey(ur => new { ur.DealerId, ur.UserId });
        });

        builder.Entity<Brand>(b =>
        {
            b.ToTable(CarMarketplaceDbProperties.DbTablePrefix + "Brands", CarMarketplaceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Name).IsRequired().HasMaxLength(BrandConsts.MaxNameLength);
            b.Property(q => q.FirstLetter).IsRequired().HasMaxLength(BrandConsts.MaxFirstLetterLength);
        });

        builder.Entity<Model>(b =>
        {
            b.ToTable(CarMarketplaceDbProperties.DbTablePrefix + "Models", CarMarketplaceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Name).IsRequired().HasMaxLength(ModelConsts.MaxNameLength);
            b.Property(q => q.Group).IsRequired().HasMaxLength(ModelConsts.MaxGroupLength);

            b.HasIndex(q => q.BrandId);
        });

        builder.Entity<Trim>(b =>
        {
            b.ToTable(CarMarketplaceDbProperties.DbTablePrefix + "Trims", CarMarketplaceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Name).IsRequired().HasMaxLength(TrimConsts.MaxNameLength);
            b.Property(q => q.Year).IsRequired().HasMaxLength(TrimConsts.MaxYearLength);

            b.HasIndex(q => q.ModelId);

            b.ApplyObjectExtensionMappings();
        });


        builder.Entity<UsedCar>(b =>
        {
            //Configure table & schema name
            b.ToTable(CarMarketplaceDbProperties.DbTablePrefix + "UsedCars", CarMarketplaceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Color).HasMaxLength(UsedCarConsts.MaxColorLength);
            b.Property(q => q.Name).IsRequired().HasMaxLength(UsedCarConsts.MaxNameLength);
            b.Property(q => q.Description).HasMaxLength(UsedCarConsts.MaxDescriptionLength);
            b.Property(q => q.TransmissionType).HasMaxLength(UsedCarConsts.MaxTransmissionTypeLength);
            b.Property(q => q.PowerType).HasMaxLength(UsedCarConsts.MaxPowerTypeLength);
            b.Property(q => q.ModelLevel).HasMaxLength(UsedCarConsts.MaxModelLevelLength);

            //Indexes
            b.HasIndex(q => q.CreationTime);
            b.HasIndex(q => q.BrandId);
            b.HasIndex(q => q.ModelId);
            b.HasIndex(q => q.TrimId);
            b.HasIndex(q => q.Color);
            b.HasIndex(q => q.PowerType);
            b.HasIndex(q => q.TransmissionType);
            b.HasIndex(q => q.ModelLevel);
            b.HasIndex(q => q.Price);
            b.HasIndex(q => q.RegistrationDate);


        });

        builder.Entity<ConfigurationItem>(b =>
        {
            b.ToTable(CarMarketplaceDbProperties.DbTablePrefix + "ConfigurationItems", CarMarketplaceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Name).IsRequired().HasMaxLength(ConfigurationItemConsts.MaxNameLength);
            b.Property(q => q.Group).IsRequired().HasMaxLength(ConfigurationItemConsts.MaxGroupLength);

        });
    }
}
