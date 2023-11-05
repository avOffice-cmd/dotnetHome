using practice.DTOs;
using practice.Model;
using static practice.Services.CustomerService;

namespace practice.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerOrderjoinsDTOS>> GetCustomerOrder();
        Task<CustomerResult> GetAllCustomer();

        Task AddCustomer_Service(AddCustomerDTO dto);

        Task<string> DeleteCustomer_Service(int _customerId);

        Task<Customer> UpdateCustomer_Service(int _customerId, string _customerName);
    }
}
