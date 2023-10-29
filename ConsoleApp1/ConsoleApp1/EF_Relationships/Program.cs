using ConsoleApp1.EF_Relationships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EF_Relationships
{
    internal class Program
    { 
        public static void Main(string[] args)
        {
         #region insertion
        //    using (EF_RelationsDBContext context = new EF_RelationsDBContext())
        //    {
        //        OfficeFloor officeFloor1 = new OfficeFloor
        //        {
        //            Floor_Name = "1st_Floor"
        //        };
        //        OfficeFloor officeFloor2 = new OfficeFloor
        //        {
        //            Floor_Name = "2nd_Floor"
        //        };

        //        context.OfficeFloors.Add(officeFloor1);
        //        context.OfficeFloors.Add(officeFloor2);
        //        context.SaveChanges();

        //        Employee emp1 = new Employee
        //        {
        //            Name = "Salil",
        //            Tech = "MS",
        //            AvailCanteenService = true,
        //            OfficeFloorId = 1
        //        };
        //        Employee emp2 = new Employee
        //        {
        //            Name = "Anchu",
        //            Tech = "MS",
        //            AvailCanteenService = false,
        //            OfficeFloorId = 1
        //        };

        //        context.Employees.Add(emp1);
        //        context.Employees.Add(emp2);
        //        context.SaveChanges();
        //    }

           #endregion

            //JoinEmployeeAndFloor();
            WithoutUsingJoins();
        }

        public static void JoinEmployeeAndFloor()
        {
            using (EF_RelationsDBContext context = new EF_RelationsDBContext())
            {
                var query = context.Employees.Join(
                        context.OfficeFloors,
                        emp => emp.OfficeFloorId,
                        floor => floor.FloorId,
                        (emp, floor) => new
                        {
                            emp_name = emp.Name,
                            emp_tech = emp.Tech,
                            floor_name = floor.Floor_Name
                        });

                foreach (var emp in query)
                {
                    Console.WriteLine($"{emp.emp_name} : {emp.emp_tech} : {emp.floor_name}");
                }
            }
        }

        public static void WithoutUsingJoins()
        {
            using (EF_RelationsDBContext context = new EF_RelationsDBContext())
            {
                var query = from emp in context.Employees
                            select new
                            {
                                Name = emp.Name,
                                Tech = emp.Tech,
                                Floor = emp.OfficeFloor.Floor_Name
                            };

                foreach (var emp in query)
                {
                    Console.WriteLine($"{emp.Name} : {emp.Tech} : {emp.Floor}");
                }
            }
        }
    }
}
