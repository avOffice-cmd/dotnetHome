using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Helper;
using DI_MiddleWare_Configuration2.Models;
using DI_MiddleWare_Configuration2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Extensions;
using System.Linq;
using System.Net;

namespace DI_MiddleWare_Configuration2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;
        private readonly Messages messages;

        public OrderController(IOrderService _orderService, IOptions<Messages> _messages)
        {
            orderService = _orderService;
            messages = _messages.Value;
        }

        // ADD ORDERS

        /// <summary>
        /// It is used to add the orders
        /// </summary>
        /// <param name="addOrderDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddOrder([FromBody] OrderDTO addOrderDTO)
        {
            await orderService.AddOrder_Service(addOrderDTO);
            return Ok("Order has been added");
        }




        // UPDATE ORDERS

        /// <summary>
        /// It is   used to update the order status
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <param name="status">Status</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("updateOrderStatus")]
        [ProducesResponseType(200, Type = typeof(Order))]
        public async Task<ActionResult> UpdateOrderStatus(int _orderID, OrderStatus _orderStatus)
        {
            try
            {
                if (_orderID <= 0)
                    return BadRequest("Order id is incorrect");

                var statusToString = _orderStatus.GetDisplayName().ToString();
                Order gotResponse = await orderService.UpdateOrder_Service(_orderID, statusToString);
                if (gotResponse == null) return NotFound("Customer not found!");
                return Ok(gotResponse);
            }
            catch (Exception ex) {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Something Went Wrong. Exception: {ex.Message}");
            }
           

            //return StatusCode(200, gotResponse);
        }




        // DELETE ORDERS

        /// <summary>
        ///It is used to delete the order
        /// </summary>
        /// <param name="_orderID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<ActionResult> DeleteOrder(int _orderID)
        {
            if(_orderID <= 0)
            {
                return BadRequest(messages.BadRequest);
            }

            string gotResponse = await orderService.DeleteOrder_Service(_orderID);
            return Ok(gotResponse);
            //return StatusCode(200, gotResponse);
        }





        // GET ALL ORDERS

        /// <summary>
        /// It is used to get all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getOrders")]
        [ProducesResponseType(200, Type = typeof(List<Order>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetAllOrders()
        {
            try
            {
                var getOrders = await orderService.GetAllOrders();

                if (getOrders.Orders.Any() == false)
                {
                    return NotFound(getOrders.Message);
                }

                return Ok(getOrders);
            }
            catch (Exception ex)
            {
                // Handle and log any exceptions that may occur during the operation.
                // You can customize the error message based on the specific exception.
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }




        // Get All Orders Specific City

        /// <summary>
        /// It is used to get all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllOrdersSpecificCity")]
        //[ProducesResponseType(200, Type = typeof(List<Order>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetAllOrdersSpecificCity()
        {

                var getOrders = await orderService.GetallOrdersBySpecificCity();
                return Ok(getOrders);
         
        }



        // Get All Orders Specific Status

        /// <summary>
        /// It is used to get all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllOrdersSpecificStatus")]
        //[ProducesResponseType(200, Type = typeof(List<Order>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetAllOrdersSpecificStatus()
        {

            var getOrders = await orderService.GetallOrdersBySpecificStatus();
            return Ok(getOrders);
        }

        //DeliveryCity : "mumbai",
        //InvoiceId :
        //        "Ord_dolly_06112023000153,Ord_rohit_06112023000208,Ord_rohit_06112023000358"

        [HttpGet]
        [Route("GetAllInvoiceOrderByCity")]
        //[ProducesResponseType(200, Type = typeof(List<Order>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetAllInvoiceOrderByCity()
        {

            var getOrders = await orderService.GetallInvoiceIdBySpecificCity();
            return Ok(getOrders);
        }


    }
}
