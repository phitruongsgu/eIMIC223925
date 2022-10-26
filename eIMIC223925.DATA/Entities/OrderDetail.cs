namespace eIMIC223925.DATA.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { set; get; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
