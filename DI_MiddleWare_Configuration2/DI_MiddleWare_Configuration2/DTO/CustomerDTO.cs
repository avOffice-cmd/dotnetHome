using DI_MiddleWare_Configuration2.validators;

namespace DI_MiddleWare_Configuration2.DTO
{
    public class CustomerDTO
    {

        [CheckName]
        public string Name { get; set; }

        [EmailCheck]
        public string Email { get; set; }

        [phoneNumberCheck]
        public string PhoneNumber { get; set; }
    }
}
