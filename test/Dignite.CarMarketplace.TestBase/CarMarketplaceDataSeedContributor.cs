using Dignite.CarMarketplace.Cars;
using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.UsedCars;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;
using Volo.CmsKit.Users;

namespace Dignite.CarMarketplace;

public class CarMarketplaceDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;
    private readonly IDealerRepository _dealerRepository;
    private readonly ICmsUserRepository _cmsUserRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IModelRepository _modelRepository;
    private readonly ISaleUsedCarRepository _saleCarRepository;
    private readonly CarMarketplaceTestData _testData;

    public CarMarketplaceDataSeedContributor(IGuidGenerator guidGenerator, ICurrentTenant currentTenant, IDealerRepository dealerRepository, ICmsUserRepository cmsUserRepository, IBrandRepository brandRepository, IModelRepository modelRepository,
        ISaleUsedCarRepository saleCarRepository,
        CarMarketplaceTestData testData)
    {
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _dealerRepository = dealerRepository;
        _cmsUserRepository = cmsUserRepository;
        _brandRepository = brandRepository;
        _modelRepository = modelRepository;
        _saleCarRepository = saleCarRepository;
        _testData = testData;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            await SeedDealersAsync();
            await SeedUsersAsync();
            await SendBrandsAsync();
            await SendModelAsync();
            await SendSaleCarAsync();
        }
    }
    private async Task SeedDealersAsync()
    {
        var dealer = new Dealer(_guidGenerator.Create(), _testData.DealerName, _testData.DealerShortName, "address", "contactPerson", "contactNumber", 1, 2, _currentTenant.Id);
        dealer.AddAdministrator(_testData.User1Id);
        await _dealerRepository.InsertAsync(dealer,autoSave: true);
    }
    private async Task SeedUsersAsync()
    {
        await _cmsUserRepository.InsertAsync(new CmsUser(new UserData(_testData.User1Id, "user1",
            "user1@volo.com",
        "user", "1")),
        autoSave: true);

        await _cmsUserRepository.InsertAsync(new CmsUser(new UserData(_testData.User2Id, "user2",
            "user2@volo.com",
            "user", "2")),
            autoSave: true);
    }
    private async Task SendBrandsAsync()
    {
        await _brandRepository.InsertAsync(
            new Brand(_testData.BmwBrandId, _testData.BmwBrandName, "B", 0),
        autoSave: true
            );
    }
    private async Task SendModelAsync()
    {
        await _modelRepository.InsertAsync(
            new Model(_testData.BmwModelId,_testData.BmwBrandId,"华晨宝马", _testData.BmwBrandName, 0),
        autoSave: true
            );
    }
    private async Task SendSaleCarAsync()
    {
        await _saleCarRepository.InsertAsync(
            new SaleUsedCar(_testData.SaleCarlId,_testData.BmwModelId,null,DateTime.Now.AddYears(-3),3,"北京大兴","李先生","13900011112",null),
        autoSave: true
            );
    }
}
