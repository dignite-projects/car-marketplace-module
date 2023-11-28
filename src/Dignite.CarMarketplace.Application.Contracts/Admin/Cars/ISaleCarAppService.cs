using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dignite.CarMarketplace.Admin.Cars
{
    public interface ISaleCarAppService : IReadOnlyAppService<SaleCarDto, Guid, GetSaleCarsInput>
    {
    }
}
