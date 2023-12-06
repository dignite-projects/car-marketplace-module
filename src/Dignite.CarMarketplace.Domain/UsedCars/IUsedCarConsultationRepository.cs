using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.UsedCars
{
    public interface IUsedCarConsultationRepository : IBasicRepository<UsedCarConsultation, Guid>
    {
        Task<int> GetCountAsync(
            string filter = null,
            Guid? dealerId=null,
            CancellationToken cancellationToken = default
        );

        Task<List<UsedCarConsultation>> GetListAsync(
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            Guid? dealerId = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );
    }
}
