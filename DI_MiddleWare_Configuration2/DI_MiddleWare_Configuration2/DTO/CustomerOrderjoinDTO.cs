namespace DI_MiddleWare_Configuration2.DTO
{
   
        public class CustomerOrderjoinDTO
        {
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }

        public int OrderId { get; set; }
        public int Amount { get; set; }
        public string DeliveryCity { get; set; }
        public string OrderStatus { get; set; }
    }
    
}
