using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dignite.CarMarketplace.Admin.Dealers;

public class DealerAppService_Tests : CarMarketplaceApplicationTestBase
{
    private readonly IDealerAdminAppService _dealerAppService;

    public DealerAppService_Tests()
    {
        _dealerAppService = GetRequiredService<IDealerAdminAppService>();
    }

    [Fact]
    public async Task GetListAsync_Test()
    {
        var result = await _dealerAppService.GetListAsync(
            new GetDealersInput ()
            );
        result.TotalCount.ShouldNotBe(0);
    }
}
