using Dignite.CarMarketplace.UsedCars;
using System.Threading.Tasks;

namespace Dignite.CarMarketplace.Public.UsedCars
{
    public class UsedCarConsultationAppService: CarMarketplaceAppService, IUsedCarConsultationAppService
    {
        private readonly IUsedCarConsultationRepository _usedCarConsultationRepository;

        public UsedCarConsultationAppService(IUsedCarConsultationRepository usedCarConsultationRepository)
        {
            _usedCarConsultationRepository = usedCarConsultationRepository;
        }

        public async Task<UsedCarConsultationDto> CreateAsync(UsedCarConsultationCreateDto input)
        {
            var entity = new UsedCarConsultation(GuidGenerator.Create(), input.UsedCarId, input.ContactPerson, input.ContactNumber, input.ReservationTime);
            return ObjectMapper.Map<UsedCarConsultation, UsedCarConsultationDto>(
                await _usedCarConsultationRepository.InsertAsync(entity)
                );
        }
    }
}
