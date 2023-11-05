using Microsoft.AspNetCore.Http.HttpResults;
using practice.DataAcessLayer;
using practice.DTOs;
using practice.Model;

namespace practice.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepisitory customerRepository;
        public readonly IOrderRepository orderRepository;

        public CustomerService(ICustomerRepisitory _customerRepisitory, IOrderRepository _orderRepository)
        {
            customerRepository = _customerRepisitory;
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

            var getCustomer = await customerRepository.GetAllCustomer();

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


        #region Using Join To Get Customer

        public async Task<List<CustomerOrderjoinsDTOS>>  GetCustomerOrder()
        {
            var customersTable = await customerRepository.GetAllCustomer();
            var ordersTable = await orderRepository.GetAllOrders();


            var join = customersTable.Join(
                    ordersTable,
                    c => c.Customer_Id,
                    o => o.Customer_Id,
                    (c, o) => new CustomerOrderjoinsDTOS
                    {
                        Customer_Id = c.Customer_Id,
                        Customer_Name = c.Customer_Name,
                        OrderId = o.Id,
                        Amount = o.Amount,
                        OrderStatus = o.OrderStatus,
                        DeliveryLocation = o.DeliveryLocation,
                    }
                ).ToList();

            return join;
        }

        #endregion


        #region Add Customers
        public async Task AddCustomer_Service(AddCustomerDTO addCustomerDTO)
        {
            Customer customer = new Customer
            {
                Customer_Name = addCustomerDTO.Customer_Name,
                Customer_Email = addCustomerDTO.Customer_Email,
                createdAt = DateTime.Now
            };

            await customerRepository.AddCustomer_Repo(customer);
        }

        #endregion

        #region Delete customer

        public async Task<string> DeleteCustomer_Service(int _customerId)
        {
            Customer gotCustomer = await customerRepository.GetCustomerByID(_customerId);
            if (gotCustomer == null) return "Customer not found";

            string gotMessage = await customerRepository.DeleteCustomer_Repo(_customerId);
            return gotMessage;
        }

        #endregion


        #region
        public async Task<Customer> UpdateCustomer_Service(int _customerId, string _customerName)
        {
            var getUpdatedCustomer = await customerRepository.UpdateCustomer_Repo(_customerId, _customerName);
            if (getUpdatedCustomer == null) return null;
            return getUpdatedCustomer;
        }

        #endregion

    }
}
