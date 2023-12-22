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

        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.UsedCars, displayName: l["Menu:UsedCar"], routePrefix+"used-car"));
        context.Menu.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.SaleUsedCar, displayName: l["Menu:SaleUsedCar"], routePrefix+"sale-used-car"));
        context.Menu.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.Dealers, displayName: l["Menu:Dealers"], routePrefix + "dealer"));

        return Task.CompletedTask;
    }
}
