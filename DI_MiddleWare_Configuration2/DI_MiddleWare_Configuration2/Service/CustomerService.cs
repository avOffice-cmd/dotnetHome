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


        // get all customers //

        #region  GetAllCustomers



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


        // GET CUSTOMER AND THEIR SPECIFIC ORDERS

        //===========================//
        //  get customerANDordersById //
        //===========================//

        //public async Task<List<Order>> GetCustomerSpecificOrders_Service(int _customerId)
        //{
        //    var gotAllOrders = await orderRepository.GetAllOrders();

        //    var customerSpecificOrders = 
        //        gotAllOrders.Where(o => o.CustomerId == _customerId)
        //                    .ToList();

        //    return customerSpecificOrders;

        //}

        public async Task<CustomerSpecificOrdersDTO> GetCustomerSpecificOrders_Service(int _customerId)
        {

            // get customer
            var gotCustomer = await customerRepository.GetCustomerByID(_customerId);

            // getting all orders list
            var gotAllOrders = await orderRepository.GetAllOrders();
            var customerSpecificOrders =
                gotAllOrders.Where(o => o.CustomerId == _customerId)
                            .ToList();

            #region
            // convert order list to orderviewdto list
            //var orderViewDTOList = new List<OrderViewDTO>();

            //foreach (var order in customerSpecificOrders)
            //{
            //    OrderViewDTO newOrderViewDTO = new OrderViewDTO()
            //    {
            //        InvoiceId = order.InvoiceId,
            //        Total_Amt = order.Total_Amt,
            //        Quantity = order.Quantity,
            //        DeliveryCity = order.DeliveryCity
            //    };

            //    orderViewDTOList.Add(newOrderViewDTO);

            //}
            #endregion

            var orderViewDTOList =
            customerSpecificOrders.Select(cso => new OrderViewDTO()
            {
                InvoiceId = cso.InvoiceId,
                Total_Amt = cso.Total_Amt,
                Quantity = cso.Quantity,
                DeliveryCity = cso.DeliveryCity

            }).ToList();


            CustomerSpecificOrdersDTO cs = new CustomerSpecificOrdersDTO()
            {
                customerName = gotCustomer.Name,
                customer_Orders = orderViewDTOList
            };


            return cs;

        }


        // DELETE CUSTOMERS AND THEIR SPECIFIC ORDERS
        public async Task<string> DeleteCustomerSpecificOrders_Service(int _customerId)
        {
            // Step 1: Check if customer exists with the given ID
            var gotCustomer = await customerRepository.GetCustomerByID(_customerId);

            if (gotCustomer == null)
            {
                // Customer not found, handle the error or return an appropriate response
                return "Customer does not exist"; // or throw an exception
            }

            // Step 2: Get all orders for the customer
            var gotAllOrders = await orderRepository.GetAllOrders();

            // Step 3: Filter orders for the specific customer
            var customerSpecificOrders = gotAllOrders
                    .Where(o => o.CustomerId == _customerId).ToList();

            // Step 4: Delete the customer-specific orders
            foreach (var order in customerSpecificOrders)
            {
                await orderRepository.DeleteOrder_Repo(order.Id);
                // Replace 'DeleteOrder' with the actual method you have in your repository to delete an order.
            }

            return "Orders deleted successfully";
        }



    }
}




