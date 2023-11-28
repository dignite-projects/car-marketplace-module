using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dignite.CarMarketplace.Admin.Cars;

public class SaleCarAppService_Tests : CarMarketplaceApplicationTestBase
{
    private readonly ISaleCarAppService _saleCarAppService;

    public SaleCarAppService_Tests()
    {
        _saleCarAppService = GetRequiredService<ISaleCarAppService>();
    }

    [Fact]
    public async Task GetListAsync()
    {
        var input = new GetSaleCarsInput();
        var list = await _saleCarAppService.GetListAsync(input);

        list.Items.ShouldNotBeEmpty();
    }
}
