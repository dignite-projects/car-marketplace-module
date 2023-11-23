using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Dignite.CarMarketplace.Dealers;

/* Write your custom repository tests like that, in this project, as abstract classes.
 * Then inherit these abstract classes from EF Core & MongoDB test projects.
 * In this way, both database providers are tests with the same set tests.
 */
public abstract class DealerRepository_Tests<TStartupModule> : CarMarketplaceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IDealerRepository _dealerRepository;

    protected DealerRepository_Tests()
    {
        _dealerRepository = GetRequiredService<IDealerRepository>();
    }

    [Fact]
    public async Task GetCountAsyncr()
    {
        (await _dealerRepository.GetCountAsync()).ShouldBe(1);
    }
}
