using Volo.Abp.Domain.Entities;

namespace Dignite.CarMarketplace.DealerPlatform.Cars
{
    public class UsedCarUpdateDto:UsedCarCreateOrUpdateDtoBase, IHasConcurrencyStamp
    {
        public string ConcurrencyStamp { get; set; }
    }
}
