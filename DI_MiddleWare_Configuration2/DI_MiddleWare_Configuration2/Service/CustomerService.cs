using DI_MiddleWare_Configuration2.DataAcessLayer;
using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DI_MiddleWare_Configuration2.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly IcustomerRepository customerRepository;
        private readonly IorderRepository orderRepository;

        public CustomerService(IcustomerRepository _customerRepository, IorderRepository _orderRepository)
        {
            customerRepository = _customerRepository;
            orderRepository = _orderRepository;
           
        }


        #region  GetAllCustomers

        // get all customers //

        public class CustomerResult
        {
            public List<Customer> Customers { get; set; }
            public string Message { get; set; }


        }

        public async Task<CustomerResult> GetAllCustomer()
        {
            var customerResult = new CustomerResult();

            var getCustomer = await customerRepository.GetAllCustomers();

            if (getCustomer.Any() == false)
            {
                customerResult.Customers = new List<Customer>();
                customerResult.Message = "No customers found.";
            }
            else
            {
                customerResult.Customers = getCustomer;
                customerResult.Message = "Customers retrieved successfully.";
            }

            return customerResult;
        }
        #endregion


        // ADD //
        public async Task AddCustomer_Service(CustomerDTO addCustomerDTO)
        {
            Customer customer = new Customer
            {
               Name = addCustomerDTO.Name,
               Email = addCustomerDTO.Email,    
               PhoneNumber = addCustomerDTO.PhoneNumber
            };

            await customerRepository.AddCustomer_Repo(customer);
        }

        // Update //

        public async Task<Customer> UpdateCustomer_Service(int _customerId, string _customerName)
        {
            var getUpdatedCustomer = await customerRepository.UpdateCustomer_Repo(_customerId, _customerName);
            if (getUpdatedCustomer == null) return null;
            return getUpdatedCustomer;
        }


        // Delete
        public async Task<string> DeleteCustomer_Service(int _customerId)
        {
            Customer gotCustomer = await customerRepository.GetCustomerByID(_customerId);
            if (gotCustomer == null) return "Customer not found";

            string gotMessage = await customerRepository.DeleteCustomer_Repo(_customerId);
            return gotMessage;
        }

        //===========================//
        //  get customerANDorders   //
        //===========================//
        public async Task<List<CustomerOrderjoinDTO>> GetCustomerOrder()
        {
            var customersTable = await customerRepository.GetAllCustomers();
            var ordersTable = await orderRepository.GetAllOrders();



            var join = customersTable.Join(
                    ordersTable,
                    c => c.Id,
                    o => o.Id,
                    (c, o) => new CustomerOrderjoinDTO
                    {
                        Customer_Id = c.Id,
                        Customer_Name = c.Name,
                        OrderId = o.Id,
                        Amount = (int)o.Total_Amt,
                        OrderStatus = o.OrderStatus,
                        DeliveryCity = o.DeliveryCity,
                    }
                ).ToList();

            return join;

        }


        //===========================//
        //  get customerANDordersById //
        //===========================//

       
    }
}
