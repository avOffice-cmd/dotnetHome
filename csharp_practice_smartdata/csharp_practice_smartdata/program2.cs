using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice_smartdata
{

    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

    }

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class program2
    {

        public static void Main(string[] args)
        {
            var Student = new List<Students>()
            {

                new Students() {Id = 1, Name = "achal", CategoryId = 1},
                new Students() {Id = 2, Name = "salil", CategoryId = 2},
                new Students() {Id = 3, Name = "dolly", CategoryId = 2},
                new Students() {Id = 4, Name = "dugu", CategoryId = 1},
                new Students() {Id = 5, Name = "anju", CategoryId = 3},
            };

            var Category = new List<Category>()
                {
                  new Category(){Id = 1,Name = "Monitor"},
                  new Category(){Id = 2,Name = "Caption"},
                  new Category(){Id = 3,Name = "nothing"},
                 
                };




            // gropu join
            var GetGroups = from c in Category
                            join s in Student
                            on c.Id equals s.CategoryId
                            into StudentGroups
                          //  where c.Id == 2
                            select new { c, StudentGroups };




            foreach (var item in GetGroups)
            {

                Console.WriteLine(item.c.Name);
         

                foreach (var student in item.StudentGroups)
                {
                    Console.WriteLine($"Student Name: {student.Name}");
                }
            }
        }
    }
 }

