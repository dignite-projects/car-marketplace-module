using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Dignite.CarMarketplace.Pages;

public class IndexModel : CarMarketplacePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
