using Dignite.CarMarketplace.Cars;
using System.Threading.Tasks;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class SaleCarAppService : CarMarketplaceAppService, ISaleCarAppService
    {
        private readonly ISaleCarRepository _saleCarRepository;

        public SaleCarAppService(ISaleCarRepository saleCarRepository)
        {
            _saleCarRepository = saleCarRepository;
        }

        public async Task<SaleCarDto> CreateAsync(SaleCarCreateDto input)
        {
            var saleCar = await _saleCarRepository.InsertAsync(
                new SaleCar(
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
            return ObjectMapper.Map<SaleCar, SaleCarDto>(saleCar);
        }
    }
}
