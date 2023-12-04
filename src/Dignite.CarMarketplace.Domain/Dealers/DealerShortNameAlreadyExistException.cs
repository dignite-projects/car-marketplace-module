using JetBrains.Annotations;
using Volo.Abp;

namespace Dignite.CarMarketplace.Dealers
{
    public class DealerShortNameAlreadyExistException : BusinessException
    {
        public DealerShortNameAlreadyExistException([NotNull] string name)
        {
            Code = CarMarketplaceErrorCodes.Dealers.ShortNameAlreadyExist;
            WithData(nameof(Dealer.ShortName), name);
        }
    }
}
