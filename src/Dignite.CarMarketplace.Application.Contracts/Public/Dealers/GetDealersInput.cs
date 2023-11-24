using Volo.Abp.Application.Dtos;

namespace Dignite.CarMarketplace.Public.Dealers
{
    public class GetDealersInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
