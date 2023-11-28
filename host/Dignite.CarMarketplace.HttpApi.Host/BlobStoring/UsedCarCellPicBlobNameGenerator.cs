using Dignite.Abp.BlobStoring;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Dignite.CarMarketplace.BlobStoring;

public class UsedCarCellPicBlobNameGenerator : IBlobNameGenerator, ITransientDependency
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsedCarCellPicBlobNameGenerator(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<string> Create()
    {
        var query = _httpContextAccessor.HttpContext.Request.Query;
        var cellName = query["CellName"][0];
        var entityId = query["EntityId"][0];
        return Task.FromResult(
            entityId + "/" + cellName
            );
    }
}
