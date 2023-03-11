namespace TPos.Ordering
{
    /// <summary>
    /// Trạng thái thanh toán của đơn hàng.
    /// - 1: Chưa thanh toán
    /// - 2: Thanh toán 1 phần
    /// - 3: Đã thanh toán
    /// </summary>
    public enum BillStatus
    {
        /// <summary>
        /// Chưa thanh toán
        /// </summary>
        Unpaid = 1,
        /// <summary>
        /// Thanh toán 1 phần
        /// </summary>
        Partial = 2,
        /// <summary>
        /// Đã thanh toán
        /// </summary>
        Completed = 3
    }
}
