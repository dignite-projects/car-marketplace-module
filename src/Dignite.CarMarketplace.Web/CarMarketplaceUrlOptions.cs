using System;
using System.Collections.Generic;

namespace Dignite.CarMarketplace.Web
{
    public class CarMarketplaceUrlOptions
    {
        private string _routePrefix = "car-marketplace";

        /// <summary>
        /// Default value: "CarMarketplace";
        /// </summary>
        public string RoutePrefix
        {
            get => GetFormattedRoutePrefix();
            set => _routePrefix = value;
        }

        /// <summary>
        /// Used to specify ignore paths if the route prefix is null or empty.
        /// </summary>
        public List<string> IgnoredPaths { get; } = new ();

        private string GetFormattedRoutePrefix()
        {
            if (string.IsNullOrWhiteSpace(_routePrefix))
            {
                return "/";
            }

            return _routePrefix.EnsureEndsWith('/').EnsureStartsWith('/');
        }
    }
}
