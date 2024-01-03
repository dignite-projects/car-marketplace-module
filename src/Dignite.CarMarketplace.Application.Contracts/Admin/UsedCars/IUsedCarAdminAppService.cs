using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Admin.UsedCars
{
    public interface IUsedCarAdminAppService: IReadOnlyAppService<UsedCarDto,Guid, GetUsedCarsInput>
    {
        Task DeleteAsync(Guid id);
    }
}
