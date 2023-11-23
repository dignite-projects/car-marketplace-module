using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.Users;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers
{
    public class DealerAppService : CarMarketplaceAppService, IDealerAppService
    {
        private readonly IDealerRepository _dealerRepository;
        private readonly ICarUserRepository _carUserRepository;
        private readonly DealerManager _dealerManager;

        public DealerAppService(IDealerRepository dealerRepository, ICarUserRepository carUserRepository, DealerManager dealerManager)
        {
            _dealerRepository = dealerRepository;
            _carUserRepository = carUserRepository;
            _dealerManager = dealerManager;
        }

        [Authorize]
        public async Task AddAdministrator(Guid userId)
        {
            var userDealer = await _dealerRepository.FindByAdministratorAsync(userId);
            if (userDealer == null)
            {
                var entity = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(), true);
                entity.AddAdministrator(userId);
                await _dealerRepository.UpdateAsync(entity);
            }
            else
            {
                throw new DealerAlreadyExistException(userId);
            }
        }

        [Authorize]
        public async Task<DealerDto> CreateAsync(DealerCreateDto input)
        {
            var entity = await _dealerManager.CreateAsync(input.Name,input.Address,input.ContactPerson,input.ContactNumber,input.Latitude,input.Longitude,CurrentUser.GetId());
            return ObjectMapper.Map<Dealer, DealerDto>(entity);
        }

        [Authorize]
        public async Task<DealerDto> FindByCurrentUserAsync()
        {
            var entity = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(), false);
            return ObjectMapper.Map<Dealer, DealerDto>(entity);
        }

        [Authorize]
        public async Task<ListResultDto<CarUserDto>> GetAdministratorsAsync()
        {
            var entity = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(), true);
            var users = await _carUserRepository.GetListAsync(
                entity.Administrators.Select(a => a.UserId)
                .ToArray()
                );

            return new ListResultDto<CarUserDto>(
                ObjectMapper.Map<List<CarUser>, List<CarUserDto>>(users)
                );
        }

        [Authorize]
        public async Task RemoveAdministratorAsync(Guid userId)
        {
            if (userId == CurrentUser.GetId())
            {
                return;
            }
            var entity = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(), true);
            entity.RemoveAdministrator(userId);
            await _dealerRepository.UpdateAsync(entity);
        }

        [Authorize]
        public async Task<DealerDto> UpdateAsync(Guid id, DealerUpdateDto input)
        {
            var entity = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(), false);
            entity.Update(input.Name,input.Address,input.ContactPerson,input.ContactNumber,input.Latitude,input.Longitude);
            entity.SetAuthenticationStatus(AuthenticationStatus.Waiting);
            await _dealerRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Dealer, DealerDto>(entity);
        }
    }
}
