using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.UsedCars;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    public class BuyUsedCarDealerPlatformAppService : CarMarketplaceAppService, IBuyUsedCarDealerPlatformAppService
    {
        private readonly IBuyUsedCarRepository _usedCarConsultationRepository;
        private readonly IDealerRepository _dealerRepository;

        public BuyUsedCarDealerPlatformAppService(IBuyUsedCarRepository usedCarConsultationRepository, IDealerRepository dealerRepository)
        {
            _usedCarConsultationRepository = usedCarConsultationRepository;
            _dealerRepository = dealerRepository;
        }

        [Authorize]
        public async Task<BuyUsedCarDto> GetAsync(Guid id)
        {
            var consultation = await _usedCarConsultationRepository.GetAsync(id);
            var dealer = await _dealerRepository.GetAsync(consultation.UsedCar.DealerId);
            await AuthorizationService.CheckAsync(dealer, CommonOperations.UsedCarManage);
            return ObjectMapper.Map<BuyUsedCar, BuyUsedCarDto>(consultation);
        }

        [Authorize]
        public async Task<PagedResultDto<BuyUsedCarDto>> GetListAsync(GetBuyUsedCarsInput input)
        {
            var dealer = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(), false);
            var count = await _usedCarConsultationRepository.GetCountAsync(input.Filter, dealer.Id);
            var list = await _usedCarConsultationRepository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Filter, dealer.Id, true);
            return new PagedResultDto<BuyUsedCarDto>(count,
                ObjectMapper.Map<List<BuyUsedCar>, List<BuyUsedCarDto>>(list)
                );
        }
    }
}
