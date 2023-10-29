using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice_smartdata
{
    internal class crudOperation
    {
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class CRUD
        {
            List<Employee> employees;

            public CRUD(List<Employee> _list)
            {
                employees = _list;
            }

            public void GetAllEmployees()
            {
                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.Id} : {employee.Name}");
                }
            }

            public void GetEmployeeById(int _id)
            {
                var query = employees.Where(emp => emp.Id == _id);
                foreach (var emp in query)
                {
                    Console.WriteLine($"{emp.Id} : {emp.Name}");
                }
            }

            public void AddEmployee(int _id, string _name)
            {
                Employee newEmployee = new Employee() { Id = _id, Name = _name };
                employees.Add(newEmployee);
            }

            public void UpdateEmployee(int _id, string _name)
            {
                foreach (var emp in employees)
                {
                    if (emp.Id == _id)
                    {
                        emp.Name = _name;
                    }
                }
            }

            public void DeleteEmployee(int _id)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i].Id == _id)
                    {
                        employees.RemoveAt(i);
                    }
                }
                //foreach (var emp in employees)
                //{
                //    if (emp.Id == _id)
                //    {
                //        employees.Remove(emp);
                //    }
                //    else
                //    {
                //        Console.WriteLine("e");
                //    }
                //}
            }
        }

       
        
            public static void Main(string[] args)
            {
                List<Employee> empList = new List<Employee>();
                CRUD crud = new CRUD(empList);

                crud.AddEmployee(1, "Salil");
                crud.AddEmployee(2, "Vijay Sir");
                crud.AddEmployee(3, "Henry");
                //crud.GetEmployeeById(1);
                //crud.GetAllEmployees();
                //crud.UpdateEmployee(1, "Rohit");
                crud.DeleteEmployee(2);
                crud.GetAllEmployees();

            
        }
    }
}
