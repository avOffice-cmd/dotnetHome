using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Basic_CRUD
{
    public class Boss
    {
        [Key]
        public int Boss_id { get; set; }

        public string Boss_name { get; set; }

        public string Boss_Post { get; set; }

        public string Boss_experience { get; set; }
    }
}
