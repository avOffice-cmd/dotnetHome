using DI_MiddleWare_Configuration2.DataAcessLayer;
using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Models;
using DI_MiddleWare_Configuration2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DI_MiddleWare_Configuration2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IcustomerRepository customerRepository;
        public IConfiguration configuration { get; }
        public CustomerController(ICustomerService _customerService,
                                    IcustomerRepository _customerRepository,
                                    IConfiguration _configuration)
        {
            customerService = _customerService;
            customerRepository = _customerRepository;
            configuration = _configuration;
        }


        // get customer using joins //
        [HttpGet]
        [Route("getCustomerAndOrders")]
        [ProducesResponseType(200, Type = typeof(CustomerOrderjoinDTO))]
        public async Task<ActionResult> GetCustomerAndOrders()
        {
            var getJoins = await customerService.GetCustomerOrder();
            return Ok(getJoins);
        }

        // ADD //
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddCustomer([FromBody] CustomerDTO addCustomerDTO)
        {

            try
            {
                if(addCustomerDTO == null)
                {
                    return BadRequest("Customer not found");
                }
                await customerService.AddCustomer_Service(addCustomerDTO);
                return Ok("Customer has been added");
            }
            catch (Exception ex)
            {
             //   return StatusCode((int)HttpStatusCode.InternalServerError, $"{_messages.InsertSuccessMessage}. Exception: {ex.Message}");
             return BadRequest(ex.Message);
            }
           
        }

        // Update

        /// <summary>
        /// Changes the name of the customer
        /// </summary>
        /// <param name="_customerID"></param>
        /// <param name="_customerName"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("updateName")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        public async Task<ActionResult> UpdateCustomerName(int _customerID, string _customerName)
        {
            try
            {
                if (_customerID <= 0)
                    return BadRequest("Customer id is incorrect");

                Customer gotResponse = await customerService.UpdateCustomer_Service(_customerID, _customerName);
                if (gotResponse == null) return NotFound("Customer not found!");
                return Ok(gotResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
         

            //return StatusCode(200, gotResponse);
        }

         
        // Delete
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<ActionResult> DeleteCustomer(int _customerID)
        {

            try
            {
                if (_customerID <= 0)
                {
                    // ModelState.AddModelError("CustomerID", "Customer ID must be greater than 0");
                    return BadRequest(ModelState);
                }
                string gotResponse = await customerService.DeleteCustomer_Service(_customerID);

                if (string.IsNullOrEmpty(gotResponse))
                {
                    return NotFound("Customer not found!");
                }
                return Ok(gotResponse);
                //return StatusCode(200, gotResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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


        // get customerORorders details using customerId //

        [HttpGet("ByCustomerId/{customerId}")]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
            try
            {
                if (customerId <= 0)
                    return BadRequest("customer Id is incorrect");
                var customerOrders = await customerRepository.GetCustomerOrders(customerId);
                if (!customerOrders.Any())
                    return NotFound("No customer or orders found for this customerid");
                return Ok(customerOrders);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Something Went Wrong. Exception: {ex.Message}");
            }
        }



        [HttpGet]
        [Route("getAppSettings")]
        public async Task<ActionResult> getappsettings()
        {
            // direct keys
            //return Ok(configuration["name"]);

            // nested keys
            //return Ok(configuration["Messages:ExceptionMessage"]);
            return Ok(configuration["a:b:c:d:ErrorMesssage"]);
        }
    }
}
