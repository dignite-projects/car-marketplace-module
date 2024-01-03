using Dignite.CarMarketplace.UsedCars;
using System.Threading.Tasks;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class SaleUsedCarPublicAppService : CarMarketplaceAppService, ISaleUsedCarPublicAppService
    {
        private readonly ISaleUsedCarRepository _saleCarRepository;

        public SaleUsedCarPublicAppService(ISaleUsedCarRepository saleCarRepository)
        {
            _saleCarRepository = saleCarRepository;
        }

        public async Task<SaleCarDto> CreateAsync(SaleCarCreateDto input)
        {
            var saleCar = await _saleCarRepository.InsertAsync(
                new SaleUsedCar(
                    GuidGenerator.Create(),
                    input.ModelId,
                    input.Description,
                    input.RegistrationDate,
                    input.TotalMileage,
                    input.Address,
                    input.ContactPerson,
                    input.ContactNumber,
                    CurrentTenant.Id
                ));
            return ObjectMapper.Map<SaleUsedCar, SaleCarDto>(saleCar);
        }
    }
}
