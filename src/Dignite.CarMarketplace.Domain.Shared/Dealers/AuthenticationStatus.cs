namespace Dignite.CarMarketplace.Dealers
{
    /// <summary>
    /// 车商的认证状态
    /// </summary>
    public enum AuthenticationStatus
    {
        /// <summary>
        /// 等待审批
        /// </summary>
        Waiting,
        /// <summary>
        /// 批准
        /// </summary>
        Approved,
        
        /// <summary>
        /// 不批准
        /// </summary>
        Disapproved,

        /// <summary>
        /// 被取消的
        /// </summary>
        Cancelled
    }
}
