namespace TPos.Ordering
{
    /// <summary>
    /// Loại hình thức bán hàng của đơn hàng
    /// - 1: Bán nhanh
    /// - 2: Giao sau
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// Bán nhanh
        /// </summary>
        Fast = 1,
        /// <summary>
        /// Giao sau
        /// </summary>
        Normal = 2
    }
}
