using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practice.DTOs;
using practice.Model;
using practice.Services;

namespace practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        // GET CustomerOrder//
        [HttpGet]
        [Route("getCustomerAndOrders")]
        [ProducesResponseType(200, Type = typeof(List<CustomerOrderjoinsDTOS>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> GetCustomerAndOrders()
        {
            try
            {
                var customerOrderDTOs = await customerService.GetCustomerOrder();

                if (customerOrderDTOs == null || !customerOrderDTOs.Any())
                {
                    return NotFound("No customer orders found.");
                }

                return Ok(customerOrderDTOs);
            }
            catch (Exception ex)
            {
                // Handle and log any exceptions that may occur during the operation.
                // You can customize the error message based on the specific exception.
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



        // GET customer //

        [HttpGet]
        [Route("getCustomer")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetCustomer()
        {
            try
            {
                var getCustomers = await customerService.GetAllCustomer();
                
                if (getCustomers.Customers.Any() == false)
                {
                    return NotFound(getCustomers.Message);
                }

                return Ok(getCustomers);
            }
            catch (Exception ex)
            {
                // Handle and log any exceptions that may occur during the operation.
                // You can customize the error message based on the specific exception.
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



        // POST customer //
        /// <summary>
        /// Adds a customer in the database
        /// </summary>
        /// <param name="addCustomerDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddCustomer([FromBody] AddCustomerDTO addCustomerDTO)
        {
            await customerService.AddCustomer_Service(addCustomerDTO);
            return Ok("Customer has been added");
        }


        // delete //
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<ActionResult> DeleteCustomer(int _customerID)
        {
            string gotResponse = await customerService.DeleteCustomer_Service(_customerID);
            return Ok(gotResponse);
            //return StatusCode(200, gotResponse);
        }


        // update //
        [HttpPatch]
        [Route("updateName")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        public async Task<ActionResult> UpdateCustomerName(int _customerID, string _customerName)
        {

            Customer gotResponse = await customerService.UpdateCustomer_Service(_customerID, _customerName);
            if (gotResponse == null) return NotFound("Customer not found!");
            return Ok(gotResponse);

            //return StatusCode(200, gotResponse);
        }
    }


}
