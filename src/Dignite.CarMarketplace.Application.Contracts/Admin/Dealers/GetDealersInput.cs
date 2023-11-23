using Dignite.CarMarketplace.Dealers;
using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Admin.Dealers
{
    public class GetDealersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public AuthenticationStatus AuthenticationStatus { get; set; }
    }
}
