namespace DI_MiddleWare_Configuration.DTO
{
    public class CustomerOrderDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public OrderDTO Order { get; set; }
    }

    
}
