using AutoMapper;
using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.UsedCars;
using Volo.Abp.AutoMapper;

namespace Dignite.CarMarketplace;

public class CarMarketplaceApplicationAutoMapperProfile : Profile
{
    public CarMarketplaceApplicationAutoMapperProfile()
    {
        CreateMap<Dealer, Admin.Dealers.DealerDto>();
        CreateMap<SaleCar, Admin.Cars.SaleCarDto>();
        CreateMap<Brand, Admin.Cars.BrandDto>();
        CreateMap<Model, Admin.Cars.ModelDto>();
        CreateMap<UsedCar, Admin.UsedCars.UsedCarDto>();

        CreateMap<Dealer, DealerPlatform.Dealers.DealerDto>();
        CreateMap<UsedCar, DealerPlatform.Cars.UsedCarDto>()
            .Ignore(x=>x.Tags);
        CreateMap<UsedCarConsultation, DealerPlatform.UsedCars.UsedCarConsultationDto>();

        CreateMap<Dealer, Public.Dealers.DealerDto>();
        CreateMap<UsedCar, Public.Cars.UsedCarDto>()
            .Ignore(x=>x.Tags);
        CreateMap<SaleCar, Public.Cars.SaleCarDto>();
        CreateMap<Brand, Public.Cars.BrandDto>();
        CreateMap<Model, Public.Cars.ModelDto>();
        CreateMap<Trim, Public.Cars.TrimDto>()
            .MapExtraProperties(Volo.Abp.ObjectExtending.MappingPropertyDefinitionChecks.None);
        CreateMap<ConfigurationItem, Public.Cars.ConfigurationItemDto>();
        CreateMap<UsedCarConsultation, Public.UsedCars.UsedCarConsultationDto>();
    }
}
