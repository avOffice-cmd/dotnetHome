using DI_MiddleWare_Configuration2.DataAcessLayer;
using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DI_MiddleWare_Configuration2.Service
{
    public class OrderService : IOrderService
    {
        private readonly IorderRepository orderRepository;
        private readonly IcustomerRepository customerRepository;
      
        public OrderService(IorderRepository _orderRepository, IcustomerRepository _customerRepository)
        {
            orderRepository = _orderRepository;
            customerRepository = _customerRepository;
           
        }


        // ADD //
        public async Task AddOrder_Service(OrderDTO addOrderDTO)
        {

            var customersTable = await customerRepository.GetAllCustomers();
            var foundCustomer = customersTable
                            .FirstOrDefault(c => c.Id == addOrderDTO.CustomerId);

            var firstName = foundCustomer.Name.Split(' ')[0];

            Order order = new Order
            {
                InvoiceId = $"Ord_{firstName}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}",
                Total_Amt = addOrderDTO.Total_Amt,
                OrderDate = DateTime.Now,
                Quantity = addOrderDTO.Quantity,
                DeliveryCity = addOrderDTO.DeliveryCity,
                OrderStatus = addOrderDTO.OrderStatus,
               // DeliveryDate = DateTime.Now.AddDays(5), // Add 5 days to the current date
                CustomerId = (int)addOrderDTO.CustomerId
            };

            await orderRepository.AddOrder_Repo(order);
        }


        // Update //

        public async Task<Order> UpdateOrder_Service(int _orderId, string _orderStatus)
        {
            var getUpdatedOrder = await orderRepository.UpdateOrder_Repo(_orderId, _orderStatus);
            if (getUpdatedOrder == null) return null;
            return getUpdatedOrder;
        }


        // Delete
        public async Task<string> DeleteOrder_Service(int _orderId)
        {
            Order gotOrder = await orderRepository.GetOrderByID(_orderId);
            if (gotOrder == null) return "Order not found";

            string gotMessage = await orderRepository.DeleteOrder_Repo(_orderId);
            return gotMessage;
        }


        // get all orders

        #region  GetAllOrders


        public class OrderResult
        {
            public List<Order> Orders { get; set; }
            public string Message { get; set; }


        }

        public async Task<OrderResult> GetAllOrders()
        {
            var orderResult = new OrderResult();

            var getOrder = await orderRepository.GetAllOrders();

            if (getOrder.Any() == false)
            {
                orderResult.Orders = new List<Order>();
                orderResult.Message = "No order found.";
            }
            else
            {
                orderResult.Orders = getOrder;
                orderResult.Message = "Order retrieved successfully.";
            }

            return orderResult;
        }
        #endregion




    }
}
