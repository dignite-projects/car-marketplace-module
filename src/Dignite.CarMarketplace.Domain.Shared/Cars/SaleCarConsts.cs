namespace Dignite.CarMarketplace.Cars
{
    public static class SaleCarConsts
    {
        /// <summary>
        /// Maximum length of the car Description property.
        /// Default value: 512
        /// </summary>
        public static int MaxDescriptionLength { get; set; } = 512;

        public static int MaxAddressLength { get; set; } = 256;
        public static int MaxContactPersonLength { get; set; } = 16;
        public static int MaxContactNumberLength { get; set; } = 32;
    }
}
