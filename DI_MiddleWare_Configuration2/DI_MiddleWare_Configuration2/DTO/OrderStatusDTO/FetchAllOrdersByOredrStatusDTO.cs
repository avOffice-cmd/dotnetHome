namespace DI_MiddleWare_Configuration2.DTO.OrderStatusDTO
{
    public class FetchAllOrdersByOredrStatusDTO
    {
        public string OrderStatus { get; set; }

        public List<FetchOrdersDTO> Orders { get; set; }
    }
}
