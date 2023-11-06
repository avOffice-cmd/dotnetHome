namespace DI_MiddleWare_Configuration.DTO
{
    public class OrderViewDTO
    {
        public string InvoiceId { get; set; }
        public int Quantity { get; set; }
        public float Total_Amt { get; set; }
        public string DeliveryCity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
