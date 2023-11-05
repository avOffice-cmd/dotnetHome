using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Models;
using static DI_MiddleWare_Configuration2.Service.CustomerService;

namespace DI_MiddleWare_Configuration2.Service
{
    public interface ICustomerService
    {
        Task AddCustomer_Service(CustomerDTO addCustomerDTO);

        Task<Customer> UpdateCustomer_Service(int _customerId, string _customerName);

        Task<string> DeleteCustomer_Service(int _customerId);

        Task<List<CustomerOrderjoinDTO>> GetCustomerOrder();

        Task<CustomerResult> GetAllCustomer();
    }
}
