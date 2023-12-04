using System;
using System.Collections.Generic;

namespace Dignite.CarMarketplace.Cars
{
    public class ConfigurationItemComparer : IEqualityComparer<ConfigurationItem>
    {
        public bool Equals(ConfigurationItem x, ConfigurationItem y)
        {
            return x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(ConfigurationItem obj)
        {
            return obj.Name.GetHashCode();
        }

    }
}
