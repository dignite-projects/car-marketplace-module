using Dignite.CarMarketplace.Dealers;

namespace Dignite.CarMarketplace.Admin.Dealers
{
    public class DealerExcelDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }

        public AuthenticationStatus AuthenticationStatus { get; protected set; }
    }
}
