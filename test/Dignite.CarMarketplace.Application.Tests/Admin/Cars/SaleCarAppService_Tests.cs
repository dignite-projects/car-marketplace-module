using Dignite.CarMarketplace.Admin.UsedCars;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Dignite.CarMarketplace.Admin.Cars;

public class SaleCarAppService_Tests : CarMarketplaceApplicationTestBase
{
    private readonly ISaleUsedCarAdminAppService _saleCarAppService;

    public SaleCarAppService_Tests()
    {
        _saleCarAppService = GetRequiredService<ISaleUsedCarAdminAppService>();
    }

    [Fact]
    public async Task GetListAsync()
    {
        var input = new GetSaleUsedCarsInput();
        var list = await _saleCarAppService.GetListAsync(input);

        list.Items.ShouldNotBeEmpty();
    }
}
