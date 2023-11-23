using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Dignite.CarMarketplace;

[Dependency(ReplaceServices = true)]
public class CarMarketplaceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CarMarketplace";
}
