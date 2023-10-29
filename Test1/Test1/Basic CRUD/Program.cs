using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Basic_CRUD
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // add
            //AddEmployee("salil", 50000);
            //AddEmployee("achal", 40000);
            //AddEmployee("Kantara", 19999);

            // get
            // GetAllEmployee();

            // update employee
            EmployeeModel newEmp = new EmployeeModel
            { Id = 2, FullName = "aps", SalaryInRS = 5000};

            UpdateEmployee(newEmp);

            // boss--------------->>>>>>
            //AddBoss("salil", "Senior Manager", "10");
            //AddBoss("achal", "Manager", "20");
            //AddBoss("dugu", "Senior Manager", "30");
            //AddBoss("dugudu", "employee", "7");

            //FindBossById(2);
            //UpdateBoss(2, "chotu", "manager", "10");

        }

        public static void AddEmployee(string _name, int _salary)
        {
            EmployeeModel newEmp = new EmployeeModel 
            { FullName = _name, SalaryInRS = _salary };

            using(MyDbContext context = new MyDbContext())
            {
                var EmployeeTable = context.Employeess;
                EmployeeTable.Add(newEmp);
                context.SaveChanges();
            }
        }

        public static void GetAllEmployee()
        {
           using(MyDbContext context = new MyDbContext())
            {
                var GetEmployeeTable = context.Employeess;
                foreach (var item in GetEmployeeTable)
                {
                    Console.WriteLine($"{item.FullName} : {item.SalaryInRS}");
                }
            }
        }

        public static void FindEmployeeById(int _id)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var foundEmp = context.Employeess.Find(_id);

                if (foundEmp != null)
                {
                    Console.WriteLine($"{foundEmp.Id} : {foundEmp.FullName} : {foundEmp.SalaryInRS}");
                }
                else
                {
                    Console.WriteLine("No employee found with the given Id");
                }
            }
        }

        public static void DeleteEmployeeById(int _id)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var foundEmp = context.Employeess.Find(_id);

                if (foundEmp != null)
                {
                    context.Employeess.Remove(foundEmp);
                    context.SaveChanges();
                }

            }
        }

        public static void UpdateEmployeeName(int _id, string _name)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var foundEmp = context.Employeess.Find(_id);
                if (foundEmp != null)
                {
                    foundEmp.FullName = _name;
                    context.SaveChanges();
                }
            }
        }

        public static void UpdateEmployee(EmployeeModel newEmp)
        {
            using(MyDbContext context = new MyDbContext())
            {
                context.Employeess.Update(newEmp);
                context.SaveChanges();
            }
        }



        ///////////////////////////////////  BOSSSS  ////////////////////////////////////////////////
        
        public static void AddBoss(string _name,string _post, string _experience)
        {
            Boss NewBoss = new Boss()
            {
                Boss_name = _name,
                Boss_Post = _post,
                Boss_experience = _experience
            };

            using (MyDbContext context = new MyDbContext())
            {
                var BossTable = context.Bossess;
                BossTable.Add(NewBoss);
                context.SaveChanges();
            }
        }

        public static void FindBossById(int _id)
        {
            using(MyDbContext context = new MyDbContext())
            {
                var foundBoss = context.Bossess.Find(_id);
                
                if(foundBoss != null)
                {
                    Console.WriteLine($"{foundBoss.Boss_name} : {foundBoss.Boss_Post}");
                }
                else
                {
                    Console.WriteLine("No boss found with the given id");
                }
            }
        }

        public static void getAllBoss()
        {
            using (MyDbContext context = new MyDbContext())
            {
                var GetEmployeeTable = context.Bossess;
                foreach (var item in GetEmployeeTable)
                {
                    Console.WriteLine($"{item.Boss_experience} : {item.Boss_name}");
                }
            }
        }

        public static void DeleteBossById(int _id)
        {
            using(MyDbContext context = new MyDbContext())
            {
                var foundBoss = context.Bossess.Find(_id);
                if (foundBoss != null)
                {
                    context.Bossess.Remove(foundBoss);
                    context.SaveChanges();
                }
            }
        }

        public static void UpdateBoss(int _id,string _bossname, string _bosspost, string _bossexp)
        {
            using(MyDbContext context = new MyDbContext())
            {
                var foundBoss = context.Bossess.Find(_id);
                if (foundBoss != null)
                {
                    foundBoss.Boss_name = _bossname;
                    foundBoss.Boss_Post = _bosspost;
                    foundBoss.Boss_experience = _bossexp;
                    context.SaveChanges();
                }
            }
        }
    }


}
