using Volo.Abp.DependencyInjection;

namespace Dignite.CarMarketplace.Web.Pages
{
    public class CarMarketplacePageHelper: ITransientDependency
    {
        public string GetPriceFormatText(float price)
        {

            switch (price)
            {
                case >= 10000:
                    return $"{price/10000}万元";
                default:
                    return $"{price}元";
            }
        }
        public string GetMileageFormatText(float totalMileage)
        {

            switch (totalMileage)
            {
                case >= 10000:
                    return $"{totalMileage / 10000}万公里";
                default:
                    return $"{totalMileage}公里";
            }
        }
    }
}
