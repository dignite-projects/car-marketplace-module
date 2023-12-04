using System;
using Volo.Abp.DependencyInjection;

namespace Dignite.CarMarketplace;

public class CarMarketplaceTestData : ISingletonDependency
{
    public Guid User1Id { get; } = Guid.NewGuid();

    public string User1UserName => "fake.user";

    public Guid User2Id { get; } = Guid.NewGuid();

    public string DealerName = "NewDealerName";

    public string DealerShortName = "NewDealerShortName";

    public string BmwBrandName = "Bmw";
    public Guid BmwBrandId { get; } = Guid.NewGuid();

    public string BmwModelName = "Bmw 330i";
    public Guid BmwModelId { get; } = Guid.NewGuid();
    public Guid SaleCarlId { get; } = Guid.NewGuid();
}
