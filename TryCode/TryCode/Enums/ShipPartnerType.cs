namespace TPos.Ordering
{
    /// <summary>
    /// Loại đơn vị vận chuyển. 
    /// - 1: Đối tác vận chuyển
    /// - 2: Dịch vụ giao hàng
    /// </summary>
    public enum ShipPartnerType
    {
        /// <summary>
        /// Đối tác vận chuyển
        /// </summary>
        DeliveryPartner = 1,
        /// <summary>
        /// Dịch vụ giao hàng
        /// </summary>
        ShippingUnit = 2
    }
}
