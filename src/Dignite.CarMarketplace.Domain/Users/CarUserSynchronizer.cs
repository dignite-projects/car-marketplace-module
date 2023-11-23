using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Users;

namespace Dignite.CarMarketplace.Users;

public class CarUserSynchronizer :
    IDistributedEventHandler<EntityUpdatedEto<UserEto>>,
    ITransientDependency
{
    protected ICarUserRepository UserRepository { get; }

    protected ICarUserLookupService UserLookupService { get; }

    public CarUserSynchronizer(
        ICarUserRepository userRepository,
        ICarUserLookupService userLookupService)
    {
        UserRepository = userRepository;
        UserLookupService = userLookupService;
    }

    public virtual async Task HandleEventAsync(EntityUpdatedEto<UserEto> eventData)
    {
        var user = await UserRepository.FindAsync(eventData.Entity.Id);
        if (user == null)
        {
            user = await UserLookupService.FindByIdAsync(eventData.Entity.Id);
            if (user == null)
            {
                return;
            }
        }

        if (user.Update(eventData.Entity))
        {
            await UserRepository.UpdateAsync(user);
        }
    }
}
