using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.Permissions;
using Microsoft.AspNetCore.Authorization;
using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization;
using Volo.Abp.Content;

namespace Dignite.CarMarketplace.Admin.Dealers
{
    public class DealerAdminAppService : CarMarketplaceAppService, IDealerAdminAppService
    {
        private readonly IDealerRepository _dealerRepository;

        public DealerAdminAppService(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task Authenticate(Guid id,AuthenticationStatus status)
        {
            var entity = await _dealerRepository.GetAsync(id);
            entity.SetAuthenticationStatus(status);
            await _dealerRepository.UpdateAsync(entity);
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task DeleteAsync(Guid id)
        {
            await _dealerRepository.DeleteAsync(id);
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task<DealerDto> GetAsync(Guid id)
        {
            var entity = await _dealerRepository.GetAsync(id);
            return ObjectMapper.Map<Dealer, DealerDto>(entity);
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task<IRemoteStreamContent> GetListAsExcelFileAsync(DealerExcelDownloadInput input)
        {
            var items = await _dealerRepository.GetListAsync(authenticationStatus: input.AuthenticationStatus);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Dealer>, List<DealerExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "经销商列表.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CarMarketplacePermissions.Dealers.Management)]
        public async Task<PagedResultDto<DealerDto>> GetListAsync(GetDealersInput input)
        {
            var count = await _dealerRepository.GetCountAsync(input.Filter,input.AuthenticationStatus);
            var result = await _dealerRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, input.AuthenticationStatus);
            return new PagedResultDto<DealerDto>(count, ObjectMapper.Map<List<Dealer>, List<DealerDto>>(result));
        }
    }
}
