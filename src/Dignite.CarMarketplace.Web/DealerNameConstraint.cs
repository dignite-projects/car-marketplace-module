using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

namespace Dignite.CarMarketplace.Web;

public class DealerNameConstraint : IRouteConstraint
{
    protected CarMarketplaceUrlOptions CarMarketplaceUrlOptions { get; }

    public DealerNameConstraint(IOptions<CarMarketplaceUrlOptions> carMarketplaceUrlOptions)
    {
        CarMarketplaceUrlOptions = carMarketplaceUrlOptions.Value;
    }
    
    public virtual bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (CarMarketplaceUrlOptions.RoutePrefix != "/" || !CarMarketplaceUrlOptions.IgnoredPaths.Any())
        {
            return true;
        }
        
        var displayUrl = httpContext.Request.GetDisplayUrl();
        
        if (CarMarketplaceUrlOptions.IgnoredPaths.Any(path => displayUrl.Contains(path, StringComparison.InvariantCultureIgnoreCase)))
        {
            return false;
        }

        return true;
    }
}