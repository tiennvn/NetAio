namespace TPos.Ordering
{
    /// <summary>
    /// Loại doanh thu đơn hàng
    /// - 1: Doanh thu đơn hàng đã hoàn thành
    /// - 2: Doanh thu dự kiến
    /// </summary>
    public enum OrderRevenueType
    {
        /// <summary>
        /// Doanh thu đơn hàng đã hoàn thành
        /// </summary>
        Revenue = 1,
        /// <summary>
        /// Doanh thu dự kiến
        /// </summary>
        ExpectRevenue = 2
    }
}
