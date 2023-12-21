using Dignite.CarMarketplace.UsedCars;
using System.Threading.Tasks;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class BuyUsedCarAppService: CarMarketplaceAppService, IBuyUsedCarAppService
    {
        private readonly IBuyUsedCarRepository _usedCarConsultationRepository;

        public BuyUsedCarAppService(IBuyUsedCarRepository usedCarConsultationRepository)
        {
            _usedCarConsultationRepository = usedCarConsultationRepository;
        }

        public async Task<BuyUsedCarDto> CreateAsync(BuyUsedCarCreateDto input)
        {
            var entity = new BuyUsedCar(GuidGenerator.Create(), input.UsedCarId, input.ContactPerson, input.ContactNumber, input.ReservationTime);
            return ObjectMapper.Map<BuyUsedCar, BuyUsedCarDto>(
                await _usedCarConsultationRepository.InsertAsync(entity)
                );
        }
    }
}
