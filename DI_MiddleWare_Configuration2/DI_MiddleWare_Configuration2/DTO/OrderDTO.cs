namespace DI_MiddleWare_Configuration2.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Total_Amt { get; set; }
        public string DeliveryCity { get; set; }
        public string OrderStatus { get; set; }
        public int? CustomerId { get; set; }
    }
}
