namespace MyWebApiApp.Data
{
    public class Order
    {
        public enum OrderStatusEnum
        {
            New = 0,
            Payment = 1,
            Complete = 2,
            Cancelled = -1
        }

        public Guid OrderId { get; set; }
        public DateTime OrderDay { get; set; }
        public DateTime? ShipDay { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public string Receiver { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

    }
}
