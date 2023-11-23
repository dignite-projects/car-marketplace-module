using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dignite.CarMarketplace.DealerPlatform.Cars;

public class UsedCarAppService_Tests : CarMarketplaceApplicationTestBase
{
    private readonly IUsedCarAppService _usedCarAppService;

    public UsedCarAppService_Tests()
    {
        _usedCarAppService = GetRequiredService<IUsedCarAppService>();
    }

    [Fact]
    public async Task GetListAsync_Test()
    {
        var result = await _usedCarAppService.GetListAsync(
            new GetUsedCarsInput()
            );
        result.TotalCount.ShouldBe(0);
    }
}
