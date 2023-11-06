using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DI_MiddleWare_Configuration2.DataAcessLayer
{
    public interface IcustomerRepository
    {
        Task AddCustomer_Repo(Customer customer);

        Task<Customer> UpdateCustomer_Repo(int customerId, string _customerName);

        Task<Customer> GetCustomerByID(int _customerID);
        Task<string> DeleteCustomer_Repo(int _customerId);
        Task<List<Customer>> GetAllCustomers();

        // Task<List<CustomerSpecificOrdersDTO>> GetCustomerOrders(int customerId);




    }
}
