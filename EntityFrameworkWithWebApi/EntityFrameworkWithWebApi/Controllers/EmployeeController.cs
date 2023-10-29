using EntityFrameworkWithWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkWithWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        // GET REQUEST TO GET ALL EMPLOYEE
        [HttpGet("All", Name = "GetAllEmployee")]
        public ActionResult GetAllEmployee()
        {
            using(MyDbContext context =  new MyDbContext())
            {
                var EmployeeTable = context.Employees.ToList();
                return Ok(EmployeeTable);
            }
        }



        // GET EMPLOYEE BY ID

        [HttpGet]
        [Route("{id:int?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult GetEmployeeById(int id)
        {
            if (id <= 0) return BadRequest("Id should be greater than zero");

            using (MyDbContext context = new MyDbContext())
            {
                var founfEmp = context.Employees.Find(id);
                if (founfEmp == null) return NotFound("Employee not found");
                return Ok(founfEmp);
            }
        }




        // POST METHOD

        [HttpPost]
        [Route("addEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        // The [FromBody] attribute is used to specify that the emp
        // parameter should be bound from the request body.
        // This means that the data for the emp parameter is expected
        // to be sent in the HTTP request's body, typically in a format such as JSON or XML.
        // The model binder will take care of deserializing the request body data into the Employee object.
        public ActionResult AddEmployee([FromBody] EmployeeModel emp)
        {
            using (MyDbContext context = new MyDbContext())
            {
                EmployeeModel newEmployee = new EmployeeModel()
                {
                    FullName = emp.FullName,
                    Salary = emp.Salary
                };

                context.Employees.Add(newEmployee);
                context.SaveChanges();
                return Ok("Employee Created or we can say added");
            }
        }

        // PATCH
        [HttpPatch]
        [Route("{id:int?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public ActionResult updateEmployee(int id , string fullName)
        {
            if (id <= 0) return BadRequest("Id should be greater than zero");
            using (MyDbContext context = new MyDbContext())
            {
                var foundEmployee = context.Employees.Find(id);

                if (foundEmployee == null) return BadRequest("Employee not found");

                foundEmployee.FullName = fullName;
                context.SaveChanges();
                return Ok(foundEmployee);

            }
        }


        // DELETE //
        [HttpDelete("{id:min(1):max(100)}", Name = "DeleteStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest(); // Return a 400 Bad Request response when the ID is invalid.
            }

           using(MyDbContext context = new MyDbContext())
            {
                var foundEmployee = context.Employees.Find(id);

                if (foundEmployee == null) return NotFound("EMployee not found");

                context.Employees.Remove(foundEmployee);
                context.SaveChanges();
                return Ok("Employee deleted");
            }
        }

    }
}
