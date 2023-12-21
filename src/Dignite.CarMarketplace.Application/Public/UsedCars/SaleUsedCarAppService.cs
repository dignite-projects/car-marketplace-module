using Dignite.CarMarketplace.UsedCars;
using System.Threading.Tasks;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class SaleUsedCarAppService : CarMarketplaceAppService, ISaleUsedCarAppService
    {
        private readonly ISaleUsedCarRepository _saleCarRepository;

        public SaleUsedCarAppService(ISaleUsedCarRepository saleCarRepository)
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
