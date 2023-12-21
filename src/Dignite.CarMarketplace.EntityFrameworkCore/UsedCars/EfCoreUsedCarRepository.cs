using Dignite.CarMarketplace.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dignite.CarMarketplace.UsedCars;

public class EfCoreUsedCarRepository : EfCoreRepository<ICarMarketplaceDbContext, UsedCar, Guid>, IUsedCarRepository
{
    public EfCoreUsedCarRepository(IDbContextProvider<ICarMarketplaceDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<List<string>> GetAllModelColorsAsync()
    {
        return await (await GetDbSetAsync())
            .Where(uc => uc.Status == UsedCarStatus.Listing)
            .Select(uc => uc.Color)
            .Distinct()
            .ToListAsync();
    }

    public async Task<List<string>> GetAllModelLevelsAsync()
    {
        return await (await GetDbSetAsync())
            .Where(uc => uc.Status == UsedCarStatus.Listing)
            .Select(uc => uc.ModelLevel)
            .Distinct()
            .ToListAsync();
    }

    public async Task<int> GetCountAsync(
        UsedCarStatus? status = null, string filter = null, int? usedCarId = null, Guid? brandId = null, Guid? modelId = null,
        Guid? dealerId = null, string color = null, DateTime? minRegistrationDate = null, DateTime? maxRegistrationDate = null,
        float? minTotalMileage = null, float? maxTotalMileage = null, float? minPrice = null, float? maxPrice = null,
        string transmissionType = null, string powerType = null, string modelLevel = null, Guid[] ids = null,
        CancellationToken cancellationToken = default)
    {
        if (ids != null && !ids.Any())
        {
            return 0;
        }
        return await (await GetQueryableAsync(false, status, filter, usedCarId, brandId, modelId, dealerId, color,
         minRegistrationDate, maxRegistrationDate, minTotalMileage, maxTotalMileage,
        minPrice, maxPrice, transmissionType, powerType, modelLevel, ids))
        .CountAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<List<UsedCar>> GetListAsync(
        bool includeDetails = false,
        UsedCarStatus? status = null, string filter = null, int? usedCarId = null, Guid? brandId = null, Guid? modelId = null,
        Guid? dealerId = null, string color = null, DateTime? minRegistrationDate = null, DateTime? maxRegistrationDate = null,
        float? minTotalMileage = null, float? maxTotalMileage = null, float? minPrice = null, float? maxPrice = null,
        string transmissionType = null, string powerType = null, string modelLevel = null, Guid[] ids = null,
        int maxResultCount = int.MaxValue, int skipCount = 0, string sorting = null, CancellationToken cancellationToken = default)
    {
        if (ids != null && !ids.Any())
        {
            return new List<UsedCar>();
        }
        return await (await GetQueryableAsync(includeDetails, status, filter, usedCarId, brandId, modelId, dealerId, color,
         minRegistrationDate, maxRegistrationDate, minTotalMileage, maxTotalMileage,
          minPrice, maxPrice, transmissionType, powerType, modelLevel, ids))
            .OrderBy(sorting.IsNullOrEmpty() ? $"{nameof(UsedCar.CreationTime)} desc" : sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }
    public override async Task<IQueryable<UsedCar>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
    protected virtual async Task<IQueryable<UsedCar>> GetQueryableAsync(
        bool includeDetails = false,
         UsedCarStatus? status = null, string filter = null, int? usedCarId = null, Guid? brandId = null, Guid? modelId = null, Guid? dealerId = null, string color = null,
         DateTime? minRegistrationDate = null, DateTime? maxRegistrationDate = null, float? minTotalMileage = null, float? maxTotalMileage = null,
         float? minPrice = null, float? maxPrice = null, string transmissionType = null, string powerType = null, string modelLevel = null, Guid[] ids = null)
    {
        var queryable =
         includeDetails
            ? await WithDetailsAsync()
            : await GetDbSetAsync();

        return queryable
            .WhereIf(status.HasValue, e => e.Status == status.Value)
            .WhereIf(!filter.IsNullOrEmpty(), e => e.Name.Contains(filter))
            .WhereIf(usedCarId.HasValue, e => e.UsedCarId == usedCarId.Value)
            .WhereIf(brandId.HasValue, e => e.BrandId == brandId.Value)
            .WhereIf(modelId.HasValue, e => e.ModelId == modelId.Value)
            .WhereIf(dealerId.HasValue, e => e.DealerId == dealerId.Value)
            .WhereIf(!color.IsNullOrEmpty(), e => e.Color == color)
            .WhereIf(minRegistrationDate.HasValue, e => e.RegistrationDate > minRegistrationDate.Value)
            .WhereIf(maxRegistrationDate.HasValue, e => e.RegistrationDate < maxRegistrationDate.Value)
            .WhereIf(minTotalMileage.HasValue, e => e.TotalMileage > minTotalMileage.Value)
            .WhereIf(maxTotalMileage.HasValue, e => e.TotalMileage < maxTotalMileage.Value)
            .WhereIf(minPrice.HasValue, e => e.Price > minPrice.Value)
            .WhereIf(maxPrice.HasValue, e => e.Price < maxPrice.Value)
            .WhereIf(!transmissionType.IsNullOrEmpty(), e => e.TransmissionType == transmissionType)
            .WhereIf(!powerType.IsNullOrEmpty(), e => e.PowerType == powerType)
            .WhereIf(!modelLevel.IsNullOrEmpty(), e => e.ModelLevel == modelLevel)
            .WhereIf(ids != null && ids.Any(), e => ids.Contains(e.Id));
    }
}
