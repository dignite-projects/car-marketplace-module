using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Dignite.CarMarketplace.Dealers
{
    public class DealerManager: DomainService
    {
        public DealerManager(IDealerRepository dealerRepository)
        {
            DealerRepository = dealerRepository;
        }

        protected IDealerRepository DealerRepository { get; }

        public async Task<Dealer> CreateAsync(string name, string shortName, string address, string contactPerson, string contactNumber, double? latitude, double? longitude, Guid userId)
        {
            var entity = await DealerRepository.FindByAdministratorAsync(userId, false);
            if (entity != null)
            {
                throw new DealerAlreadyExistException(userId);
            }

            entity = await DealerRepository.FindByShortNameAsync(shortName);
            if (entity != null)
            {
                throw new DealerShortNameAlreadyExistException(shortName);
            }


            entity = new Dealer(
                GuidGenerator.Create(),
                name, shortName, address, contactPerson, contactNumber, latitude, longitude, CurrentTenant.Id);
            entity.AddAdministrator(userId);
            return await DealerRepository.InsertAsync(entity);            
        }
    }
}
