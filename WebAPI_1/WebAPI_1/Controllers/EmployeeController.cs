using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_1.Models;

namespace WebAPI_1.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class EmployeeController : ControllerBase
    {

        static List<Employee> employee = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "Pranaya" },
            new Employee() { Id = 2, Name = "Priyanka" },
            new Employee() { Id = 3, Name = "Anurag" },
            new Employee() { Id = 4, Name = "Sambit" }
        };

        // GET BY ID
        [HttpGet]
        [Route("{employeeId}")]
        public Employee GetStudentDetails(int employeeId)
        {
            Employee employeeDetails = employee.FirstOrDefault(s => s.Id == employeeId);
            return employeeDetails;
        }


        // GET BY NAME
        [HttpGet]
        [Route("{employeeName}")]
        public Employee GetStudentDetails(string employeeName)
        {
            Employee employeeDetails = employee.FirstOrDefault(s => s.Name == employeeName);
            return employeeDetails;


        }

    }
}
