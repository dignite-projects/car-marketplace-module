using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Dignite.CarMarketplace;

[Dependency(ReplaceServices = true)]
public class CarMarketplaceBrandingProvider : DefaultBrandingProvider
{
    public override string? LogoUrl => "/images/logo.png";
    public override string AppName => "燃点二手车演示";
}
