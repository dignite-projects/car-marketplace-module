using Dignite.CarMarketplace.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Dignite.CarMarketplace.Permissions;

public class CarMarketplacePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CarMarketplacePermissions.GroupName, L("Permission:CarMarketplace"));

        var saleCars = myGroup.AddPermission(CarMarketplacePermissions.SaleCars.Default, L("Permission:SaleCars"));
        saleCars.AddChild(CarMarketplacePermissions.SaleCars.Management, L("Permission:Management"));

        var usedCars = myGroup.AddPermission(CarMarketplacePermissions.UsedCars.Default, L("Permission:UsedCars"));
        usedCars.AddChild(CarMarketplacePermissions.UsedCars.Management, L("Permission:Management"));

        var dealers = myGroup.AddPermission(CarMarketplacePermissions.Dealers.Default, L("Permission:Dealers"));
        dealers.AddChild(CarMarketplacePermissions.Dealers.Management, L("Permission:Management"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CarMarketplaceResource>(name);
    }
}
