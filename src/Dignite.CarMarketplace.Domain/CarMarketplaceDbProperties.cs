namespace Dignite.CarMarketplace;

public static class CarMarketplaceDbProperties
{
    public static string DbTablePrefix { get; set; } = "cmp";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "CarMarketplace";
}
