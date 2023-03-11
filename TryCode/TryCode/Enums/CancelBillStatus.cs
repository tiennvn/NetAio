namespace TPos.Ordering
{
    /// <summary>
    /// Trạng thái thanh toán của đơn hàng.
    /// - 0: Chưa xử lý
    /// - 1: Đã tạo phiếu chi hoàn trả
    /// - 2: Đã hủy tất cả phiếu thu
    /// </summary>
    public enum CancelBillStatus
    {
        /// <summary>
        /// Chưa xử lý
        /// </summary>
        None = 0,
        /// <summary>
        /// Đã tạo phiếu chi hoàn trả
        /// </summary>
        SpendingCreated = 1,
        /// <summary>
        /// Đã hủy tất cả phiếu thu
        /// </summary>
        AllTakingCanceled = 2
    }
}
