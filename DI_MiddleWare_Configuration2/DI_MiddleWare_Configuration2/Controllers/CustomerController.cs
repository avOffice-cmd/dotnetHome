using DI_MiddleWare_Configuration2.DataAcessLayer;
using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Models;
using DI_MiddleWare_Configuration2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace DI_MiddleWare_Configuration2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly ILogger<CustomerController> logger;
       
        public IConfiguration configuration { get; }
        public CustomerController(ICustomerService _customerService,
                                    IConfiguration _configuration,
                                    ILogger<CustomerController> logger)
        {
            customerService = _customerService;
            configuration = _configuration;
            this.logger = logger;
        }


        // get customer using joins //
        /// <summary>
        /// It is used to get the customers and orders details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getCustomerAndOrders")]
        [ProducesResponseType(200, Type = typeof(CustomerOrderjoinDTO))]
        public async Task<ActionResult> GetCustomerAndOrders()
        {
            var getJoins = await customerService.GetCustomerOrder();
            return Ok(getJoins);
        }

        // ADD //
        /// <summary>
        /// It is used to add the customers
        /// </summary>
        /// <param name="addCustomerDTO"></param>
        /// <returns></returns>
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
        /// It is used to Changes the name of the customer
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
        /// <summary>
        /// It is used to delete the orders
        /// </summary>
        /// <param name="_customerID"></param>
        /// <returns></returns>
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

                //if (string.IsNullOrEmpty(gotResponse))
                //{
                //    return NotFound("Customer not found!");
                //}

                return Ok(gotResponse);
                //return StatusCode(200, gotResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



        // Delete
        /// <summary>
        /// It is used to delete the customers and their orders
        /// </summary>
        /// <param name="_customerID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleted")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<ActionResult> DeleteCustomerWithOrders(int _customerID)
        {

            if (_customerID <= 0)
            {
                logger.LogWarning("Bad request");
                return BadRequest("customer Id is incorrect");
            }
               
            var result = await customerService.DeleteCustomerSpecificOrders_Service(_customerID);


            if (result == null)
            {

                logger.LogError("custo,er not found with the given Id");
                // Customer not found, return a 404 Not Found response or handle the error appropriately.
                return NotFound("Customer not found");
            }

            // You can return a success message if needed
            return Ok("Customer and their orders deleted successfully");
        }


   




        // GET customer //
        /// <summary>
        /// It is used to get the all customers
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("getCustomer")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetCustomer()
        {

            logger.LogInformation("get method started");
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
        /// <summary>
        /// Used to get customer specific orders
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>

        [HttpGet("ByCustomerId/{customerId}")]
        public async Task<IActionResult> GetCustomerSpecificOrders(int customerId)
        {

            if (customerId <= 0)
            {
                logger.LogWarning("Bad request");
                return BadRequest("customer Id is incorrect");
            }
            var customerOrders = await customerService
                                    .GetCustomerSpecificOrders_Service(customerId);
            return Ok(customerOrders);
            //if (!customerOrders.Any())
            //    return NotFound("No customer or orders found for this customerid");
            // return Ok(customerOrders);

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



        // LOGGER //
        [HttpGet]
        [Route("logger")]
        public ActionResult Index()
        {

            // all are log level messages
            logger.LogTrace("Log msg from trace");
            logger.LogInformation("log msg from loginformation");
            logger.LogDebug("log msg from log debug");
            logger.LogWarning("log msg from logwarning");
            logger.LogError("log msg from logError");
            logger.LogCritical("log msg from logcritical");


            return Ok();
        }
    }
}
