namespace DI_MiddleWare_Configuration2.DTO
{
    public class FetchAllOrdersByCityDTO
    {
        public string DeliveryCity { get; set; }

        public List<FetchOrdersDTO> Orders { get; set; }
    }
}
