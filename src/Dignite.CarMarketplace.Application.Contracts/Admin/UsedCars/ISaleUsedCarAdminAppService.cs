using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Admin.UsedCars
{
    public interface ISaleUsedCarAdminAppService : IReadOnlyAppService<SaleUsedCarDto, Guid, GetSaleUsedCarsInput>
    {
    }
}
