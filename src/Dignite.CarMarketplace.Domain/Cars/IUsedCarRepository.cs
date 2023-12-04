using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.Cars
{
    public interface IUsedCarRepository : IBasicRepository<UsedCar, Guid>
    {
        Task<int> GetCountAsync(
            CarStatus? status = null,
            string filter = null,
            Guid? brandId = null,
            Guid? modelId = null,
            Guid? dealerId = null,
            string color = null,
            DateTime? minRegistrationDate = null,
            DateTime? maxRegistrationDate = null,
            float? minTotalMileage = null,
            float? maxTotalMileage = null,
            float? minPrice = null,
            float? maxPrice = null,
            string transmissionType = null,
            string powerType = null,
            string modelLevel = null,
            Guid[] ids = null,
            CancellationToken cancellationToken = default);

        Task<List<UsedCar>> GetListAsync(
            CarStatus? status = null,
            string filter = null,
            Guid? brandId = null,
            Guid? modelId = null,
            Guid? dealerId = null,
            string color = null,
            DateTime? minRegistrationDate = null,
            DateTime? maxRegistrationDate = null,
            float? minTotalMileage = null,
            float? maxTotalMileage = null,
            float? minPrice = null,
            float? maxPrice = null,
            string transmissionType = null,
            string powerType = null,
            string modelLevel = null,
            Guid[] ids = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default);
    }
}
