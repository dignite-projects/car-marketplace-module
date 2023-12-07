using Dignite.Abp.BlobStoring;
using Dignite.CarMarketplace.Dealers;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Dignite.CarMarketplace.BlobStoring;

public class DealerCoverBlobNameGenerator : IBlobNameGenerator, ITransientDependency
{
    private readonly IDealerRepository _dealerRepository;
    private readonly ICurrentUser _currentUser;

    public DealerCoverBlobNameGenerator(IDealerRepository dealerRepository, ICurrentUser currentUser)
    {
        _dealerRepository = dealerRepository;
        _currentUser = currentUser;
    }

    public async Task<string> Create()
    {
        var entity = await _dealerRepository.FindByAdministratorAsync(_currentUser.GetId(), true);
        return entity.Id.ToString("N");
    }
}
