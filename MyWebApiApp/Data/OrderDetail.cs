namespace MyWebApiApp.Data
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Guid ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }

        //Realationship
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
