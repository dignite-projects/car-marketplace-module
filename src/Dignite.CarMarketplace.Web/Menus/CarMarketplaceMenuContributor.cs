using Dignite.CarMarketplace.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
        var urlOptions = context.ServiceProvider.GetRequiredService<IOptions<CarMarketplaceUrlOptions>>()
            .Value;

        var routePrefix = urlOptions.RoutePrefix;

        var l = context.GetLocalizer<CarMarketplaceResource>();


        // 二手车市场
        var carMarketplaceMenuItem = new ApplicationMenuItem(
                CarMarketplaceMenus.Prefix,
                l["CarMarketplace"]
            );
        carMarketplaceMenuItem.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.Prefix, displayName: l["CarMarketplace"], routePrefix));
        carMarketplaceMenuItem.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.UsedCars, displayName: l["Menu:UsedCar"], routePrefix + "used-car"));
        carMarketplaceMenuItem.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.SaleUsedCar, displayName: l["Menu:SaleUsedCar"], routePrefix + "sale-used-car"));
        carMarketplaceMenuItem.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.Dealers, displayName: l["Menu:Dealers"], routePrefix + "dealer"));
        context.Menu.AddItem(carMarketplaceMenuItem);

        return Task.CompletedTask;
    }
}
