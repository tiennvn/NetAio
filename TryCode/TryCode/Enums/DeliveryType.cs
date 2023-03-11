namespace TPos.Ordering
{
    /// <summary>
    /// Loại giao hàng: 
    /// - 1: Đối tác vận chuyển
    /// - 2: Tự giao
    /// </summary>
    public enum DeliveryType
    {
        /// <summary>
        /// Đối tác vận chuyển
        /// </summary>
        PartnerShip = 1,
        /// <summary>
        /// Tự giao
        /// </summary>
        SelfShip = 2

    }
}
