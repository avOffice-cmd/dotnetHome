namespace DI_MiddleWare_Configuration.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public float Total_Amt { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string DeliveryCity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
