using Dignite.CarMarketplace.Dealers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;
using Volo.CmsKit.Users;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers
{
    public class DealerAppService : CarMarketplaceAppService, IDealerAppService
    {
        private readonly IDealerRepository _dealerRepository;
        private readonly ICmsUserRepository _cmsUserRepository;
        private readonly DealerManager _dealerManager;

        public DealerAppService(IDealerRepository dealerRepository, ICmsUserRepository cmsUserRepository, DealerManager dealerManager)
        {
            _dealerRepository = dealerRepository;
            _cmsUserRepository = cmsUserRepository;
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
        public async Task<ListResultDto<CmsUserDto>> GetAdministratorsAsync()
        {
            var userId = CurrentUser.GetId();
            var entity = await _dealerRepository.FindByAdministratorAsync(CurrentUser.GetId(), true);
            var users = await _cmsUserRepository.GetListAsync(
                entity.Administrators.Select(a => a.UserId)
                .ToArray()
                );

            return new ListResultDto<CmsUserDto>(
                ObjectMapper.Map<List<CmsUser>, List<CmsUserDto>>(users)
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
            entity.UpdateInternal(input.Name,input.Address,input.ContactPerson,input.ContactNumber,input.Latitude,input.Longitude);
            entity.SetAuthenticationStatus(AuthenticationStatus.Waiting);
            await _dealerRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Dealer, DealerDto>(entity);
        }
    }
}
