using DI_MiddleWare_Configuration.Context;
using DI_MiddleWare_Configuration.DataAccessLayer;
using DI_MiddleWare_Configuration.DTO;
using DI_MiddleWare_Configuration.Helper;
using DI_MiddleWare_Configuration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Extensions;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DI_MiddleWare_Configuration.Controllers
{
    /// <summary>
    /// This is order api which is being used to handle all order related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly Messages _messages;
        public OrderController(
            IOrderRepository orderRepo
            ,IOptions<Messages> messages)
        {
            _orderRepo = orderRepo;
            _messages = messages.Value; 
        }
        // GET: api/<OrderController>
        /// <summary>
        /// test summary
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            throw new Exception();
            return new string[] { "value1", _messages.InsertSuccessMessage };
        }

        /// <summary>
        /// This endpoint gives the orders placed by a customer
        /// </summary>
        /// <param name="customerId">CustomerId</param>
        /// <returns></returns>
        // GET api/<OrderController>/5
        [HttpGet("ByCustomerId/{customerId}")]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
            try
            {
                if (customerId <= 0)
                    return BadRequest("customer Id is incorrect");
                var customerOrders = await _orderRepo.GetCustomerOrders(customerId);
                if (!customerOrders.Any())
                    return NotFound("No customer or orders found for this customerid");
                return Ok(customerOrders);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Something Went Wrong. Exception: {ex.Message}");
            }
        }

        [HttpPost("CustomerOrder")]
        public async Task<IActionResult> AddCustomerOrder([FromBody] CustomerOrderDTO customerOrder)
        {
            try
            {
                if (customerOrder == null)
                {
                    return BadRequest("Bad data passed.");
                }
                Customer customer = new()
                {
                    Name = $"{customerOrder.FirstName} {customerOrder.LastName}",
                    Email = customerOrder.Email,
                    PhoneNumber = customerOrder.PhoneNumber,
                    Orders = new List<Order>
                {
                new ()
                {
                    InvoiceId=$"Ord_{customerOrder.FirstName}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}",
                    Total_Amt=customerOrder.Order.Total_Amt,
                    OrderDate=DateTime.Now,
                    DeliveryCity=customerOrder.Order.DeliveryCity,
                    OrderStatus=OrderStatus.Initiated.GetDisplayName()
                }
                }
                };
                
                await _orderRepo.AddCustomerOrder(customer);
                return Ok(_messages.InsertSuccessMessage);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"{_messages.InsertSuccessMessage}. Exception: {ex.Message}");
            }

        }

        [HttpPost("Order")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Bad data passed.");
                }
                Order orderObj = new()
                {
                    InvoiceId = $"Ord_{order.FirstName}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}",
                    Total_Amt = order.Total_Amt,
                    OrderDate = DateTime.Now,
                    DeliveryCity = order.DeliveryCity,
                    Quantity = order.Quantity,
                    OrderStatus = OrderStatus.Initiated.GetDisplayName(),
                    CustomerId = order.CustomerId.Value
                };
                await _orderRepo.AddOrder(orderObj);
                return Ok("Order created successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"{_messages.ExceptionMessage}. Exception: {ex.Message}");
            }

        }

        /// <summary>
        /// This endpoint is being used to update the order status
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <param name="status">Status</param>
        /// <returns></returns>
        [HttpPatch("Order/{orderId}/Status/{status}")]
        public async Task<IActionResult> UpdateDeliveryStatus(int orderId, OrderStatus status)
        {
            try
            {
                if (orderId <= 0)
                    return BadRequest("Order id is incorrect");
                var order = await _orderRepo.GetOrderById(orderId);
                if (order == null)
                    return NotFound($"No orders found for given order id: {orderId}");
                order.OrderStatus = status.GetDisplayName().ToString();
                order.DeliveryDate = status == OrderStatus.Delivered ? DateTime.Now : null;
                await _orderRepo.UpdateOrder(order);
                return Ok("Order Updated successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Something Went Wrong. Exception: {ex.Message}");
            }
        }
    }
}
