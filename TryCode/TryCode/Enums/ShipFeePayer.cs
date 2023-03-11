namespace TPos.Ordering
{
    /// <summary>
    /// Đối tượng trả phí Ship. 
    /// - 0: Không có phí ship
    /// - 1: Người mua trả
    /// - 2: Người bán trả 
    /// - 3: Mỗi người trả 1 phần
    /// </summary>
    public enum ShipFeePayer
    {
        /// <summary>
        /// Không có phí ship
        /// </summary>
        None = 0,
        /// <summary>
        /// Người mua trả tiền ship
        /// </summary>
        Buyer = 1,
        /// <summary>
        /// Người bán trả tiền ship
        /// </summary>
        Seller = 2,
        /// <summary>
        /// Mỗi người trả 1 phần
        /// </summary>
        BuyerAndSeller = 3
    }
}
