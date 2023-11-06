namespace DI_MiddleWare_Configuration2.DTO
{
    public class CustomerSpecificOrdersDTO
    {
        public string customerName { get; set; }
     
        public List<OrderViewDTO> customer_Orders { get; set; }
      
    }
}
