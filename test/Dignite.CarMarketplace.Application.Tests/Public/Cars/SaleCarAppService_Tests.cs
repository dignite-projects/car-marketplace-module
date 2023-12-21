using Dignite.CarMarketplace.Public.UsedCars;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Dignite.CarMarketplace.Public.Cars;

public class SaleCarAppService_Tests : CarMarketplaceApplicationTestBase
{
    private readonly ISaleUsedCarAppService _saleCarAppService;
    private readonly CarMarketplaceTestData _testData;

    public SaleCarAppService_Tests()
    {
        _saleCarAppService = GetRequiredService<ISaleUsedCarAppService>();
        _testData = GetRequiredService<CarMarketplaceTestData>();
    }

    [Fact]
    public async Task CreateAsync()
    {
        var entity = await _saleCarAppService.CreateAsync(
            new SaleCarCreateDto { 
                ModelId= _testData.BmwModelId,
                RegistrationDate=DateTime.Now.AddYears(-5),
                TotalMileage=1,
                Address="北京市朝阳区",
                ContactPerson="王先生",
                ContactNumber="18611112222"
            }
            );
        entity.ShouldNotBeNull();
    }
}
