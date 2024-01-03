using System;
using System.Collections.Generic;

namespace Dignite.CarMarketplace.Cars
{
    public class TrimConfigItemComparer : IEqualityComparer<TrimConfigItem>
    {
        public bool Equals(TrimConfigItem x, TrimConfigItem y)
        {
            return x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(TrimConfigItem obj)
        {
            return obj.Name.GetHashCode();
        }

    }
}
