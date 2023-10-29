

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csharp_practice_smartdata
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string department { get; set; }
        public int EmployeeAge { get; set; }
        public int EmployeeDepId { get; set; }
        public string gender { get; set; }
    }
    internal class crudabc
    {
        public void add_emp(List<Employee> employee, int eid, string eName, string edep, int age, int emp_id, string gender)
        {
            employee.Add(new Employee() { EmployeeId = eid, Name = eName, department = edep, EmployeeAge = age, EmployeeDepId = emp_id, gender = gender });

        }

        public void get(List<Employee> employee)
        {
            foreach (var a in employee)
            {
                Console.WriteLine(a.EmployeeId + " " + a.Name + " " + a.EmployeeDepId + " " + a.department + " " + a.EmployeeAge + " " + a.gender);
            }
        }

        public void UpdateEmployeeDepartment(List<Employee> employees, int empId, string newDepartment)
        {
            var employeeToUpdate = employees.FirstOrDefault(e => e.EmployeeId == empId);

            if (employeeToUpdate != null)
            {
                employeeToUpdate.department = newDepartment;
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

        }

        public void Remove(List<Employee> employee, int id)
        {
            employee.RemoveAll(e => e.EmployeeId == id);
        }
        static void Main(string[] args)
        {
            List<Employee> employee = new List<Employee>()
                {
                    new Employee() { EmployeeId = 1,Name = "Satyam",department="HR",EmployeeAge = 23,EmployeeDepId=101,gender="Male"},
                    new Employee() { EmployeeId = 2,Name = "Shubham",department="IT",EmployeeAge = 22,EmployeeDepId=102,gender="Male"},
                    new Employee() { EmployeeId = 3,Name = "Kashish",department="MS",EmployeeAge = 25,EmployeeDepId=103, gender = "Female"},
                    new Employee() { EmployeeId = 4,Name = "Somya",department="HR",EmployeeAge = 29,EmployeeDepId=101, gender = "Female"},
                    new Employee() { EmployeeId = 5,Name = "Khilesh",department="MS",EmployeeAge = 18,EmployeeDepId=103, gender = "Male", },
                    new Employee() { EmployeeId = 6,Name = "Sakshi",department="HR",EmployeeAge = 22,EmployeeDepId=101, gender = "Female"},
                    new Employee() { EmployeeId = 7,Name = "Rushikesh",department="IT",EmployeeAge = 21,EmployeeDepId=102, gender = "Male"},
                    new Employee() { EmployeeId = 8,Name = "Salil",department="MS",EmployeeAge = 26,EmployeeDepId=103, gender = "Male"},
                    new Employee() { EmployeeId = 9,Name = "Sagar",department="HR",EmployeeAge = 29,EmployeeDepId=101, gender = "Male"},
                    new Employee() { EmployeeId = 10,Name = "Sachin",department="IT",EmployeeAge = 30,EmployeeDepId=102, gender = "Male"},
                };
            crudabc p = new crudabc();


            p.add_emp(employee, 11, "rakesh", "MS", 23, 103, "Male");
            p.UpdateEmployeeDepartment(employee, 4, "Marketing");
            p.Remove(employee, 1);
            p.get(employee);


        }
    }
}

