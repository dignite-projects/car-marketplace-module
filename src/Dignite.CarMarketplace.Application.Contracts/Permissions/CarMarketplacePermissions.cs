using Volo.Abp.Reflection;

namespace Dignite.CarMarketplace.Permissions;

public class CarMarketplacePermissions
{
    public const string GroupName = "CarMarketplace";
    public static class SaleCars
    {
        public const string Default = GroupName + ".SaleCar";
        public const string Management = Default + ".Management";
    }
    public static class UsedCars
    {
        public const string Default = GroupName + ".UsedCar";
        public const string Management = Default + ".Management";
    }
    public static class Dealers
    {
        public const string Default = GroupName + ".Dealer";
        public const string Management = Default + ".Management";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CarMarketplacePermissions));
    }
}
