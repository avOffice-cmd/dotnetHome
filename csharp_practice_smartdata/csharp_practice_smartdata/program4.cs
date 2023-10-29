using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice_smartdata
{

    public class Employee1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<string> Programming { get; set; }
    }

    public class Student2
    {
        public int Std_Id { get; set; }

        public string Std_Name { get; set; }

        public string Std_Email { get; set; }

       
    }
        public class program4
    {

        public static void Main(string[] args)
        {
            var Employeee = new List<Employee1>()
            {
                new Employee1(){Id = 1, Name = "achal", Email = "ab@gmail.com", Programming = new List<string>(){"c#","html" }},
                new Employee1(){Id = 2, Name = "salil", Email = "abc@gmail.com", Programming = new List<string>(){"mern", "sql"}},
                new Employee1(){Id = 3, Name = "dugu", Email = "abd@gmail.com", Programming = new List<string>() {"css","sass" }},

            };

            var qs = (from emp in Employeee
                      select new Student2()
                      {
                          Std_Id = emp.Id,
                          Std_Name = emp.Name,
                          Std_Email = emp.Email
                      }).ToList();

            //var datasourse = SelectMany(emp => emp.Programming).ToList();
          //var datasourse = from emp in datasourse
          //                 from skill in emp.Programming
            foreach (var item in qs)
            {
                Console.WriteLine(item.Std_Name);
            }
        }
    }
}
