using Dignite.CarMarketplace.Dealers;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Dignite.CarMarketplace;

public class CarMarketplaceDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;
    private readonly IDealerRepository _dealerRepository;
    private readonly CarMarketplaceTestData _testData;

    public CarMarketplaceDataSeedContributor(IGuidGenerator guidGenerator, ICurrentTenant currentTenant, IDealerRepository dealerRepository, CarMarketplaceTestData testData)
    {
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _dealerRepository = dealerRepository;
        _testData = testData;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            await SeedDealersAsync();
        }
    }
    private async Task SeedDealersAsync()
    {
        var dealer = new Dealer(_guidGenerator.Create(), _testData.DealerName, "address", "contactPerson", "contactNumber", 1, 2, _currentTenant.Id);
        dealer.AddAdministrator(_testData.User1Id);
        await _dealerRepository.InsertAsync(dealer,autoSave: true);
    }
}
