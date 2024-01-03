using Dignite.Abp.AspNetCore.Mvc.UI.Theme.Pure;
using Dignite.CarMarketplace.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace Dignite.CarMarketplace;

public class CarMarketplaceWebHostMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public CarMarketplaceWebHostMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            ConfigureMainMenu(context);
        }
        if (context.Menu.Name == StandardMenus.User)
        {
            AddLogoutItemToMenu(context);
        }
        if (context.Menu.Name == PureMenus.SiteMap)
        {
            await ConfigureSiteMapMenuAsync(context);
        }
    }

    private Task ConfigureMainMenu(MenuConfigurationContext context)
    {
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                    "Home",
                    "首页",
                    "~/"
                ));

        return Task.CompletedTask;
    }

    private void AddLogoutItemToMenu(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CarMarketplaceResource>();

        context.Menu.Items.Add(new ApplicationMenuItem(
            "Account.Manage",
            l["MyAccount"],
            $"{_configuration["AuthServer:Authority"]!.EnsureEndsWith('/')}Account/Manage",
            icon: "fa fa-cog",
            order: int.MaxValue - 1001,
            null,
            "_blank"
        ).RequireAuthenticated());

        context.Menu.Items.Add(new ApplicationMenuItem(
            "Account.Logout",
            l["Logout"],
            "~/Account/Logout",
            "fas fa-power-off",
            order: int.MaxValue - 1000
        ).RequireAuthenticated());
    }

    private Task ConfigureSiteMapMenuAsync(MenuConfigurationContext context)
    {
        var actionContextAccessor = context.ServiceProvider.GetRequiredService<IActionContextAccessor>();
        var urlHelperFactory = context.ServiceProvider.GetRequiredService<IUrlHelperFactory>();
        var urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        var l = context.GetLocalizer<CarMarketplaceResource>();
        var buy = "买二手车";
        var sale = "卖二手车";
        var dealers = "二手车商";
        context.Menu.AddGroup(new ApplicationMenuGroup(buy, l[$"{buy}"]));
        context.Menu.AddGroup(new ApplicationMenuGroup(sale, l[$"{sale}"]));
        context.Menu.AddGroup(new ApplicationMenuGroup(dealers, l[$"{dealers}"]));



        /* 买二手车 */
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "准新车",
                l["准新车"],
                urlHelper.Page("/CarMarketplace/UsedCars/Index", new { tagName="准新车" }),
                groupName: buy
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "急售车型",
                l["急售车型"],
                urlHelper.Page("/CarMarketplace/UsedCars/Index", new { tagName = "急售车型" }),
                groupName: buy
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "奥迪认证",
                l["奥迪认证"],
                urlHelper.Page("/CarMarketplace/UsedCars/Index", new { tagName = "奥迪认证" }),
                groupName: buy
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "入门练手",
                l["入门练手"],
                urlHelper.Page("/CarMarketplace/UsedCars/Index", new { minPrice = 0, maxPrice=10000 }),
                groupName: buy
            )
        );

        /* 卖二手车 */
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "我要卖车",
                l["我要卖车"],
                urlHelper.Page("/CarMarketplace/SaleUsedCar/Index"),
                groupName: sale
            )
        );

        /* 二手车商 */
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "我是车商",
                l["我是车商"],
                urlHelper.Page("/CarMarketplace/Dealers/Register"),
                groupName: dealers
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "查找二手车商",
                l["查找二手车商"],
                urlHelper.Page("/CarMarketplace/Dealers/Index"),
                groupName: dealers
            )
        );


        return Task.CompletedTask;
    }
}
