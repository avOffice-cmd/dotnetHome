using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class EmployeeModel
    {
        public int Id { get; set; }  // taken as primary key by default

        // [Key]
        public string FullName { get; set; }

        public long SalaryInRS { get; set; }

        public int Boss_id { get; set; }
    }
}
