using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.UsedCars
{
    public interface IUsedCarRepository : IBasicRepository<UsedCar, Guid>
    {
        Task<List<string>> GetAllModelColorsAsync();
        Task<List<string>> GetAllModelLevelsAsync();

        Task<int> GetCountAsync(
            UsedCarStatus? status = null,
            string filter = null,
            int? usedCarId = null,
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
            bool includeDetails=false,
            UsedCarStatus? status = null,
            string filter = null,
            int? usedCarId = null,
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
