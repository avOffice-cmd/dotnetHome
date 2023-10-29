using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EF_FluentApi
{
    public class Employee
    {
        // [Key]
        public int Id { get; set; }  // taken as primary key by default

        public string FullName { get; set; }

        public int Salary { get; set; }

        public string Post { get; set; }



        //// but this will give u foreign key relation
        //[ForeignKey("Department")]
        //public int DepartmentRefId { get; set; }

        //// this will give u mapping
        //public string Department { get; set;}
    }


}
