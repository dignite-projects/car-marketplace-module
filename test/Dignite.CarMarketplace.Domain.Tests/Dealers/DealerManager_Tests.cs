using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dignite.CarMarketplace.Dealers;

public class DealerManager_Tests : CarMarketplaceDomainTestBase
{
    private readonly DealerManager _dealerManager;
    private readonly CarMarketplaceTestData _testData;

    public DealerManager_Tests()
    {
        _dealerManager = GetRequiredService<DealerManager>();
        _testData = GetRequiredService<CarMarketplaceTestData>();
    }

    [Fact]
    public async Task CreateAsync_Test()
    {
        var newDealer = await _dealerManager.CreateAsync("TestDealerName", "TestDealerShortName","TestDealerAddress", "TestDealerContactPerson", "TestDealerContactNumber", 1, 2, _testData.User2Id);
        newDealer.ShouldNotBeNull();
        newDealer.Administrators.ShouldContain(a => a.UserId == _testData.User2Id);
    }
}
