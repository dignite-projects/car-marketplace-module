using System.Linq;

namespace Dignite.CarMarketplace.Web.Pages.Helpers
{
    public static class DealerNameControlHelper
    {
        public static readonly string[] ProhibitedFileExtensions = new string[] {"ico", "txt", "php"};

        public static bool IsProhibitedFileFormatName(string dealerShortName)
        {
            if (string.IsNullOrWhiteSpace(dealerShortName))
            {
                return false;
            }

            return ProhibitedFileExtensions.Any(x => dealerShortName.ToLowerInvariant().EndsWith(x));
        }
    }
}