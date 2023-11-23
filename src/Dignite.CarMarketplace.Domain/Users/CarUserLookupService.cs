using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Dignite.CarMarketplace.Users;

public class CarUserLookupService : UserLookupService<CarUser, ICarUserRepository>, ICarUserLookupService
{
    public CarUserLookupService(
        ICarUserRepository userRepository,
        IUnitOfWorkManager unitOfWorkManager)
        : base(
            userRepository,
            unitOfWorkManager)
    {

    }

    protected override CarUser CreateUser(IUserData externalUser)
    {
        return new CarUser(externalUser);
    }
}
