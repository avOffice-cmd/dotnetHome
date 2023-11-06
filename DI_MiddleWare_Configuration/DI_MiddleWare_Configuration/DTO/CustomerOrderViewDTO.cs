namespace DI_MiddleWare_Configuration.DTO
{
    public class CustomerOrderViewDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<OrderViewDTO> Orders { get; set; }
    }
}
