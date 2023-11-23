using AutoMapper;
using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;

namespace Dignite.CarMarketplace;

public class CarMarketplaceApplicationAutoMapperProfile : Profile
{
    public CarMarketplaceApplicationAutoMapperProfile()
    {
        CreateMap<Dealer, Admin.Dealers.DealerDto>();
        CreateMap<Dealer, DealerPlatform.Dealers.DealerDto>();
        CreateMap<Dealer, Public.Dealers.DealerDto>();
        CreateMap<UsedCar, DealerPlatform.Cars.UsedCarDto>();
        CreateMap<UsedCar, Public.Cars.UsedCarDto>();
        CreateMap<Brand, Public.Cars.BrandDto>();
        CreateMap<Model, Public.Cars.ModelDto>();
        CreateMap<Trim, Public.Cars.TrimDto>().MapExtraProperties();
        CreateMap<ConfigurationItem, Public.Cars.ConfigurationItemDto>();
    }
}
