using Dignite.CarMarketplace.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.UsedCars
{
    public class EfCoreUsedCarConsultationRepository : EfCoreRepository<ICarMarketplaceDbContext, UsedCarConsultation, Guid>, IUsedCarConsultationRepository
    {
        public EfCoreUsedCarConsultationRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<int> GetCountAsync(string filter = null, Guid? dealerId = null, CancellationToken cancellationToken = default)
        {
            return await(await GetQueryableAsync(filter, dealerId))
            .CountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<UsedCarConsultation>> GetListAsync(int maxResultCount = int.MaxValue, int skipCount = 0, string filter = null, Guid? dealerId = null, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await(await GetQueryableAsync(filter, dealerId))
                .IncludeDetails(includeDetails)
                .OrderByDescending(c=>c.CreationTime)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public override async Task<IQueryable<UsedCarConsultation>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }

        protected virtual async Task<IQueryable<UsedCarConsultation>> GetQueryableAsync(
             string filter = null, Guid? dealerId = null)
        {
            return (await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrEmpty(), e => e.ContactPerson.Contains(filter))
                .WhereIf(dealerId.HasValue, e => e.UsedCar.DealerId == dealerId.Value);
        }
    }
}
