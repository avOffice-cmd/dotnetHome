﻿using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Helper;
using DI_MiddleWare_Configuration2.Models;
using DI_MiddleWare_Configuration2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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

        // ADD //
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddOrder([FromBody] OrderDTO addOrderDTO)
        {
            await orderService.AddOrder_Service(addOrderDTO);
            return Ok("Order has been added");
        }


        // Update

        [HttpPatch]
        [Route("updateName")]
        [ProducesResponseType(200, Type = typeof(Order))]
        public async Task<ActionResult> UpdateOrderStatus(int _orderID, string _orderStatus)
        {

            Order gotResponse = await orderService.UpdateOrder_Service(_orderID, _orderStatus);
            if (gotResponse == null) return NotFound("Customer not found!");
            return Ok(gotResponse);

            //return StatusCode(200, gotResponse);
        }


        // Delete
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


        // GET customer //

        [HttpGet]
        [Route("getCustomer")]
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
    }
}