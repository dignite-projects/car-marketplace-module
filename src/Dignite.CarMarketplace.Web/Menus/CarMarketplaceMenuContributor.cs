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
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CarMarketplaceMenus.Prefix, displayName: "CarMarketplace", "~/CarMarketplace", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
