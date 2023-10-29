using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Hello.Linq
{
    public class Operator
    {

        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>()
            {
              new Employee(){Id = 1, Name = "Tom", Email = "Tom@gmail.com"},
              new Employee(){Id = 2, Name = "achal", Email = "achal@gmail.com"},
              new Employee(){Id = 3, Name = "salil", Email = "salil@gmail.com"},
              new Employee(){Id = 4, Name = "xyz", Email = "xyz@gmail.com"},
              new Employee(){Id = 5, Name = "abc", Email = "abc@gmail.com"}

            };

            // get all records
            var basicQuery = (from emp in employees
                             select emp).ToList();


            // method syntax
            var basicMethod = employees.ToList();

            //------some opreations-------//
            //1] select all id's
            // type of this variable is list of integers

            var basicPropQuery = (from emp in employees
                                  select emp.Id).ToList();
            // increase id by 1
            var basicProp = (from emp in employees
                                  select emp.Id+1).ToList();

            // convert id into string
            var basicProp1 = (from emp in employees
                             select emp.Id.ToString()).ToList();

            // using method
            var basicPropMethod = employees.Select(emp => emp.Name).ToList();

            // In all the records select only id and name
            //var selectQuery = (from emp in employees
            //                   select new Employee()
            //                   {
            //                       Id = emp.Id,
            //                       Email = emp.Email
            //                   }).ToList();


            //foreach ( var emp in basicQuery )
            //{
            //    Console.WriteLine($"Id = {emp.Id}, Name = {emp.Name}");
            //}




            /////// convert in to student class //////

            var selectQuery = (from emp in employees
                               select new student()
                               {
                                   StudentId = emp.Id,
                                   StEmail = emp.Email
                               }).ToList();

            // using method
            var selectMethod = employees.Select(emp => new student()
            {
                StudentId = emp.Id,
                StEmail = emp.Email,
                FullName = emp.Name
            }).ToList();


            // anonymous
            var selectQuery1 = (from emp in employees
                               select new
                               {
                                   CustomId = emp.Id,
                                   CustomEmail = emp.Email,
                                   CustomName = emp.Name

                               }).ToList();

            //  using method

            var selectMethod2 = employees.Select(emp => new {
                CustomId = emp.Id,
                CustomEmail = emp.Email,
                CustomName = emp.Name
            }).ToList();


            foreach (var emp in selectMethod2)
            {
                Console.WriteLine($"Id = {emp.CustomId}, Name = {emp.CustomEmail}");
            }
            Console.ReadLine();
        }
    }
}
