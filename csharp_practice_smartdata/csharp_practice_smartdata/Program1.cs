using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice_smartdata
{
    public class Program1
    {

        public static void Main(string[] args)
        {
            var Students = new List<Student>()

            {
                new Student(){Id = 1, Name = "achal",AddressId = 3},
                new Student(){Id = 2, Name = "salil",AddressId = 2},
                new Student(){Id = 3, Name = "dolly",AddressId = 0},
                new Student(){Id = 4, Name = "karma",AddressId = 2},
                new Student(){Id = 5, Name = "rohit",AddressId = 1},
                new Student(){Id = 6, Name = "rahul",AddressId = 0}

            };

            var Address = new List<Address>()
            {
                 new Address(){Id = 1,AddressLine = "Line 1"},
                 new Address(){Id = 2,AddressLine = "Line 2"},
                 new Address(){Id = 3,AddressLine = "Line 3"},
                 new Address(){Id = 4,AddressLine = "Line 4"},
                 new Address(){Id = 5,AddressLine = "Line 5"},
                 new Address(){Id = 6,AddressLine = "Line 6"},

            };


            var Marks = new List<Marks>()
            {

                new Marks(){Id = 1, StudentId = 1,TMarks = 80},
                new Marks(){Id = 2, StudentId = 2,TMarks = 50},
                new Marks(){Id = 3, StudentId = 3,TMarks = 60},
                new Marks(){Id = 4, StudentId = 4,TMarks = 90},
                new Marks(){Id = 5, StudentId = 5,TMarks = 70},
                new Marks(){Id = 6, StudentId = 6,TMarks = 30},


            };

            //var GetDetails = (from student in Students
            //                 join address in Address
            //                 on student.AddressId equals address.Id
            //                 select new
            //                 {
            //                     StudentName = student.Name,
            //                     Line = address.AddressLine
            //                 }).ToList();

            ///////// joinssssss
            var GetDetails = (from student in Students
                             join address in Address
                             on student.AddressId equals address.Id
                             join marks in Marks
                             on student.Id equals marks.StudentId
                            // where student.Id == 2
                             select new
                             {
                                 StudentName = student.Name,
                                 Line = address.AddressLine,
                                 TotalMarks = marks.TMarks
                             }).ToList();


            foreach (var item in GetDetails)
            {
                Console.WriteLine("studentName :{0}  Line : {1}  TotalMarks : {2}", item.StudentName,item.Line,item.TotalMarks);
            }
        }
    }
}
