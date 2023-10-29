using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class EmployeeModel
    {

        public int Id { get; set; }  // taken as primary key by default

       // [Key]
        public string FullName { get; set; }

        public long SalaryInRS { get; set; }

        public int Boss_id { get; set; }
    }
}
