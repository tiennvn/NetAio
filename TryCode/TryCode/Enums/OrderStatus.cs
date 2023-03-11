namespace TPos.Ordering
{
    /// <summary>
    /// Trạng thái đơn hàng. 
    /// - 1: Chờ xác nhận
    /// - 2: Chuẩn bị hàng
    /// - 3: Đang giao
    /// - 4: Hoàn thành
    /// - 5: Đã hủy
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Chờ xác nhận
        /// </summary>
        Waiting = 1,
        /// <summary>
        /// Chuẩn bị hàng
        /// </summary>
        Preparing = 2,
        /// <summary>
        /// Đang giao
        /// </summary>
        Delivering = 3,
        /// <summary>
        /// Hoàn thành
        /// </summary>
        Finished = 4,
        /// <summary>
        /// Đã hủy
        /// </summary>
        Cancelled = 5
    }
}
