using Dignite.CarMarketplace.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Dignite.CarMarketplace.Web.Menus;

public class CarMarketplaceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CarMarketplaceResource>();

        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.UsedCars, displayName: l["Menu:UsedCar"], "~/UsedCars"));
        context.Menu.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.SaleCar, displayName: l["Menu:SaleCar"], "~/SaleCar"));
        context.Menu.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.Dealers, displayName: "Dealers", "~/Dealers"));

        return Task.CompletedTask;
    }
}
