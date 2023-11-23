namespace Dignite.CarMarketplace.Cars
{
    public static class UsedCarConsts
    {
        /// <summary>
        /// Maximum length of the car Name property.
        /// Default value: 256
        /// </summary>
        public static int MaxNameLength { get; set; } = 256;
        /// <summary>
        /// Maximum length of the car Description property.
        /// Default value: 512
        /// </summary>
        public static int MaxDescriptionLength { get; set; } = 512;

        /// <summary>
        /// Maximum length of the car 变速箱类型 property.
        /// </summary>
        public static int MaxTransmissionTypeLength { get; set; } = 8;

        /// <summary>
        /// Maximum length of the car 动力类型 property.
        /// </summary>
        public static int MaxPowerTypeLength { get; set; } = 16;

        /// <summary>
        /// Maximum length of the car 颜色 property.
        /// </summary>
        public static int MaxColorLength { get; set; } = 8;

        /// <summary>
        /// Maximum length of the car 车型级别 property.
        /// </summary>
        public static int MaxModelLevelLength { get; set; } = 16;
    }
}
