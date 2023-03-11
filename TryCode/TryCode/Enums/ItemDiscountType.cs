namespace TPos.Ordering
{
    /// <summary>
    /// Loại giảm giá của sản phẩm:
    /// - 1: Không giảm giá
    /// - 2: Giảm theo giá trị
    /// - 3: Giảm theo phần trăm
    /// - 4: Giảm theo giá trị và phần trăm
    /// </summary>
    public enum ItemDiscountType
    {
        /// <summary>
        /// Không giảm giá
        /// </summary>
        None = 1,
        /// <summary>
        /// giá trị
        /// </summary>
        Value = 2,
        /// <summary>
        /// phần trăm
        /// </summary>
        Percent = 3,
        /// <summary>
        /// phần trăm
        /// </summary>
        Both = 4
    }
}
