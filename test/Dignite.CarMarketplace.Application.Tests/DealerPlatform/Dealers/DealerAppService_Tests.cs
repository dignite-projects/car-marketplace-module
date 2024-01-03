using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers;

public class DealerAppService_Tests : CarMarketplaceApplicationTestBase
{
    private readonly IDealerPlatformAppService _dealerAppService;

    public DealerAppService_Tests()
    {
        _dealerAppService = GetRequiredService<IDealerPlatformAppService>();
    }

    [Fact]
    public async Task GetAdministratorsAsync_Test()
    {
        var result = await _dealerAppService.GetAdministratorsAsync();
        result.Items.Count.ShouldBe(1);
    }
}
