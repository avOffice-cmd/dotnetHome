using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Boss
    {
        // syntax called dataAnotation

        public int Boss_id { get; set; }

        public string Boss_name { get; set; }

        public string Boss_Post { get; set; }

        public string Boss_experience { get; set; }
    }
}
