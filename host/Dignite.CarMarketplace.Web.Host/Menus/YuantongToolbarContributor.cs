using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Dignite.CarMarketplace.Components.Toolbar.LoginLink;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Users;
using Dignite.Abp.AspNetCore.Mvc.UI.Theme.Pure.Components.Toolbar.UserMenu;

namespace Dignite.CarMarketplace.Menus;

public class YuantongToolbarContributor : IToolbarContributor
{
    public virtual Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name != StandardToolbars.Main)
        {
            return Task.CompletedTask;
        }

        if (!context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginLinkViewComponent)));
        }
        else
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(UserMenuViewComponent)));
        }

        return Task.CompletedTask;
    }
}
