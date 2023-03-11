using System.ComponentModel.DataAnnotations;

namespace TPos.Ordering
{
    /// <summary>
    /// Dữ liệu tìm kiếu và lọc
    /// </summary>
    public class OrderGetListDto
    {
        /// <summary>
        /// Hình thức bán hàng của đơn hàng
        /// </summary>
        public OrderType? Type { get; set; }
        /// <summary>
        /// Trạng thái đơn hàng
        /// </summary>
        public OrderStatus? Status { get; set; }
        /// <summary>
        /// ID khách hàng
        /// </summary>
        public long? CustomerID { get; set; }
        /// <summary>
        /// Trạng thái thanh toán của đơn hàng
        /// </summary>
        public BillStatus? BillStatus { get; set; }

        /// <summary>
        /// Hình thức vận chuyển
        /// </summary>
        public DeliveryType? DeliveryType { get; set; }
        /// <summary>
        /// Lọc theo ID đối tác vận chuyển / tên người giao hàng
        /// </summary>
        public long? ShipPartnerId { get; set; }
        /// <summary>
        /// Lọc từ ngày
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? FromTime { get; set; }
        /// <summary>
        /// Lọc đến ngày
        /// </summary>
		[DataType(DataType.Date)]
        public DateTime? ToTime { get; set; }
        /// <summary>
        /// Danh sách các tag đơn hàng
        /// </summary>
        public List<long> TagIds { get; set; } = new List<long>();
    }
}
