using System;
using System.Collections.Generic;
using System.Text;

namespace Dignite.CarMarketplace.Public.Cars
{
    public class ModelCompanyDto
    {
        public string Name { get; set; }

        public IReadOnlyList<ModelDto> Models { get; set; }
    }
}
