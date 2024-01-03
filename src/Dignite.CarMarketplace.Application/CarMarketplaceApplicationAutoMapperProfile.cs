using AutoMapper;
using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.Public.UsedCars;
using Dignite.CarMarketplace.UsedCars;
using Volo.Abp.AutoMapper;

namespace Dignite.CarMarketplace;

public class CarMarketplaceApplicationAutoMapperProfile : Profile
{
    public CarMarketplaceApplicationAutoMapperProfile()
    {
        CreateMap<Dealer, Admin.Dealers.DealerDto>();
        CreateMap<SaleUsedCar, Admin.UsedCars.SaleUsedCarDto>();
        CreateMap<Brand, Admin.Cars.BrandDto>();
        CreateMap<Model, Admin.Cars.ModelDto>();
        CreateMap<UsedCar, Admin.UsedCars.UsedCarDto>()
            .Ignore(x => x.Tags);
        CreateMap<Dealer, Admin.Dealers.DealerExcelDto>();

        CreateMap<Dealer, DealerPlatform.Dealers.DealerDto>();
        CreateMap<UsedCar, DealerPlatform.UsedCars.UsedCarDto>()
            .Ignore(x=>x.Tags);
        CreateMap<BuyUsedCar, DealerPlatform.UsedCars.BuyUsedCarDto>();

        CreateMap<Dealer, Public.Dealers.DealerDto>();
        CreateMap<UsedCar, Public.UsedCars.UsedCarDto>()
            .Ignore(x=>x.Tags);
        CreateMap<SaleUsedCar, SaleCarDto>();
        CreateMap<Brand, Public.Cars.BrandDto>();
        CreateMap<Model, Public.Cars.ModelDto>();
        CreateMap<Trim, Public.Cars.TrimDto>()
            .MapExtraProperties(Volo.Abp.ObjectExtending.MappingPropertyDefinitionChecks.None);
        CreateMap<TrimConfigItem, Public.Cars.TrimConfigItemDto>();
        CreateMap<BuyUsedCar, Public.UsedCars.BuyUsedCarDto>();
    }
}
