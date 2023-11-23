namespace Dignite.CarMarketplace.Cars
{
    public enum CarStatus
    {
        /// <summary>
        /// 尚未上架
        /// </summary>
        Waiting,

        /// <summary>
        /// 上架销售中
        /// </summary>
        Listing,

        /// <summary>
        /// 已下架
        /// </summary>
        OffShelf,

        /// <summary>
        /// 已售出
        /// </summary>
        Sold
    }
}
