using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EF_Relationships.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Tech { get; set; }
        public bool? AvailCanteenService { get; set; }
       //officeFloorId int Foreign Key References officeFloor(FloorId)
        public int OfficeFloorId { get; set; }

        public OfficeFloor OfficeFloor { get; set; }

    }
}
